using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drop : MonoBehaviour
{
    public string part;//どこの部位か
    public int hp;
    public int atk;
    public int def;
    public int mdef;

    public string rare = null;//レア度

    public void Start()
    {
        //レア度がnullの場合のみレア度を乱数で作成
        float r1 = Random.value;//0.0f～1.0fまでの値
        float normal = 0.6f;//ノーマルの確率
        float rare = 0.3f; //レア
        float epic = 0.1f; //エピック

        switch (r1) 
        {
            case float r2 when r2 < epic:
                this.rare = "epic";
                break;
            case float r2 when r2 < rare + epic:
                this.rare = "rare";
                break;
            default:
                this.rare = "normal";
                break;
        }
    }
}
