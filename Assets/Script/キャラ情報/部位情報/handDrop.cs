using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HandDrop : Drop
{
    public float atkSpeed;//�����U�����x
    public bool wepon = false; //���킪�����\��

    HandDrop()
    {
        this.part = "hand";
    }
}
