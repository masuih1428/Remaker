using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player :MonoBehaviour
{

    //�|Prefab
    public Unit unitPrefab;

    //HP(���_�̗̑�)
    public int hp;

    //GOLD(������)
    public int cost;

    //�I�𒆂̋|
    public Unit selectUnit;

    public SaveData savedata;

    public StatView s;

    public GameObject uni;

    private List<GameObject> party;
    /*
    
    private Sprite sprites;

   
    private Sprite sprite;

    public void imageview()
    {
        GameObject[] ima = { image0, image1, image2, image3, image4, image5, image6, image7 };
        switch (savedata.BattleParty)
        {
            case 1:
                party = savedata.humanParty1;
                
                for (int i = 0; i<= 7; i++)
                {
                   
                }
                break;
            case 2:

                break;
            case 3:

                break;
        }
    

    }
    */
    //�|�̌��݂��o����
    public void CreateUnit(Transform t)
    {
        
            if (cost < unitPrefab.cost) return;
            cost -= unitPrefab.cost;
            selectUnit = Instantiate(unitPrefab, t);
            selectUnit.transform.localPosition = Vector3.zero;
            
        
        
    }

    //�I�𒆂̋|�̃��x���A�b�v���o����
    /*public void LevelUpUnit()
    {
        if (selectUnit == null) return;  //�����I������Ă��Ȃ�
        if (cost < selectUnit.cost) return; //������������Ȃ�
        cost -= selectUnit.cost;
        selectUnit.lv++;
        //�|�̃��x���A�b�v������
    }*/

    //�I�𒆂̋|�̔��p���o����
    public void SellUnit()
    {
        if (selectUnit == null) return;
        cost += selectUnit.Price;
        Destroy(selectUnit.gameObject);
        selectUnit = null;
        

    }

    /*public void SetUnit(Unit unit)
    {
        unitPrefab = unit;
    }*/
    public void SetUnit(int number)
    {
        
        
        
        
        switch (savedata.BattleParty)
        {
            case 1:

                party = savedata.humanParty1;
                uni = party[number];
                unitPrefab = uni.GetComponent<Unit>();
                
                s.stat(unitPrefab);
                break;
            case 2:
               
                party = savedata.humanParty2;
                uni = party[number];
                unitPrefab = uni.GetComponent<Unit>();
                
                s.stat(unitPrefab);
                break;
            case 3:
                party = savedata.humanParty3;
                uni = party[number];
                unitPrefab = uni.GetComponent<Unit>();
                
                s.stat(unitPrefab);
                break;
        }

       

        
    }
    
    

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var col = Physics2D.OverlapPoint(mousePos, LayerMask.GetMask("Block"));
            if (col == null) return;
            var childUnit = col.GetComponentInChildren<Unit>();
            if (childUnit == null)
            {
                if (unitPrefab == null) return;
                CreateUnit(col.transform);
            }
            else
            {
                selectUnit = childUnit;
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            unitPrefab = null;
            selectUnit = null;
        }
    }
   
   
}