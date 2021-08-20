using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public int unittype;//0‚ª‹ß‹——£1‚ª‰“‹——£
    public int lv;
    [SerializeField]
    private int MAX_HP;
    public int hp;
    public int atk;
    public int MAX_BLOCK;
    public float range;
    public float atkspeed;
    public int CostManey;
    public List<Enemy> blockEnemy;
    public float ShotRange => range + (unittype * lv * 0.5f);
    public float ShotInterval => 1.0f * Mathf.Pow(atkspeed, lv);
    public int Cost => (int)(CostManey * Mathf.Pow(1.5f, lv));
    public int Price => Cost / 2;

    public int GetMAX_HP()
    {
        return MAX_HP;
    }
    public int GetHP()
    {
        return hp;
    }
}

