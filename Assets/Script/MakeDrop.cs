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
    //�h���b�v�̐���
    void makeDrops()
    {
        //������������߂�
        int dropCount = Random.Range(0, 8);
        Debug.Log(dropCount);
        //�h���b�v�̐���
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
            
            //�I�u�W�F�N�g�̕ۑ��Ȃ�
            GameObject dropInstant = GameObject.Instantiate(drop);
            drop.GetComponent<Drop>().rareStart();
            Debug.Log(drop.GetComponent<Drop>().rare);
            dropList.Add(dropInstant);
            dropInstant.SetActive(false);
            PrefabUtility.SaveAsPrefabAssetAndConnect(dropInstant, "Assets/Resources/�h���b�v���/" + drop.GetComponent<Drop>().partName + (saveData.dropInt++) + ".prefab",InteractionMode.AutomatedAction);
            saveData.drops.Add(PrefabUtility.GetCorrespondingObjectFromOriginalSource(dropInstant));
            Debug.Log(drop);
        }
    }
}
