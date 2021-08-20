using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public EnemyBallet balletPrefab;
    public Unit unit;
    public int id;
    [SerializeField]
    private int MAX_HP;
    public int hp;
    //
    public int atk;

    public float atkspeed;
    public float range;
    public float AtkRange => range + 1 * 0.5f;
    public float AtkInterval => 1.0f * Mathf.Pow(atkspeed, 1);

    public float speed;
    public int gold;
    public Route route;
    private int pointIndex;
    private bool blockCk;

    [SerializeField]


    // Start is called before the first frame update
    void Start()
    {
        hp = MAX_HP;


        StartCoroutine("EnemyHP");

        if (balletPrefab != null)
        {
            balletPrefab.SetAtk(atk);
            StartCoroutine(SearchAndShot());
        }

        blockCk = true;
        transform.position = route.points[0].transform.position;
        StartCoroutine("AttackUnit");

    }

    // Update is called once per frame
    /*void Update()
    {
        if(blockCk)
        {
            var v = route.points[pointIndex + 1].transform.position - route.points[pointIndex].transform.position;
            transform.position += v.normalized * speed * Time.deltaTime;

            var pv = transform.position - route.points[pointIndex].transform.position;
            if (pv.magnitude >= v.magnitude)
            {
                pointIndex++; //次のPointへ
            }

            if (pointIndex >= route.points.Length - 1)
            {
                Destroy(gameObject);
                //プレイヤーへダメージ
                FindObjectOfType<Player>().hp--;
            }
        }
    }*/

    private IEnumerator AttackUnit()
    {
        while (true)
        {
            //
            //UpdateHPValue();
            yield return null;
            if (blockCk)
            {
                var v = route.points[pointIndex + 1].transform.position - route.points[pointIndex].transform.position;
                transform.position += v.normalized * speed * Time.deltaTime;



                var pv = transform.position - route.points[pointIndex].transform.position;
                if (pv.magnitude >= v.magnitude)
                {
                    pointIndex++; //次のPointへ
                }

                if (pointIndex >= route.points.Length - 1)
                {
                    Destroy(gameObject);
                    //プレイヤーへダメージ
                    FindObjectOfType<Player>().hp--;
                }

            }

            else if (blockCk == false && unit != null && unit.hp > 0)
            {
                yield return StartCoroutine(Unitatk());
            }


        }
    }

    private IEnumerator Unitatk()
    {
        //
        //UpdateHPValue();
        yield return new WaitForSeconds(AtkInterval);
        try
        {
            //
            //UpdateHPValue();

            unit.hp = unit.hp - atk;
            Debug.Log(unit.hp);
            if (unit.hp <= 0)
            {
                Destroy(unit.gameObject);
            }
            yield break;
        }
        catch (NullReferenceException e)
        {
            //Debug.Log("ああああ");
            yield break;
        }
    }

    private IEnumerator SearchAndShot()
    {
        int ck = 0;
        Collider2D collider = null;

        while (true)
        {
            //
            //UpdateHPValue();
            yield return new WaitForSeconds(AtkInterval);


            try
            {
                //
                //UpdateHPValue();

                collider = Physics2D.OverlapCircle(transform.position, AtkRange, LayerMask.GetMask("Unit"));
                if (collider != null && balletPrefab != null)
                {
                    //Debug.Log(200);
                    StopCoroutine("AttackUnit");

                    ck = 1;
                    transform.position = transform.position;
                    var ballet = Instantiate(balletPrefab, transform.position, transform.rotation);
                    ballet.transform.rotation = Quaternion.FromToRotation(Vector3.right, collider.transform.position - transform.position);
                    ballet.targetUnit = collider.GetComponent<Unit>();


                }

            }
            catch (MissingReferenceException e)
            {

            }


            if (ck == 1 && collider != null)
            {
                yield return new WaitForSeconds(1f);
                ck = 0;
                StartCoroutine("AttackUnit");
            }

        }



    }

    void OnCollisionEnter2D(Collision2D collision)//unitにふれたとき
    {

        if (collision.collider.gameObject.layer == 10 && unit == null)//レイヤー10=Unit
        {
            unit = collision.collider.gameObject.GetComponent<Unit>();
            if (balletPrefab != null)
            {
                StopCoroutine("AttackUnit");

            }

            //Debug.Log(unit.name); // ぶつかった相手の名前を取得


        }
    }
    void OnCollisionStay2D(Collision2D collision)//unitに触れている間
    {
        if (collision.collider.gameObject.layer == 10)
        {
            if (balletPrefab != null)
            {

                StopCoroutine("AttackUnit");
            }

            foreach (Enemy enemy in unit.blockEnemy)
            {
                if (enemy.id == id)
                {
                    blockCk = false;
                    break;
                }
            }
        }

    }

    void OnCollisionExit2D(Collision2D collision)//unitから離れたとき
    {
        if (collision.collider.gameObject.layer == 10)
        {
            if (balletPrefab != null)
            {
                StartCoroutine("AttackUnit");
            }

            blockCk = true;
            unit = null;
        }

    }
    public int GetHP()
    {
        return this.hp;
    }
    public int GetMAXHP()
    {
        return this.MAX_HP;
    }
    public void UpdateHPValue()
    {

    }
    private IEnumerator EnemyHP()
    {
        while (true)
        {
            yield return null;
            UpdateHPValue();
        }
    }
}
