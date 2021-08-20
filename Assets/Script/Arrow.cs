using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Enemy targetEnemy;
    [SerializeField]
    private int atk;
    private float speed = 10;

    internal void SetAtk(int atk)
    {
        this.atk = atk;
    }

    void Update()
    {
        if (targetEnemy == null)
        {
            Destroy(gameObject);
            return;
        }

        var v = targetEnemy.transform.position - transform.position;
        transform.position += v.normalized * speed * Time.deltaTime;

        if (v.magnitude < 0.7f)
        {
            //Debug.Log(atk);
            targetEnemy.hp = targetEnemy.hp - atk;
            //Debug.Log(targetEnemy.hp);
            if (targetEnemy.hp <= 0)
            {
                Destroy(targetEnemy.gameObject);
                FindObjectOfType<Player>().gold += targetEnemy.gold;
            }
            transform.SetParent(targetEnemy.transform);
            enabled = false;
        }
    }
}