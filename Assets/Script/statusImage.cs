using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusImage : MonoBehaviour
{
    public GameObject prefbImage;
    public GameObject image;
    public GameObject panel;
    public Sprite spriteImage;
    // Start is called before the first frame update
    void Start()
    {
        prefbImage.GetComponent<Image>().sprite = spriteImage;
    }

    // Update is called once per frame
    public void Update()
    {
        image.GetComponent<Image>().sprite = prefbImage.GetComponent<Image>().sprite;  
    }
}
