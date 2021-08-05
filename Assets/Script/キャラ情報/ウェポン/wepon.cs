using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wepon : Drop
{
    public bool weponType;//Trueなら遠距離
    public float range = 1;//射程範囲
    public bool magic;//魔法使うか
    public float atkSpeed = 1;//攻撃速度
    public int atkattribute;//攻撃属性 0が無 1が火 2が水 3が木
    public bool heal; //ヒール使うか
    public Ballet ballet;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
