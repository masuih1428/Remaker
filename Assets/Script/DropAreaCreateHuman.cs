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
            return;//�p�[�c���Ⴄ���ɂ͏I������
        }
        
        Debug.Log(gameObject.name + "��" + eventData.pointerDrag.name + "���h���b�v����܂����B");
        //�摜��ύX
        gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = eventData.pointerDrag.GetComponent<Image>().sprite;

        //�h���b�O���ꂽ�I�u�W�F�N�g�̃X�N���v�g����K�v�ȃI�u�W�F�N�g�������擾
        Unit unit = saveData.DragObj.GetComponent<Unit>();
        //�p�l���ɂ�����GameObject���폜���ĐV��������z�u
        //�폜���
        try
        {
            Destroy(gameObject.transform.GetChild(1).gameObject);
        } catch
        {

        }

        //��
        if(headIcon.transform.childCount > 1)
        {
            Destroy(headIcon.transform.GetChild(1).gameObject);
        }

        //��
        if (bodyIcon.transform.childCount > 1)
        {
            Destroy(bodyIcon.transform.GetChild(1).gameObject);
        }

        //�r
        if (armIcon.transform.childCount > 1)
        {
            Destroy(armIcon.transform.GetChild(1).gameObject);
        }

        //��
        if (legIcon.transform.childCount > 1)
        {
            Destroy(legIcon.transform.GetChild(1).gameObject);
        }

        //����
        if (weponIcon.transform.childCount > 1)
        {
            Destroy(weponIcon.transform.GetChild(1).gameObject);
        }

        //�z�u���
        try
        {
            //�z�u
            GameObject dropObj = (GameObject)PrefabUtility.InstantiatePrefab(saveData.DragObj);
            dropObj.transform.SetParent(gameObject.transform, false);
            dropObj.SetActive(false);
            //��
            headIcon.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = unit.headObj.GetComponent<SpriteRenderer>().sprite;
            GameObject headObj = (GameObject)PrefabUtility.InstantiatePrefab(unit.headObj);
            headObj.transform.SetParent(headIcon.transform, false);
            headObj.SetActive(false);
            //��
            bodyIcon.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = unit.bodyObj.GetComponent<SpriteRenderer>().sprite;
            GameObject bodyObj = (GameObject)PrefabUtility.InstantiatePrefab(PrefabUtility.GetCorrespondingObjectFromOriginalSource(unit.bodyObj));
            bodyObj.transform.SetParent(bodyIcon.transform, false);
            bodyObj.SetActive(false);
            //�r
            armIcon.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = unit.handObj.GetComponent<SpriteRenderer>().sprite;
            GameObject armObj = (GameObject)PrefabUtility.InstantiatePrefab(PrefabUtility.GetCorrespondingObjectFromOriginalSource(unit.handObj));
            armObj.transform.SetParent(armIcon.transform, false);
            armObj.SetActive(false);
            //��
            legIcon.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = unit.legObj.GetComponent<SpriteRenderer>().sprite;
            GameObject legObj�@= (GameObject)PrefabUtility.InstantiatePrefab(PrefabUtility.GetCorrespondingObjectFromOriginalSource(unit.legObj));
            legObj.transform.SetParent(legIcon.transform, false);
            legObj.SetActive(false);
            //����
            weponIcon.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = unit.weponObj.GetComponent<SpriteRenderer>().sprite;
            GameObject weponObj = (GameObject)PrefabUtility.InstantiatePrefab(PrefabUtility.GetCorrespondingObjectFromOriginalSource(unit.weponObj));
            weponObj.transform.SetParent(weponIcon.transform, false);
            weponObj.SetActive(false);
            //���O
            text.text = unit.charaName;
        } catch (Exception e)
        {
            Debug.Log(e);
        }

    }
}