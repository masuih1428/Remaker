using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Seisei : MonoBehaviour
{
    public GameObject headObj;
    public GameObject bodyObj;
    public GameObject legObj;
    public GameObject armObj;
    public GameObject wepon;
    public GameObject nameObj;
    public GameObject UnitModel;
    public SaveData saveData;
    private string assetPath = "Assets/Resources/味方キャラ/";
    public void OnClick()
    {
        //Unit unitScript = UnitModel.GetComponent<Unit>();
        GameObject unit;
        //try
        //{
            //オブジェクトの生成
            unit = Instantiate(UnitModel);
            Unit unitScript = unit.GetComponent<Unit>();
            //head
            unitScript.head = PrefabUtility.GetCorrespondingObjectFromOriginalSource(headObj.transform.GetChild(1).gameObject).GetComponent<HeadDrop>();
            //body
            unitScript.body = PrefabUtility.GetCorrespondingObjectFromOriginalSource(bodyObj.transform.GetChild(1).gameObject).GetComponent<BodyDrop>();
            //Debug.Log(bodyObj.transform.GetChild(1).gameObject.GetComponent<BodyDrop>());
            //leg
            unitScript.leg = PrefabUtility.GetCorrespondingObjectFromOriginalSource(legObj.transform.GetChild(1).gameObject).GetComponent<LegDrop>();
            //Debug.Log(legObj.transform.GetChild(1).gameObject.GetComponent<LegDrop>());
            //arm
            unitScript.hand = PrefabUtility.GetCorrespondingObjectFromOriginalSource(armObj.transform.GetChild(1).gameObject).GetComponent<HandDrop>();
            //Debug.Log(armObj.transform.GetChild(1).gameObject.GetComponent<HandDrop>());

            //weponがアクティブの場合のみ
            if (wepon.activeSelf)
            {
                //wepon
                unitScript.wepon = PrefabUtility.GetCorrespondingObjectFromOriginalSource(wepon.transform.GetChild(1).gameObject).GetComponent<Wepon>();
                Debug.Log(headObj.transform.GetChild(1).gameObject.GetComponent<Wepon>());
            }

            if (nameObj.transform.GetChild(2).gameObject.GetComponent<Text>().text == null)
            {
                throw new Exception();//名前未入力の為
            }　else
            {
                unitScript.charaName = nameObj.transform.GetChild(2).gameObject.GetComponent<Text>().text;
            }
            Debug.Log("取得完了");
            unitScript.Start();
            GameObject unitPrefab = PrefabUtility.SaveAsPrefabAsset(unit, assetPath + unitScript.charaName + saveData.humanList.Count +".prefab");
            saveData.humanList.Add(unitPrefab);
            Destroy(unit);

        //} catch (Exception e)
        //{
        //Debug.Log("入力してない欄あり");
        //}
    }
}
