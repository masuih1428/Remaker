using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatView :MonoBehaviour
    
{
    public Text text;
    private string Status;

    // Start is called before the first frame update
   public void stat(Unit unit)
    {
        
        text.text= "name:\n" + unit.charaName + "\nhp:" + unit.hp + "\natk:" + unit.atk +
            "\ndef:" + unit.def + "\nmdef:" + unit.mdef;
        
    }

   
    // Update is called once per frame

}
