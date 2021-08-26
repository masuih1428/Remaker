using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BowStatusUI : MonoBehaviour
{
    public Player player;
    public Text lvText;
    public Text unithp; 
    public Text lvUpButtonText;
    public Text sellButtonText;

    void Update()
    {
        if (player.selectUnit == null)
        {
            lvText.text = "LV: - ";
            unithp.text = "HP: - ";
            lvUpButtonText.text = " - GOLD";
            sellButtonText.text = " - GOLD";
        }
        else
        {
            lvText.text = $"LV:{player.selectUnit.lv}";
            unithp.text = $"HP:{player.selectUnit.hp}";
            lvUpButtonText.text = $"{player.selectUnit.cost}GOLD";
            sellButtonText.text = $"{player.selectUnit.Price}GOLD";
        }
    }
}