using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Seisei : MonoBehaviour
{
    public GameObject headObj;//シーンから取得してきたオブジェクトを入れる変数
    public GameObject bodyObj;
    public GameObject legObj;
    public GameObject armObj;
    public GameObject wepon;
    public GameObject nameObj;
    public GameObject UnitModel;//ユニットの元プレハブ
    public SaveData saveData;
    private string assetPath = "Assets/Resources/味方キャラ/";
    private GameObject headOri;//prefabを入れる変数
    private GameObject bodyOri;
    private GameObject legOri;
    private GameObject armOri;
    private GameObject weponOri;
    private Unit unitScript;
    private GameObject unit;
    public void OnClick()
    {
        //Unit unitScript = UnitModel.GetComponent<Unit>();

        try
        {
            //オブジェクトの生成
            unit = Instantiate(UnitModel);
            unitScript = unit.GetComponent<Unit>();
            //head
            headOri = PrefabUtility.GetCorrespondingObjectFromOriginalSource(headObj.transform.GetChild(1).gameObject);
            unitScript.head = headOri.GetComponent<HeadDrop>();
            //body
            bodyOri = PrefabUtility.GetCorrespondingObjectFromOriginalSource(bodyObj.transform.GetChild(1).gameObject);
            unitScript.body = bodyOri.GetComponent<BodyDrop>();
            //Debug.Log(bodyObj.transform.GetChild(1).gameObject.GetComponent<BodyDrop>());
            //leg
            legOri = PrefabUtility.GetCorrespondingObjectFromOriginalSource(legObj.transform.GetChild(1).gameObject);
            unitScript.leg = legOri.GetComponent<LegDrop>();
            //Debug.Log(legObj.transform.GetChild(1).gameObject.GetComponent<LegDrop>());
            //arm
            armOri = PrefabUtility.GetCorrespondingObjectFromOriginalSource(armObj.transform.GetChild(1).gameObject);
            unitScript.hand = armOri.GetComponent<HandDrop>();
            //Debug.Log(armObj.transform.GetChild(1).gameObject.GetComponent<HandDrop>());

            //weponがアクティブの場合のみ
            if (wepon.activeSelf)
            {
                //wepon
                weponOri = PrefabUtility.GetCorrespondingObjectFromOriginalSource(wepon.transform.GetChild(1).gameObject);
                unitScript.wepon = weponOri.GetComponent<Wepon>();
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

        } catch (Exception e)
        {
            Debug.Log("入力してない欄あり");
        }

        try
        {
            unitScript.Start();
            GameObject unitPrefab = PrefabUtility.SaveAsPrefabAsset(unit, assetPath + unitScript.charaName + saveData.HumanInt + ".prefab");
            saveData.humanList.Add(unitPrefab);
            //dropListから使用した素材を消去
            saveData.drops.Remove(headOri);
            saveData.drops.Remove(bodyOri);
            saveData.drops.Remove(legOri);
            saveData.drops.Remove(armOri);
            if (wepon.activeSelf)
            {
                saveData.drops.Remove(weponOri);
            }

            //リロード
            // 現在のSceneを取得
            Scene loadScene = SceneManager.GetActiveScene();
            // 現在のシーンを再読み込みする
            SceneManager.LoadScene(loadScene.name);
        } catch(Exception e)
        {
            Debug.Log(e);
        }

        Destroy(unit);
    }
}
