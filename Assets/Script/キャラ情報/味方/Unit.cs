using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : CharaScript
{
    public int Cost;
    public int Price => Cost / 2;
    public HeadDrop head;//頭
    public BodyDrop body;//体
    public HandDrop hand;//手
    public LegDrop leg;//足
    public Wepon wepon;//武器

    public List<Enemys> blockEnemy;//ブロックしているEnemy

    [SerializeField]
    private GameObject HPUI;//HPバー
    private Slider hpSlider;

    private Enemys enemy;

    // Start is called before the first frame update
    void Start()
    {
        //ステータス設定
        hp = head.hp + body.hp + hand.hp + leg.hp+wepon.hp;
        atk = head.atk + body.atk + hand.atk + leg.atk + wepon.atk;
        def = head.def + body.def + hand.def + leg.def + wepon.def;
        mdef = head.mdef + body.mdef + hand.mdef + leg.mdef + wepon.mdef;
        //HPバー設定
        hpSlider = HPUI.transform.Find("HPBar").GetComponent<Slider>();
        hpSlider.value = 1f;
        StartCoroutine("UpdateUnitHPValue");


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)//Enemyがふれたとき
    {
        if (collision.collider.gameObject.layer == 3 && blockEnemy.Count < body.max_block) //レイヤー3=Enemys
        {
            blockEnemy.Add(collision.collider.gameObject.GetComponent<Enemys>());
            //Debug.Log(collision.collider.name); // ぶつかった相手の名前を取得
        }
    }
    void OnCollisionStay2D(Collision2D collision)//Enemyが触れている間
    {
        if (collision.collider.gameObject.layer == 3 && blockEnemy.Count < body.max_block)
        {

            for (int i = 0; i < blockEnemy.Count; i++)
            {
                if (blockEnemy[i].id == collision.collider.gameObject.GetComponent<Enemys>().id)
                {
                    return;
                }
            }
            blockEnemy.Add(collision.collider.gameObject.GetComponent<Enemys>());
        }
    }
    void OnCollisionExit2D(Collision2D collision)//Enemyが離れたとき
    {
        if (collision.collider.gameObject.layer == 3 && hp > 0)
        {
            for (int i = 0; i < blockEnemy.Count; i++)
            {
                if (blockEnemy[i].id == collision.collider.gameObject.GetComponent<Enemys>().id)
                {
                    blockEnemy.RemoveAt(i);
                }
            }
        }
    }

    private IEnumerator UpdateUnitHPValue()//hpバーの更新
    {
        while (true)
        {
            yield return null;
            hpSlider.value = (float)hp / (float)max_hp;
        }
    }

    private IEnumerator ShortDistance()//近接攻撃
    {
        while (true)
        {
            yield return new WaitForSeconds(hand.atkSpeed);
            var collider = Physics2D.OverlapCircle(transform.position, wepon.range, LayerMask.GetMask("Enemy"));
            if (collider != null)
            {

                if(enemy==null && blockEnemy.Count != 0)
                {
                    yield return StartCoroutine(EnemySet());
                }

                if (enemy != null)
                {
                    if (magic)
                    {

                    }
                    else
                    {
                        if ((atk - enemy.def) < 0)
                        {
                            enemy.hp -= (int)(atk * 0.05);
                        }
                        else
                        {
                            enemy.hp = enemy.hp - (atk - enemy.def);
                        }
                    }

                    if (enemy.hp <= 0)
                    {
                        Destroy(enemy.gameObject);
                        //FindObjectOfType<Player>().gold += enemy.gold;
                    }
                }
            }

        }
    }
    private IEnumerator EnemySet()
    {
        enemy = blockEnemy[0];
        yield break;
    }//
    private IEnumerator LongDistance()//遠距離
    {
        while (true)
        {
            yield return new WaitForSeconds(hand.atkSpeed);
            // ここで敵を探して、敵を撃つ
            var collider = Physics2D.OverlapCircle(transform.position, wepon.range, LayerMask.GetMask("Enemy"));
            if (collider != null)
            {
                //transform.rotation = Quaternion.FromToRotation(Vector3.right, collider.transform.position - transform.position);
                var arrow = Instantiate(wepon.ballet, transform.position, transform.rotation);
                arrow.transform.rotation = Quaternion.FromToRotation(Vector3.right, collider.transform.position - transform.position);
                arrow.targetEnemy = collider.GetComponent<Enemys>();
            }
        }
    }

}
