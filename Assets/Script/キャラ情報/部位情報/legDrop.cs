using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LegDrop : Drop
{
    public int waitTime; //�ďo���\����

    LegDrop()
    {
        this.part = "leg";
    }
}
