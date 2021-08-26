using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBallet : MonoBehaviour
{
    public Unit targetUnit;
    [SerializeField]
    private int atk;
    private float speed = 10;

    internal void SetAtk(int atk)
    {
        this.atk = atk;
    }


    void Update()
    {
        if (targetUnit == null)
        {
            Destroy(gameObject);
            return;
        }

        var v = targetUnit.transform.position - transform.position;
        transform.position += v.normalized * speed * Time.deltaTime;

        if (v.magnitude < 0.7f)
        {
            //Debug.Log(atk);
            targetUnit.hp = targetUnit.hp - atk;
            //Debug.Log(targetEnemy.hp);
            if (targetUnit.hp <= 0)
            {
                Destroy(targetUnit.gameObject);
            }
            //transform.SetParent(targetUnit.transform);
            //enabled = false;
            Destroy(gameObject);
        }
    }
}