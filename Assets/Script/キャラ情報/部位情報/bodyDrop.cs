using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bodyDrop : drop
{
    public int block;//�u���b�N��
    public bool fry = false;//��s���邩�ǂ���

    bodyDrop()
    {
        this.part = "body";
    }
}
