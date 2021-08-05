using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BodyDrop : Drop
{
    public int max_block;//ブロック数
    public bool fry = false;//飛行するかどうか

    BodyDrop()
    {
        this.part = "body";
    }
}
