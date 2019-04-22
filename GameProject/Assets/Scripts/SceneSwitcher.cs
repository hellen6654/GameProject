using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void GoChapterScene()
	{
		SceneManager.LoadScene("Chapter");
	}

	public void GoAnimationScene()
	{
		SceneManager.LoadScene("Animation");
	}
}
