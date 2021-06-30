using UnityEngine;
using UnityEngine.UI;

public class BGMvol : MonoBehaviour
{
    public Slider slider;
    public Text valuetext;

    public float levelvalue;

    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GameObject.Find("GameObject").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audio.volume = slider.value;
        levelvalue = slider.value * 100;
        valuetext.text = levelvalue.ToString("f0");
    }
}
