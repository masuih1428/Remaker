using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class bodyDrop : drop
{
    public int block;//ブロック数
    public bool fry = false;//飛行するかどうか

    bodyDrop()
    {
        this.part = "body";
    }
}
