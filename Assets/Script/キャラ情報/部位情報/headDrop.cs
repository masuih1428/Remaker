using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HeadDrop : Drop
{
    public int defattribute = 0;//�瑮��
    public float MatkSpeed; //���@�U�����x

    HeadDrop()
    {
        this.part = "head";
    }
}
