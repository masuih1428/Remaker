using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatView : MonoBehaviour
    
{
    public Unit unit;
    private string Status;

    // Start is called before the first frame update
   public void stat()
    {
        Debug.Log("ugoita");
        Text t = GameObject.Find("Unitst").transform.Find("Text").GetComponent<Text>();
        t.text = unit.ToString();
    }
    // Update is called once per frame

}
