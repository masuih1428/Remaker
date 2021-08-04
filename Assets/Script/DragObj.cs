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
        //移動するゲームオブジェクトを複製
        cloneObj = Instantiate(gameObject);
        Debug.Log(gameObject.transform.parent);
        cloneObj.transform.SetParent(gameObject.transform.parent.gameObject.transform, false);
        //元の位置にある画像をグレー化
        cloneObj.GetComponent<Image>().color = Color.gray;
        // ドラッグ前の位置を記憶しておく
        prevPos = transform.position;
        //ドラッグするオブジェクトを記憶
        saveData.DragObj = (GameObject)PrefabUtility.GetCorrespondingObjectFromOriginalSource
            (gameObject.transform.parent.gameObject.transform.GetChild(1).gameObject);
        Debug.Log(saveData.DragObj);
        

    }

    public void OnDrag(PointerEventData eventData)
    {
        // ドラッグ中は位置を更新する
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // ドラッグ前の位置に戻す
        transform.position = prevPos;
        Destroy(cloneObj);
    }

}