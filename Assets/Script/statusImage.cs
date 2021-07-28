using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusImage : MonoBehaviour
{
    public GameObject prefbImage;
    public GameObject image;
    public GameObject panel;
    private GameObject clickedGameObject;
    // Start is called before the first frame update
    void Start()
    {
        //イメージを透明にする
        image.GetComponent<Image>().SetOpacity(0.0f);
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickedGameObject = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
            Debug.Log(hit2d);
            clickedGameObject = hit2d.transform.gameObject;
            Debug.Log(clickedGameObject);
            bool i = hit2d.transform.gameObject == panel;
            Debug.Log(i);

            if(hit2d && hit2d.transform.gameObject == panel)
            {
                image.GetComponent<Image>().sprite = prefbImage.GetComponent<Image>().sprite;
                image.GetComponent<Image>().SetOpacity(1.0f);
            }
 
        }
        image.GetComponent<Image>().sprite = prefbImage.GetComponent<Image>().sprite;
        //画像を不透明にシテ表示
        
    }
}
