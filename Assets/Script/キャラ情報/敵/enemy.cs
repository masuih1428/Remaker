using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : chara
{
    public bool stealth = false;//ステルスかどうか
    public int attribute = 0;//キャラの属性 0が無 1が火 2が水 3が木
    public float move = 1; //移動速度
    public float dps = 1; //攻撃速度(dps換算）
    public float deficult = 1; //難易度補正;

    public List<GameObject> dropList;

    void Start()
    {
        //コンストラクタ
        this.hp = (int)(this.max_hp * this.deficult);
        this.atk = (int)(this.max_atk * this.deficult);
        this.def = (int)(this.max_def * this.deficult);
        this.mdef = (int)(this.max_mdef * this.deficult);
    }

    void Start(int dif)//難易度受け取り
    {
        //コンストラクタ
        this.deficult = dif;
        this.hp = (int)(this.max_hp * this.deficult);
        this.atk = (int)(this.max_atk * this.deficult);
        this.def = (int)(this.max_def * this.deficult);
        this.mdef = (int)(this.max_mdef * this.deficult);
    }
}
