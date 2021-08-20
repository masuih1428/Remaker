using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemys : CharaScript
{
    public bool stealth = false;//ステルスかどうか
    public int attribute = 0;//キャラの属性 0が無 1が火 2が水 3が木
    public float move = 1; //移動速度
    public float dps = 1; //攻撃速度(dps換算）
    public SaveData savedata;

    public List<GameObject> dropList;

    public Route route;//ルート決めるやつ
    private int pointIndex;//追加した２文

    void Start()
    {
        //コンストラクタ
        this.hp = (int)(this.max_hp * savedata.dificult);
        this.atk = (int)(this.max_atk * savedata.dificult);
        this.def = (int)(this.max_def * savedata.dificult);
        this.mdef = (int)(this.max_mdef * savedata.dificult);
    }
    void Update()//追加した文
    {
        var v = route.points[pointIndex + 1].transform.position - route.points[pointIndex].transform.position;
        transform.position += v.normalized * move * Time.deltaTime;

        var pv = transform.position - route.points[pointIndex].transform.position;
        if (pv.magnitude >= v.magnitude)
        {
            pointIndex++;

            if (pointIndex >= route.points.Length - 1)//最後まで到達した
            {
                Destroy(gameObject);
                //TODO プレイヤーにダメージ
            }
        }
    }
}
