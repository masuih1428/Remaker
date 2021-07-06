using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charaMake : MonoBehaviour
{
    public List<GameObject> drops;//1番目から頭、体、足、手、武器の順で格納されている
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeChara()//生成ボタンが押された時の処理
    {
        List<GameObject> dropLists = new List<GameObject>();
        for (int i = 0; i < drops.Count; i++)
        {
            GameObject droplist = drops[i].transform.GetChild(0).gameObject;
            dropLists.Add(droplist);
        }

    }
}
