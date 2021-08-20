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
        Debug.Log(gameObject.name + "��" + eventData.pointerDrag.name + "���h���b�v����܂����B");
        //�摜��ύX
        gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = eventData.pointerDrag.GetComponent<Image>().sprite;
        //�p�l���ɂ�����GameObject���폜���ĐV��������z�u
        try
        {
            Destroy(gameObject.transform.GetChild(1).gameObject); //�폜
            //�z�u
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