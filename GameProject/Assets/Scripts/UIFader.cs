using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFader : MonoBehaviour {

	public CanvasGroup uiElement;

	public void FadeIn()
	{
		StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 1));
		uiElement.interactable = true;
		uiElement.blocksRaycasts = true;
	}

	public void FadeOut()
	{
		uiElement.interactable = false;
		uiElement.blocksRaycasts = false;
		StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 0));
	}

	public IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float lerpTime = 0.5f)
	{
		float _timeStartedLerping = Time.time;
		float timeSinceStarted = Time.time - _timeStartedLerping;
		float percentageComplete = timeSinceStarted / lerpTime;
		Vector3 tempPos;

		while (true)
		{
			timeSinceStarted = Time.time - _timeStartedLerping;
			percentageComplete = timeSinceStarted / lerpTime;
			tempPos = transform.position;

			float currentValue = Mathf.Lerp(start, end, percentageComplete);
			if(end > 0)
			{
				tempPos.z -= 0.01f;
			}
			else
			{
				tempPos.z += 0.01f;
			}

			cg.alpha = currentValue;
			transform.position = tempPos;

			if(percentageComplete >= 1) break;

			yield return new WaitForEndOfFrame();
		}

		print("done");
	}
}
