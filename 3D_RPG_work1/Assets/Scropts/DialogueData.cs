using UnityEngine;

/// <summary>
/// �x�s��ܸ��
/// 1.��ܪ̦W��
/// 2.��ܤ��e - �h�q
/// </summary>
/// �~�����O�אּ ScripableObject �}���ƪ���
/// �N�����O�����e�i�H�إߪ�����x�s��M�פ�
/// �ݷf�t CreateAsstMenu �إ߯����ﶵ�ӫإߦ�����
[CreateAssetMenu(menuName = "Kyle/��ܸ��", fileName = "��ܸ��")]
public class DialogueData : ScriptableObject
{
    [Header("��ܪ̦W��")]
    public string diaogueTalkerName;
    [Header("��ܤ��e"), TextArea(2, 5)]
    public string[] diaogueContents;
}
