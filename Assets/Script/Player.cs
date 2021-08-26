using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //�|Prefab
    public Unit unitPrefab;

    //HP(���_�̗̑�)
    public int hp;

    //GOLD(������)
    public int cost;

    //�I�𒆂̋|
    public Unit selectUnit;

   

    //�|�̌��݂��o����
    public void CreateUnit(Transform t)
    {
        if (cost < 100) return;
        cost -= 100;
        selectUnit = Instantiate(unitPrefab, t);
        selectUnit.transform.localPosition = Vector3.zero;
    }

    //�I�𒆂̋|�̃��x���A�b�v���o����
    public void LevelUpUnit()
    {
        if (selectUnit == null) return;  //�����I������Ă��Ȃ�
        if (cost < selectUnit.cost) return; //������������Ȃ�
        cost -= selectUnit.cost;
        selectUnit.lv++;
        //�|�̃��x���A�b�v������
    }

    //�I�𒆂̋|�̔��p���o����
    public void SellUnit()
    {
        if (selectUnit == null) return;
        cost += selectUnit.Price;
        Destroy(selectUnit.gameObject);
        selectUnit= null;
    }

    public void SetUnit(Unit unit)
    {
        unitPrefab = unit;
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