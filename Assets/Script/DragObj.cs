using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
 
public class DragObj : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Vector2 prevPos;
    public SaveData saveData;
    public GameObject prevObj;
    private GameObject cloneObj;
    public void OnBeginDrag(PointerEventData eventData)
    {
        //�ړ�����Q�[���I�u�W�F�N�g�𕡐�
        cloneObj = Instantiate(gameObject);
        Debug.Log(gameObject.transform.parent);
        cloneObj.transform.SetParent(gameObject.transform.parent.gameObject.transform, false);
        //���̈ʒu�ɂ���摜���O���[��
        cloneObj.GetComponent<Image>().color = Color.gray;
        // �h���b�O�O�̈ʒu���L�����Ă���
        prevPos = transform.position;
        //�h���b�O����I�u�W�F�N�g���L��
        saveData.DragObj = (GameObject)PrefabUtility.GetCorrespondingObjectFromOriginalSource
            (gameObject.transform.parent.gameObject.transform.GetChild(1).gameObject);
        Debug.Log(saveData.DragObj);
        

    }

    public void OnDrag(PointerEventData eventData)
    {
        // �h���b�O���͈ʒu���X�V����
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // �h���b�O�O�̈ʒu�ɖ߂�
        transform.position = prevPos;
        Destroy(cloneObj);
    }

}