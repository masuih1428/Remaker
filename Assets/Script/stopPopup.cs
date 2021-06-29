using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopPopup : MonoBehaviour
{
    [SerializeField]
    public GameObject stopPopup1;
    // Start is called before the first frame update
    void Start()
    {
        stopPopup1.SetActive(false);
    }

}
