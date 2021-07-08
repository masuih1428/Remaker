using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour
{
    SavedataObject savedata = new SavedataObject();
    // Start is called before the first frame update
    void Start()
    {
        DataBank bank = DataBank.Open();
        SavedataObject savedata1 = new SavedataObject();
        Debug.Log(savedata1.dificult);
        savedata1 = bank.Get<SavedataObject>("Sample");
        if (bank.ExistsKey("Sample"))
        {
            Debug.Log("‚ ‚è‚Ü‚·");
        } else
        {
            Debug.Log("‚ ‚è‚Ü‚¹‚ñ");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
