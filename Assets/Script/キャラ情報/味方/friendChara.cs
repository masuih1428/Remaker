using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FriendChara:Chara
{
    public int defattribute = 0;//�瑮��
    public float MatkSpeed; //���@�U�����x
    public int block;//�u���b�N��
    public bool wepon = false; //���킪�����\��
    public int waitTime; //�ďo���\����
    public List<GameObject> gameObjects;
}
