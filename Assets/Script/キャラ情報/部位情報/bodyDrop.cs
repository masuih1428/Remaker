using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BodyDrop : Drop
{
    public int max_block;//�u���b�N��
    public bool fry = false;//��s���邩�ǂ���

    BodyDrop()
    {
        this.part = "body";
    }
}
