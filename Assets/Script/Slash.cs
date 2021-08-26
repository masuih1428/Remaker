using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{
    public Enemys targetEnemy;
    [SerializeField]
    private int atk;

    internal void SetAtk(int atk)
    {
        this.atk = atk;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetEnemy == null)
        {
            Destroy(gameObject);
            return;
        }

        //Debug.Log(atk);
        targetEnemy.hp = targetEnemy.hp - atk;
        //Debug.Log(targetEnemy.hp);
        if (targetEnemy.hp <= 0)
        {
            Destroy(targetEnemy.gameObject);
            FindObjectOfType<Player>().cost += targetEnemy.cost;
        }
        Destroy(gameObject);
    }
}
