using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HandDrop : Drop
{
    public float atkSpeed;//•¨—UŒ‚‘¬“x
    public bool wepon = false; //•Ší‚ª‘•”õ‰Â”\‚©

    HandDrop()
    {
        this.part = "hand";
    }
}
