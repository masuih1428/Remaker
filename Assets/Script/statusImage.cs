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

}
