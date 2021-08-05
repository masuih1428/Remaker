using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropAreas : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log(gameObject.name + "に" + eventData.pointerDrag.name + "がドロップされました。");
        //ドロップする画像をドロップしたい場所の画像にする
        Debug.Log(gameObject.GetComponent<Image>().sprite + "\n" + eventData.pointerDrag.GetComponent<Image>().sprite);
        gameObject.GetComponent<Image>().sprite = eventData.pointerDrag.GetComponent<Image>().sprite;
    }
}