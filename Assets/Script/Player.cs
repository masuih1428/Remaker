using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //弓Prefab
    public Unit unitPrefab;

    //HP(拠点の体力)
    public int hp;

    //GOLD(所持金)
    public int cost;

    //選択中の弓
    public Unit selectUnit;

   

    //弓の建設が出来る
    public void CreateUnit(Transform t)
    {
        if (cost < 100) return;
        cost -= 100;
        selectUnit = Instantiate(unitPrefab, t);
        selectUnit.transform.localPosition = Vector3.zero;
    }

    //選択中の弓のレベルアップが出来る
    public void LevelUpUnit()
    {
        if (selectUnit == null) return;  //何も選択されていない
        if (cost < selectUnit.cost) return; //所持金が足りない
        cost -= selectUnit.cost;
        selectUnit.lv++;
        //弓のレベルアップをする
    }

    //選択中の弓の売却が出来る
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