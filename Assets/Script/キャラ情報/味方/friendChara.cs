using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FriendChara:Chara
{
    public int defattribute = 0;//守属性
    public float MatkSpeed; //魔法攻撃速度
    public int block;//ブロック数
    public bool wepon = false; //武器が装備可能か
    public int waitTime; //再出撃可能時間
    public List<GameObject> gameObjects;
}
