using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class legDrop : drop
{
    public int waitTime; //再出撃可能時間

    legDrop()
    {
        this.part = "leg";
    }
}
