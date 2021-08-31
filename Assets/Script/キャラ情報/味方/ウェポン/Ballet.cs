using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballet : MonoBehaviour
{
    public Enemys targetEnemy;
    [SerializeField]
    private int atk;
    private float Balletspeed = 10;

    internal void SetAtk(int atk)
    {
        this.atk = atk;
    }

    void Update()
    {
        Debug.Log("B1");
        if (targetEnemy == null)
        {
            //Debug.Log("B2");
            //Destroy(gameObject);
            return;
        }
        
        var v = targetEnemy.transform.position - transform.position;
        Debug.Log("B4");
        transform.position += v.normalized * Balletspeed * Time.deltaTime;
        Debug.Log("B5");
        if (v.magnitude < 0.7f)//‚æ‚­‚È‚¢
        {
            Debug.Log("B6");
            //Debug.Log(atk);
            targetEnemy.hp = targetEnemy.hp - atk;
            Debug.Log("B7");
            //Debug.Log(targetEnemy.hp);
            if (targetEnemy.hp <= 0)
            {
                Debug.Log("B8");
                Destroy(targetEnemy.gameObject);
                FindObjectOfType<Player>().cost += targetEnemy.cost;
            }
            Debug.Log("B9");
            //transform.SetParent(targetEnemy.transform);
            //enabled = false;
            Destroy(gameObject);
        }
    }
}
