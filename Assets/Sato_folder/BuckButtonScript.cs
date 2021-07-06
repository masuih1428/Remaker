using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuckButtonScript : MonoBehaviour
{
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("生成・素材・付替メニュー");
    }
}