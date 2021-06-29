using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
	// Start is called before the first frame update
	[SerializeField]
	UnityEngine.Audio.AudioMixer mixer;

	public float masterVolume
	{
		set { mixer.SetFloat("Mastervolune", Mathf.Lerp(-80, 0, value)); }
	}
}
