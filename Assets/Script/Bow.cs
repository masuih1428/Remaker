using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Bow : Unit
{
    [SerializeField]
    //private GameObject HPUI;
    //private Slider hpSlider;

    public Arrow arrowPrefab;

    void Start()
    {
        this.hp = GetMAX_HP();

        ///hpSlider = HPUI.transform.Find("HPBar").GetComponent<Slider>();
        //hpSlider.value = 1f;
        StartCoroutine("UnitHP");

        arrowPrefab.SetAtk(atk);
        StartCoroutine(SearchAndShot());
    }

    private IEnumerator SearchAndShot()
    {
        while (true)
        {
            yield return new WaitForSeconds(ShotInterval);
            // Ç±Ç±Ç≈ìGÇíTÇµÇƒÅAñÓÇåÇÇ¬
            var collider = Physics2D.OverlapCircle(transform.position, ShotRange, LayerMask.GetMask("Enemy"));
            if (collider != null)
            {
                //transform.rotation = Quaternion.FromToRotation(Vector3.right, collider.transform.position - transform.position);
                var arrow = Instantiate(arrowPrefab, transform.position, transform.rotation);
                arrow.transform.rotation = Quaternion.FromToRotation(Vector3.right, collider.transform.position - transform.position);
                arrow.targetEnemy = collider.GetComponent<Enemy>();
            }
        }
    }

    public void UpdateHPValue()
    {
       // hpSlider.value = (float)GetHP() / (float)GetMAX_HP();
    }

    private IEnumerator UnitHP()
    {
        while (true)
        {
            yield return null;
            UpdateHPValue();
        }
    }
}
