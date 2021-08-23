using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HeadDrop : Drop
{
    public int defattribute = 0;//ç‘®«
    public float MatkSpeed; //–‚–@UŒ‚‘¬“x

    HeadDrop()
    {
        this.part = "head";
    }
}
