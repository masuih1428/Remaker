using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charaMake : MonoBehaviour
{
    public List<GameObject> drops;//1�Ԗڂ��瓪�A�́A���A��A����̏��Ŋi�[����Ă���
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeChara()//�����{�^���������ꂽ���̏���
    {
        List<GameObject> dropLists = new List<GameObject>();
        for (int i = 0; i < drops.Count; i++)
        {
            GameObject droplist = drops[i].transform.GetChild(0).gameObject;
            dropLists.Add(droplist);
        }

    }
}
