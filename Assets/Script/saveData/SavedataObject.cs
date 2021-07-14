using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavedataObject
{
    //Static変数を最初に宣言するためのスクリプト
    public float dificult = 1.0f;//難易度
    public List<drop> drops;//ドロップ情報
    public List<GameObject> character;//味方キャラ情報
}
