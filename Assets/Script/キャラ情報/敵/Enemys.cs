using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemys : CharaScript
{
    public int grade;
    public int id;
    public bool stealth = false;//ステルスかどうか
    public int attribute = 0;//キャラの属性 0が無 1が火 2が水 3が木
    public float move = 1; //移動速度
    public float dps = 1; //攻撃速度(dps換算)
    public SaveData savedata;

    public List<GameObject> dropList;

    void Start()
    {
        //コンストラクタ
        this.hp = (int)(this.max_hp * savedata.dificult);
        this.atk = (int)(this.max_atk * savedata.dificult);
        this.def = (int)(this.max_def * savedata.dificult);
        this.mdef = (int)(this.max_mdef * savedata.dificult);
    }
}
