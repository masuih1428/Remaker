using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handDrop : drop
{
    public float atkSpeed;//�����U�����x
    public bool wepon = false; //���킪�����\��

    handDrop()
    {
        this.part = "hand";
    }
}
