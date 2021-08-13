using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class DropArea : MonoBehaviour, IDropHandler
{
    public SaveData saveData;
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(gameObject.name + "に" + eventData.pointerDrag.name + "がドロップされました。");
        //画像を変更
        gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = eventData.pointerDrag.GetComponent<Image>().sprite;
        //パネルにあったGameObjectを削除して新しい物を配置
        try
        {
            Destroy(gameObject.transform.GetChild(1).gameObject); //削除
            //配置
            GameObject dropObj = (GameObject)PrefabUtility.InstantiatePrefab(saveData.DragObj);
            dropObj.transform.SetParent(gameObject.transform, false);
        }
        catch (Exception e)
        {
            GameObject dropObj = (GameObject)PrefabUtility.InstantiatePrefab(saveData.DragObj);
            dropObj.transform.SetParent(gameObject.transform, false);
        }
    }





}