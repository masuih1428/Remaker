using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="saveData",menuName ="saveData/mainSaveData")]
public class SaveData : ScriptableObject
{
    [SerializeField]
    public float dificult = 1; //難易度
    public List<GameObject> drops; //ドロップ情報
    public List<Drop> dropScript;//ドロップ情報のスクリプトのみを格納する場所
    public string stage; //選択ステージ
    public List<GameObject> humanParty1;//キャラ編成１
    public List<GameObject> humanParty2;//上同２
    public List<GameObject> humanParty3;//上同３
    public List<GameObject> humanList;
    [SerializeField]
    public GameObject DragObj;//ドラック＆ドロップで使用する変数
}
