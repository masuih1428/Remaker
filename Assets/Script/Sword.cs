using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class Sword : Unit
{
    [SerializeField]
    private GameObject HPUI;
    private Slider hpSlider;

    private Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        hp = GetMAX_HP();

        hpSlider = HPUI.transform.Find("HPBar").GetComponent<Slider>();
        hpSlider.value = 1f;
        StartCoroutine("UnitHP");

        //blockEnemy = new List<Enemy>();
        StartCoroutine(AttackSword());
    }

    private IEnumerator AttackSword()
    {
        while (true)
        {
            //enabled = false;
            yield return new WaitForSeconds(ShotInterval);
            //enabled = true;

            var collider = Physics2D.OverlapCircle(transform.position, ShotRange, LayerMask.GetMask("Enemy"));
            if (collider != null)
            {
                //transform.rotation = Quaternion.FromToRotation(Vector3.up, collider.transform.position - transform.position);
                //yield return new WaitForSeconds(1f);

                if(enemy== null && blockEnemy.Count != 0)
                {
                    yield return StartCoroutine(Ene());
                }
                if (enemy != null)
                {
                   
                    enemy.hp = enemy.hp - atk;
                    Debug.Log(enemy.hp);
                    if (enemy.hp <= 0)
                    {
                        Destroy(enemy.gameObject);
                        FindObjectOfType<Player>().gold += enemy.gold;
                    }
                }
                /*if (blockEnemy.Count!=0)
                {
                    var at = Instantiate(slash, transform.position, transform.rotation);
                    at.targetEnemy = blockEnemy[0];
                }*/
            }

        }
    }

    private IEnumerator Ene()
    {
        enemy = blockEnemy[0];  
        yield break;
    }

    public void UpdateHPValue()
    {
        hpSlider.value = (float)GetHP() / (float)GetMAX_HP();
    }
    private IEnumerator UnitHP()
    {
        while (true)
        {
            yield return null;
            UpdateHPValue();
        }
    }


    void OnCollisionEnter2D(Collision2D collision)//EnemyÇ™Ç”ÇÍÇΩÇ∆Ç´
    {
        if (collision.collider.gameObject.layer==8 && blockEnemy.Count < MAX_BLOCK) //ÉåÉCÉÑÅ[8=Enemy
        {
            blockEnemy.Add(collision.collider.gameObject.GetComponent<Enemy>());
            //Debug.Log(collision.collider.name); // Ç‘Ç¬Ç©Ç¡ÇΩëäéËÇÃñºëOÇéÊìæ
        }
    }
    void OnCollisionStay2D(Collision2D collision)//EnemyÇ™êGÇÍÇƒÇ¢ÇÈä‘
    {
        if (collision.collider.gameObject.layer == 8 && blockEnemy.Count < MAX_BLOCK)
        {

            for (int i = 0; i < blockEnemy.Count; i++)
            {
                if (blockEnemy[i].id == collision.collider.gameObject.GetComponent<Enemy>().id)
                {
                    return;
                }
            }
            blockEnemy.Add(collision.collider.gameObject.GetComponent<Enemy>());
        }
    }

    void OnCollisionExit2D(Collision2D collision)//EnemyÇ™ó£ÇÍÇΩÇ∆Ç´
    {
        if (collision.collider.gameObject.layer == 8 && hp>0)
        {
            for(int i=0;i<blockEnemy.Count;i++)
            {
                if (blockEnemy[i].id == collision.collider.gameObject.GetComponent<Enemy>().id)
                {
                    blockEnemy.RemoveAt(i);
                }
            }
        }
    }
}
