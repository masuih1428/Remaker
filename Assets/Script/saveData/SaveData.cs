using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="saveData",menuName ="saveData/mainSaveData")]
public class SaveData : ScriptableObject
{
    public float dificult = 1; //難易度
    public List<GameObject> drops; //ドロップ情報
    public string stage; //選択ステージ
    public List<GameObject> humanParty1;//キャラ編成１
    public List<GameObject> humanParty2;//上同２
    public List<GameObject> humanParty3;//上同３
}
