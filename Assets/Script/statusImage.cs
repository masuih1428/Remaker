using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class statusImage : MonoBehaviour
{
    public GameObject prefbImage;
    public GameObject image;
    // Start is called before the first frame update
    void Start()
    {
        //�C���[�W�𓧖��ɂ���
        image.GetComponent<Image>().SetOpacity(0.0f);
    }

    // Update is called once per frame
    public void Update()
    {
        //if (image.GetComponent<Image>().sprite == )
        //{
          //  image.GetComponent<Image>().SetOpacity(1.0f);
        //}
        //image.GetComponent<Image>().sprite = prefbImage.GetComponent<Image>().sprite;
        //�摜��s�����ɃV�e�\��
        
    }
}
