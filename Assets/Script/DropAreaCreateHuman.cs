using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropAreaCreateHuman : MonoBehaviour, IDropHandler
{
    public SaveData saveData;
    public string partIconData;
    private string partName;
    public GameObject headIcon;
    public GameObject bodyIcon;
    public GameObject armIcon;
    public GameObject legIcon;
    public GameObject weponIcon;
    public InputField text;
    public void OnDrop(PointerEventData eventData)
    {
        try
        {
            partName = eventData.pointerDrag.transform.parent.gameObject.transform.GetChild(1).gameObject.GetComponent<Drop>().part;
        } catch (Exception e)
        {
            partName = null;
        }

        if (partName == null)
        {
            try
            {

                partName = eventData.pointerDrag.transform.parent.gameObject.transform.GetChild(1).gameObject.GetComponent<CharaScript>().name;
            }
            catch (Exception e)
            {
            }
        }


        if (partName != partIconData)
        {
            return;//パーツが違う時には終了する
        }
        
        Debug.Log(gameObject.name + "に" + eventData.pointerDrag.name + "がドロップされました。");
        //画像を変更
        gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = eventData.pointerDrag.GetComponent<Image>().sprite;

        //ドラッグされたオブジェクトのスクリプトから必要なオブジェクトたちを取得
        Unit unit = saveData.DragObj.GetComponent<Unit>();
        //パネルにあったGameObjectを削除して新しい物を配置
        //削除作業
        try
        {
            Destroy(gameObject.transform.GetChild(1).gameObject);
        } catch
        {

        }

        //頭
        if(headIcon.transform.childCount > 1)
        {
            Destroy(headIcon.transform.GetChild(1).gameObject);
        }

        //体
        if (bodyIcon.transform.childCount > 1)
        {
            Destroy(bodyIcon.transform.GetChild(1).gameObject);
        }

        //腕
        if (armIcon.transform.childCount > 1)
        {
            Destroy(armIcon.transform.GetChild(1).gameObject);
        }

        //足
        if (legIcon.transform.childCount > 1)
        {
            Destroy(legIcon.transform.GetChild(1).gameObject);
        }

        //武器
        if (weponIcon.transform.childCount > 1)
        {
            Destroy(weponIcon.transform.GetChild(1).gameObject);
        }

        //配置作業
        try
        {
            //配置
            GameObject dropObj = (GameObject)PrefabUtility.InstantiatePrefab(saveData.DragObj);
            dropObj.transform.SetParent(gameObject.transform, false);
            dropObj.SetActive(false);
            //頭
            headIcon.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = unit.headObj.GetComponent<SpriteRenderer>().sprite;
            GameObject headObj = (GameObject)PrefabUtility.InstantiatePrefab(unit.headObj);
            headObj.transform.SetParent(headIcon.transform, false);
            headObj.SetActive(false);
            //体
            bodyIcon.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = unit.bodyObj.GetComponent<SpriteRenderer>().sprite;
            GameObject bodyObj = (GameObject)PrefabUtility.InstantiatePrefab(PrefabUtility.GetCorrespondingObjectFromOriginalSource(unit.bodyObj));
            bodyObj.transform.SetParent(bodyIcon.transform, false);
            bodyObj.SetActive(false);
            //腕
            armIcon.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = unit.handObj.GetComponent<SpriteRenderer>().sprite;
            GameObject armObj = (GameObject)PrefabUtility.InstantiatePrefab(PrefabUtility.GetCorrespondingObjectFromOriginalSource(unit.handObj));
            armObj.transform.SetParent(armIcon.transform, false);
            armObj.SetActive(false);
            //足
            legIcon.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = unit.legObj.GetComponent<SpriteRenderer>().sprite;
            GameObject legObj　= (GameObject)PrefabUtility.InstantiatePrefab(PrefabUtility.GetCorrespondingObjectFromOriginalSource(unit.legObj));
            legObj.transform.SetParent(legIcon.transform, false);
            legObj.SetActive(false);
            //武器
            weponIcon.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = unit.weponObj.GetComponent<SpriteRenderer>().sprite;
            GameObject weponObj = (GameObject)PrefabUtility.InstantiatePrefab(PrefabUtility.GetCorrespondingObjectFromOriginalSource(unit.weponObj));
            weponObj.transform.SetParent(weponIcon.transform, false);
            weponObj.SetActive(false);
            //名前
            text.text = unit.charaName;
        } catch (Exception e)
        {
            Debug.Log(e);
        }

    }
}