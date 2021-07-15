using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelControl : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> drops = new List<GameObject>();
    public GameObject content;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < drops.Count; i++)
        {
            GameObject panelObj = (GameObject)Instantiate(panel);
            panelObj.transform.SetParent(content.transform, false);
            //panelObj.transform.parent = content.transform;
            GameObject dropObj = (GameObject)Instantiate(drops[i],panelObj.transform);
            dropObj.transform.parent.SetParent(panelObj.transform, false);
            //dropObj.GetComponent<RectTransform>().SetAsLastSibling();
            //dropObj.transform.parent = panelObj.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
