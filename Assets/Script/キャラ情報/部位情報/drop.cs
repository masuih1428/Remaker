using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Drop : MonoBehaviour
{
    public int cost;
    public string partName;
    public string part;//どこの部位か
    public int hp;
    public int atk;
    public int def;
    public int mdef;
    public float rareFloat = 1;
    public string rare = "";//レア度

    public void Start()
    {
    }

    public string Tostring()
    {

        string returnstring = "part:"+this.part +"\n"+"hp:" + this.hp + "\natk:"+ this.atk + "\ndef:" + this.def + "\nmdef:" + this.mdef  + "\n";
        return returnstring;
    } 

    public void rareStart()
    {
        //rareがnullの時のみ最初にレアリティを決める
        Debug.Log("Start");
        if (this.rare == "")
        {
            //レア度がnullの場合のみレア度を乱数で作成
            float r1 = Random.value;//0.0f～1.0fまでの値
            float rare = 0.3f; //レア
            float epic = 0.1f; //エピック

            switch (r1)
            {
                case float r2 when r2 < epic:
                    this.rare = "epic";
                    this.rareFloat = 1.1f;
                    break;
                case float r2 when r2 < rare + epic:
                    this.rare = "rare";
                    this.rareFloat = 1.05f;
                    break;
                default:
                    this.rare = "normal";
                    break;
            }
            //ステータスの上昇
            this.hp = (int)(this.hp * rareFloat);
            this.atk = (int)(this.atk * rareFloat);
            this.def = (int)(this.def * rareFloat);
            this.mdef = (int)(this.mdef * rareFloat);
        }
    }
}
