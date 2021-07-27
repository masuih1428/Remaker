using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="saveData",menuName ="saveData/mainSaveData")]
public class SaveData : ScriptableObject
{
    public float dificult = 1; //��Փx
    public List<GameObject> drops; //�h���b�v���
    public string stage; //�I���X�e�[�W
    public List<GameObject> humanParty1;//�L�����Ґ��P
    public List<GameObject> humanParty2;//�㓯�Q
    public List<GameObject> humanParty3;//�㓯�R
}
