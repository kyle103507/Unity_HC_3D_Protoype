using UnityEngine;
using UnityEngine.UI;
using System.Collections;


/// <summary>
/// 對話系統
/// 1.決定說話者名稱
/// 2.決定畫畫內容 - 可以有多段
/// 3.顯示每個段落對話完成圖示動態效果
/// </summary>
public class DialogueSystem : MonoBehaviour
{
    #region 欄位
    [Header("對話資料")]
    public DialogueData data;
    [Header("對話間格"), Range(0, 3)]
    public float interval = 0.2f;
    [Header("對話完成圖示")]
    public GameObject goFinishIcon;
    [Header("文字介面:說話者名稱、對話文字內容")]
    public Text texTalker;
    public Text textContent;

    ///
    ///對話系統桌布:群組元件
    ///
    private CanvasGroup groupDialogue;
    #endregion

    [Header("繼續對話的按鍵")]
    public KeyCode kcContinute = KeyCode.Space;
    [Header("打字音效")]
    public AudioClip soundType;
    [Header("打字音量"), Range(0, 2)]
    public float volume = 1;

    private AudioSource aud;

    private void Start()
    {
        aud = GetComponent<AudioSource>();
        groupDialogue = transform.GetChild(0).GetComponent<CanvasGroup>();

        StartDialogue();
    }

    ///
    ///開始對話
    ///
    private void StartDialogue()
    {
        StartCoroutine(ShowEveryDialogue());
    }

    private IEnumerator ShowEveryDialogue()
    {
        groupDialogue.alpha = 1;
        texTalker.text = data.diaogueTalkerName;
        textContent.text = "";

        for (int i = 0; i < data.diaogueContents.Length; i++)
        {
            for (int j = 0; j < data.diaogueContents[i].Length; j++)
            {         
            textContent.text += data.diaogueContents[i][j];
            aud.PlayOneShot(soundType, volume);
            yield return new WaitForSeconds(interval);
            }

            goFinishIcon.SetActive(true);

            while (!Input.GetKeyDown(kcContinute))
            {
                yield return null;
            }

            textContent.text = "";
            goFinishIcon.SetActive(false);
        }
    }
}
