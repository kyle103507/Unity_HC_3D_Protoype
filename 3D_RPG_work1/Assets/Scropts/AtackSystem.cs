using UnityEngine;


/// <summary>
/// �����t��
/// �T�q�����P����
/// </summary>
public class AtackSystem : MonoBehaviour
{
    #region ���:���}
    [Header("�ѼƦW��")]
    public string praAttackPart = "���q�q��";
    public string parAttackGather = "���𶰮�";
    [Header("�s�����浥�ݮɶ�"), Range(0, 2)]
    public float intervalBetweenAttackPart = 0.2f;
    [Header("����ɶ�"), Range(0, 2)]
    public float timeToAttackGather = 1;
    #endregion

    #region ���:�p�H
    private Animator ani;
    /// <summary>
    /// �������a���U���䪺�ɶ�
    /// </summary>
    private float timer;
    #endregion

    #region �ƥ�
    //����ƥ�:�C�������w�� Start ���椧�e����@��
    private void Awake()
    {
        ani = GetComponent<Animator>();
    }

    //�}�l�ƥ�:�C�������w�� Awake ���椧�e����@��
    private void Start()
    {

    }

    private void Update()
    {
        ClickTime();
    }
    #endregion

    #region ��k:�p�H
    /// <summary>
    /// �I���ɶ����֥[
    /// </summary>
    private void ClickTime()
    {
        if (Input.GetKey(KeyCode.Mouse0))                  //�t�� ����
        {
            timer += Time.deltaTime;�@�@�@�@�@�@�@�@�@�@�@ //�֥[ �p�ɾ�
        }
        else if (Input.GetKey(KeyCode.Mouse0))              //��}����
        {
            if (timer >= timeToAttackGather)                //�p�G �p�ɾ� >= ����ɶ�
            {
                AttackGather();
            }
            else                                           // �_�h
            {
                print("����ɶ�����");
            }

            timer = 0;                                     // �p�ɾ��k�s
        }

        print("���U���䪺�ɶ�:" + timer);
    }

    ///
    ///�������
    ///
    private void AttackGather()
    {
        ani.SetTrigger(parAttackGather);
    }
    #endregion
}
