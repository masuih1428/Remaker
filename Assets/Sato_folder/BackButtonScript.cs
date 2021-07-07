using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButtonScript : MonoBehaviour
{
    public void OnClickBackButton()
    {
        SceneManager.LoadScene("生成・素材・付替メニュー");
    }
}