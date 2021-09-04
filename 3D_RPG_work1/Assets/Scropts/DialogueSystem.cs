using UnityEngine;
using UnityEngine.UI;
using System.Collections;


/// <summary>
/// ��ܨt��
/// 1.�M�w���ܪ̦W��
/// 2.�M�w�e�e���e - �i�H���h�q
/// 3.��ܨC�Ӭq����ܧ����ϥܰʺA�ĪG
/// </summary>
public class DialogueSystem : MonoBehaviour
{
    #region ���
    [Header("��ܸ��")]
    public DialogueData data;
    [Header("��ܶ���"), Range(0, 3)]
    public float interval = 0.2f;
    [Header("��ܧ����ϥ�")]
    public GameObject goFinishIcon;
    [Header("��r����:���ܪ̦W�١B��ܤ�r���e")]
    public Text texTalker;
    public Text textContent;

    ///
    ///��ܨt�ή६:�s�դ���
    ///
    private CanvasGroup groupDialogue;
    #endregion

    [Header("�~���ܪ�����")]
    public KeyCode kcContinute = KeyCode.Space;
    [Header("���r����")]
    public AudioClip soundType;
    [Header("���r���q"), Range(0, 2)]
    public float volume = 1;

    private AudioSource aud;

    private void Start()
    {
        aud = GetComponent<AudioSource>();
        groupDialogue = transform.GetChild(0).GetComponent<CanvasGroup>();

        StartDialogue();
    }

    ///
    ///�}�l���
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
