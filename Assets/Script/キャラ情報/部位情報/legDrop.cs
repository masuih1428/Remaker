using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class legDrop : drop
{
    public int waitTime; //�ďo���\����

    legDrop()
    {
        this.part = "leg";
    }
}
