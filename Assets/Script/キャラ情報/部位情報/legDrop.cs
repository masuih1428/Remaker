using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LegDrop : Drop
{
    public int waitTime; //再出撃可能時間

    LegDrop()
    {
        this.part = "leg";
    }
}
