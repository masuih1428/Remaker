using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Drop : MonoBehaviour
{
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

        string returnstring = "part:"+this.part +"\n"+"hp:" + (this.hp * this.rareFloat) + "\natk:"+ +(this.atk * this.rareFloat) + "\ndef:" + (this.def * this.rareFloat) + "\nmdef:" + (this.mdef * this.rareFloat) + "\n";
        return returnstring;
    } 

    public void rareStart()
    {
        //rareがnullの時のみ最初にレアリティを決める
        Debug.Log("Start");
        if (this.rare == "")
        {
            Debug.Log("null");
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
        }
    }
}
