using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeInScript : MonoBehaviour
{

	//�@�t�F�[�h�C���̂����悻�̕b��
	[SerializeField]
	private float fadeInTime;
	//�@�w�iImage
	private Image image;

	void Start()
	{
		image = transform.Find("Panel").GetComponent<Image>();
		//�@�R���[�`���Ŏg�p����҂����Ԃ��v��
		fadeInTime = 1f * fadeInTime / 10f;
		StartCoroutine("FadeIn");
	}

	IEnumerator FadeIn()
	{

		//�@Color�̃A���t�@��0.1�������Ă���
		for (var i = 1f; i >= 0; i -= 0.1f)
		{
			image.color = new Color(0f, 0f, 0f, i);
			//�@�w��b���҂�
			yield return new WaitForSeconds(fadeInTime);
		}
	}
}