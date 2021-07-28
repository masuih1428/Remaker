using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharaScript : MonoBehaviour
{
    //キャラ名
    public string charaName;

    //基礎ステータス
    public int max_hp;
    public int max_atk;
    public int max_def;
    public int max_mdef;
    public const int mdef_max = 90;
    public int hp;
    public int atk;
    public int def;
    public int mdef;

    public float atkspeed = 1;//攻撃速度

    public bool magic = false;//マジック使うか
    public bool fry = false;//飛行するか
    
    public string ToString()
    {
        return "name:\n" + this.charaName + "\nhp:" + this.max_hp + "\natk:" + this.max_atk +
            "\ndef:" + this.max_def + "\nmdef:" + this.max_mdef;
    }
}
