using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Enemys : CharaScript
{
    public EnemyBallet balletPrefab;
    public Unit unit;
   
  
    
    //public int hp;
 
    //public int atk;

    //public float atkspeed;
    public float range;
    public float AtkRange => range + 1 * 0.5f;
    public float AtkInterval => 1.0f * Mathf.Pow(atkspeed, 1);

    public float speed;
    

    public bool blockCk;
    public int grade;
    public int id;
    public bool stealth = false;//�X�e���X���ǂ���
    public int attribute = 0;//�L�����̑��� 0���� 1���� 2���� 3����
    public float move = 1; //�ړ����x
    public float dps = 1; //�U�����x(dps���Z�j
    public SaveData savedata;

    public List<GameObject> dropList;

    public Route route;//���[�g���߂���
    private int pointIndex;//�ǉ������Q��

    [SerializeField]
    private GameObject HPUI;//HP�o�[
    private Slider hpSlider;
    //
    public string blockname;

    void Start()
    {
        hp = max_hp;
        //Debug.Log("HP:" + hp + "max:" + max_hp);
        hpSlider = HPUI.transform.Find("HPBar").GetComponent<Slider>();
        hpSlider.value = 1f;
        StartCoroutine("EnemyHP");

        if (balletPrefab != null)
        {
            balletPrefab.SetAtk(atk);
            StartCoroutine(SearchAndShot());
        }
        
        
            
        

        blockCk = true;
        //
        blockname = null;
        transform.position = route.points[0].transform.position;
        StartCoroutine("AttackUnit");


        //�R���X�g���N�^
        //this.hp = (int)(this.max_hp * savedata.dificult);
        //this.atk = (int)(this.max_atk * savedata.dificult);
        //this.def = (int)(this.max_def * savedata.dificult);
        // this.mdef = (int)(this.max_mdef * savedata.dificult);
    }
    /*void Update()//�ǉ�������
    {
        var v = route.points[pointIndex + 1].transform.position - route.points[pointIndex].transform.position;
        transform.position += v.normalized * move * Time.deltaTime;

        var pv = transform.position - route.points[pointIndex].transform.position;
        if (pv.magnitude >= v.magnitude)
        {
            pointIndex++;

            if (pointIndex >= route.points.Length - 1)//�Ō�܂œ��B����
            {
                Destroy(gameObject);
                //TODO �v���C���[�Ƀ_���[�W
            }
        }
    }*/
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
                pointIndex++; //����Point��
            }

            if (pointIndex >= route.points.Length - 1)
            {
                Destroy(gameObject);
                //�v���C���[�փ_���[�W
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
                    pointIndex++; //����Point��
                }

                if (pointIndex >= route.points.Length - 1)
                {
                    Destroy(gameObject);
                    //�v���C���[�փ_���[�W
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
            UpdateHPValue();

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
                Debug.Log(AtkRange);
                Debug.Log(transform.position);
                Debug.Log(LayerMask.GetMask("Unit"));
                collider = Physics2D.OverlapCircle(transform.position, AtkRange, LayerMask.GetMask("Unit"));
                Debug.Log(collider);
                //Debug.Log(collider);
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

    void OnCollisionEnter2D(Collision2D collision)//unit�ɂӂꂽ�Ƃ�
    {

        if (collision.collider.gameObject.layer == 10 && unit == null && blockname==null)//���C���[10=Unit
        {
            blockname = collision.collider.gameObject.name;
            unit = collision.collider.gameObject.GetComponent<Unit>();
            if (balletPrefab != null)
            {
                StopCoroutine("AttackUnit");

            }

            //Debug.Log(unit.name); // �Ԃ���������̖��O���擾


        }
    }
    void OnCollisionStay2D(Collision2D collision)//unit�ɐG��Ă����
    {
  
        if (collision.collider.gameObject.layer == 10 && blockname== collision.collider.gameObject.name)
        {
            if (balletPrefab != null)
            {

                StopCoroutine("AttackUnit");
            }

            foreach (Enemys enemy in unit.blockEnemy)
            {
              
                if (enemy.id == id)
                {
                    blockCk = false;
                    break;
                }
                
            }
        }

    }

    void OnCollisionExit2D(Collision2D collision)//unit���痣�ꂽ�Ƃ�
    {
        if (collision.collider.gameObject.layer == 10)
        {
            blockname = null;
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
        return this.max_hp;
    }
    public void UpdateHPValue()
    {
        hpSlider.value = (float)GetHP() / (float)GetMAXHP();
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
