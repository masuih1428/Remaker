using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="saveData",menuName ="saveData/mainSaveData")]
public class SaveData : ScriptableObject
{
    public float dificult = 1; //��Փx
    public List<GameObject> drops; //�h���b�v���
    public string stage; //�I���X�e�[�W
}
