using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Unit : CharaScript
{
    [SerializeField]
    public int unittype;//0が近距離1が遠距離
    public int lv;
    
    //private int max_hp;
    //public int hp;
    //public int atk;
    public int MAX_BLOCK;
    public float range;
    //public float atkspeed;
    //public int CostManey;
   
    public float ShotRange => range + (unittype * lv * 0.5f);
    public float ShotInterval => 1.0f * Mathf.Pow(atkspeed, lv);
    //public int Cost;
   
    
    public int Price => cost / 2;
    public HeadDrop head;//頭
    public BodyDrop body;//体
    public HandDrop hand;//手
    public LegDrop leg;//足
    public Wepon wepon;//武器
    public GameObject headObj;
    public GameObject bodyObj;
    public GameObject handObj;
    public GameObject legObj;
    public GameObject weponObj;
    //
    public int max_block;
    public Ballet balletPrefab;

    public List<Enemys> blockEnemy;//ブロックしているEnemy

    [SerializeField]
    private GameObject HPUI;//HPバー
    private Slider hpSlider;

    private Enemys enemy;

    public int id;

    // Start is called before the first frame update
    public void Start()
    {
        //ステータス設定
 
        hp = head.hp + body.hp + hand.hp + leg.hp+wepon.hp;
        atk = head.atk + body.atk + hand.atk + leg.atk + wepon.atk;
        def = head.def + body.def + hand.def + leg.def + wepon.def;
        mdef = head.mdef + body.mdef + hand.mdef + leg.mdef + wepon.mdef;
        magic = wepon.magic;
        fry =  body.fry;
        cost = head.cost + body.cost + hand.cost + leg.cost;
        max_block = body.max_block;
        //HPバー設定
        hpSlider = HPUI.transform.Find("HPBar").GetComponent<Slider>();
        hpSlider.value = 1f;
        StartCoroutine("UpdateUnitHPValue");

        if (unittype == 0)
        {
            StartCoroutine(ShortDistance());
        }else if(unittype==1)
        {
            balletPrefab.SetAtk(atk);
            Debug.Log(balletPrefab);
            StartCoroutine(LongDistance());
           
        }
    }

    // Update is called once per frame

    void OnCollisionEnter2D(Collision2D collision)//Enemyがふれたとき
    {
        if (collision.collider.gameObject.layer == 8 && blockEnemy.Count < max_block) //レイヤー3=Enemys
        {
            blockEnemy.Add(collision.collider.gameObject.GetComponent<Enemys>());
            //Debug.Log(collision.collider.name); // ぶつかった相手の名前を取得
        }
    }
    void OnCollisionStay2D(Collision2D collision)//Enemyが触れている間
    {
      
        if (collision.collider.gameObject.layer == 8 && blockEnemy.Count <max_block  && collision.collider.gameObject.GetComponent<Enemys>().blockCk == true)
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
        
        if (collision.collider.gameObject.layer == 8 && hp > 0)
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
            hpSlider.value = (float)GetHP() / (float)Getmax_hp();
        }
    }

    private IEnumerator ShortDistance()//近接攻撃
    {
        Debug.Log("1dann");
        while (true)
        {



                                            //↓元
            yield return new WaitForSeconds(hand.atkSpeed);//               ↓元wepon.range
            
            var collider = Physics2D.OverlapCircle(transform.position, wepon.range, LayerMask.GetMask("Enemy"));
          
            
            if (collider != null)
            {
                

                if (enemy==null && blockEnemy.Count != 0)
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
                            Debug.Log("減ってないよ");
                            enemy.hp -= (int)(atk * 0.05);
                        }
                        else
                        {
                            Debug.Log("減ったよ");
                            enemy.hp = enemy.hp - (atk - enemy.def);
                        }
                    }

                    if (enemy.hp <= 0)
                    {
                        Debug.Log(enemy.name + "が死んだ");
                        Destroy(enemy.gameObject);
                        FindObjectOfType<Player>().cost += enemy.cost;
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
        Debug.Log(balletPrefab);
        Debug.Log("1da");
        while (true)
        {                                   //↓hand.atkSpeed
            Debug.Log("2da");
            Debug.Log(balletPrefab);
            yield return new WaitForSeconds(hand.atkSpeed);
            Debug.Log(balletPrefab);
            // ここで敵を探して、敵を撃つ
            //                                                         ↓wepon.range
            var collider = Physics2D.OverlapCircle(transform.position, wepon.range, LayerMask.GetMask("Enemy"));
            Debug.Log("3da");
            Debug.Log(balletPrefab);
            if (collider != null)
            {
                Debug.Log("4da");
                //transform.rotation = Quaternion.FromToRotation(Vector3.right, collider.transform.position - transform.position);
                //Debug.Log(transform.rotation);
                Debug.Log(balletPrefab);
                
                                      //↓wepon.ballet
                var arrow = Instantiate(balletPrefab, transform.position, transform.rotation);
                Debug.Log("5da");
                arrow.transform.rotation = Quaternion.FromToRotation(Vector3.right, collider.transform.position - transform.position);
                Debug.Log("6da");
                arrow.targetEnemy = collider.GetComponent<Enemys>();

                
            }
        }
    }

    public void setStatus()
    {

        //ステータス設定
        hp = 1000;// head.hp + body.hp + hand.hp + leg.hp+wepon.hp;
        atk = 100;//head.atk + body.atk + hand.atk + leg.atk + wepon.atk;
        def = 100;// head.def + body.def + hand.def + leg.def + wepon.def;
        mdef = 100;// head.mdef + body.mdef + hand.mdef + leg.mdef + wepon.mdef;
        magic = false;// wepon.magic;
        fry = false;// body.fry;
        cost = 10;// head.cost + body.cost + hand.cost + leg.cost;
        /* //ステータス設定
         hp = head.hp + body.hp + hand.hp + leg.hp + wepon.hp;
         atk = head.atk + body.atk + hand.atk + leg.atk + wepon.atk;
         def = head.def + body.def + hand.def + leg.def + wepon.def;
         mdef = head.mdef + body.mdef + hand.mdef + leg.mdef + wepon.mdef;
         magic = wepon.magic;
         fry = body.fry;
         cost = head.cost + body.cost + hand.cost + leg.cost;
         //HPバー設定
         hpSlider = HPUI.transform.Find("HPBar").GetComponent<Slider>();
         hpSlider.value = 1f;
        */
    }
    public int Getmax_hp()
    {
        return max_hp;
    }
    public int GetHP()
    {
        return hp;
    }
    

}
