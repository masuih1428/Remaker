using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MakeDrop : MonoBehaviour
{
    public List<GameObject> dropEnemys;
    public SaveData saveData;
    public List<GameObject> dropList;

    private void Start()
    {
        makeDrops();
    }
    //ドロップの生成
    void makeDrops()
    {
        //落ちる個数を決める
        int dropCount = Random.Range(0, 8);
        Debug.Log(dropCount);
        //ドロップの生成
        for (int i = 0; i < dropCount; i++)
        {
            int dropListCount = Random.Range(0, dropList.Count);
            Enemys enemy = dropEnemys[dropListCount].GetComponent<Enemys>();
            GameObject drop;
            if (i < 2)
            {
                drop = enemy.dropList[Random.Range(0, 4)];
            } else
            {
                drop = enemy.dropList[Random.Range(0, enemy.dropList.Count)];
            }
            
            //オブジェクトの保存など
            GameObject dropInstant = GameObject.Instantiate(drop);
            drop.GetComponent<Drop>().rareStart();
            Debug.Log(drop.GetComponent<Drop>().rare);
            dropList.Add(dropInstant);
            dropInstant.SetActive(false);
            PrefabUtility.SaveAsPrefabAssetAndConnect(dropInstant, "Assets/Resources/ドロップ情報/" + drop.GetComponent<Drop>().partName + (saveData.dropInt++) + ".prefab",InteractionMode.AutomatedAction);
            saveData.drops.Add(PrefabUtility.GetCorrespondingObjectFromOriginalSource(dropInstant));
            Debug.Log(drop);
        }
    }
}
