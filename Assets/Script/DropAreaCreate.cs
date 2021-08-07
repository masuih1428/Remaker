using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropAreaCreate : MonoBehaviour, IDropHandler
{
    public SaveData saveData;
    public string partIconData;
    private string partName;
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

                partName = eventData.pointerDrag.transform.parent.gameObject.transform.GetChild(1).gameObject.GetComponent<CharaScript>().charaName;
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
        //パネルにあったGameObjectを削除して新しい物を配置
        //削除作業
        try
        {
            Destroy(gameObject.transform.GetChild(1).gameObject);
        } catch
        {

        }

        //配置作業
        try
        {
            //配置
            GameObject dropObj = (GameObject)PrefabUtility.InstantiatePrefab(saveData.DragObj);
            dropObj.transform.SetParent(gameObject.transform, false);
            dropObj.SetActive(false);
        } catch (Exception e)
        {
            Debug.Log(e.Data);
        }

    }
}