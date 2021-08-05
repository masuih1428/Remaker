using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="saveData",menuName ="saveData/mainSaveData")]
public class SaveData : ScriptableObject
{
    [SerializeField]
    public float dificult = 1; //��Փx
    public List<GameObject> drops; //�h���b�v���
    public List<Drop> dropScript;//�h���b�v���̃X�N���v�g�݂̂��i�[����ꏊ
    public string stage; //�I���X�e�[�W
    public List<GameObject> humanParty1;//�L�����Ґ��P
    public List<GameObject> humanParty2;//�㓯�Q
    public List<GameObject> humanParty3;//�㓯�R
    public List<GameObject> humanList;
    [SerializeField]
    public GameObject DragObj;//�h���b�N���h���b�v�Ŏg�p����ϐ�
}
