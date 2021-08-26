using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropAreas : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log(gameObject.name + "��" + eventData.pointerDrag.name + "���h���b�v����܂����B");
        //�h���b�v����摜���h���b�v�������ꏊ�̉摜�ɂ���
        Debug.Log(gameObject.GetComponent<Image>().sprite + "\n" + eventData.pointerDrag.GetComponent<Image>().sprite);
        gameObject.GetComponent<Image>().sprite = eventData.pointerDrag.GetComponent<Image>().sprite;
    }
}