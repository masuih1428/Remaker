using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotRange : MonoBehaviour
{
    public Player player;
    public SpriteRenderer rangeRenderer;

    // Update is called once per frame
    void Update()
    {
        if (player.selectUnit == null)
        {
            rangeRenderer.enabled = false;
        }
        else
        {
            rangeRenderer.enabled = true;
            rangeRenderer.transform.localScale = new Vector3(2, 2) * player.selectUnit.ShotRange;
            rangeRenderer.transform.position = player.selectUnit.transform.position;
        }
    }
}