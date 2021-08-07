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
            return;//�p�[�c���Ⴄ���ɂ͏I������
        }
        
        Debug.Log(gameObject.name + "��" + eventData.pointerDrag.name + "���h���b�v����܂����B");
        //�摜��ύX
        gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = eventData.pointerDrag.GetComponent<Image>().sprite;
        //�p�l���ɂ�����GameObject���폜���ĐV��������z�u
        //�폜���
        try
        {
            Destroy(gameObject.transform.GetChild(1).gameObject);
        } catch
        {

        }

        //�z�u���
        try
        {
            //�z�u
            GameObject dropObj = (GameObject)PrefabUtility.InstantiatePrefab(saveData.DragObj);
            dropObj.transform.SetParent(gameObject.transform, false);
            dropObj.SetActive(false);
        } catch (Exception e)
        {
            Debug.Log(e.Data);
        }

    }
}