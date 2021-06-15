using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSoundScript : MonoBehaviour
{
    public AudioClip audioClip3;
    private AudioSource audioSource;
    public bool dontDestroyEnabled = true;
    static int count = 0;
    void Start()
    {
        if (count == 0)
        {

            audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.clip = audioClip3;
            audioSource.Play();
            count = 1;
            if (dontDestroyEnabled)
            {
                DontDestroyOnLoad(this);
            }
        }
        
    }

}