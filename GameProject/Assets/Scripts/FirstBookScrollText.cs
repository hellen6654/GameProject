using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.SceneManagement;

public class FirstBookScrollText : MonoBehaviour
{
    // Use this for initialization
    public float speed = 2; //速度
    public float goalLen = 100; //最終位置
    private float moveLen = 0;
    private int startAlpha = 1;
    private int endAlpha = 0;
    private CanvasGroup canvasGroup;
    public float changeTimeSeconds = 5;
    float changeRate = 0;
    float timeSoFar = 0;
    bool fading = false;
    int isRollFinishFlag = 0;
    private void Start()
    {
        canvasGroup = this.GetComponent<CanvasGroup>();
    }
    void Update()
    {
        if (isRollFinishFlag==0)
        {
            Move();
        }
        else if (isRollFinishFlag == 1)
        {
            FadeOut();
            Invoke("SwitchScene", changeTimeSeconds);
            isRollFinishFlag++;
        }
        
    }
    void Move()
    {
        //文字向上移動
        Debug.Log(moveLen);
        if (moveLen <= goalLen)
        {
            moveLen += Time.deltaTime * speed;
            GetComponent<RectTransform>().Translate(0, Time.deltaTime * speed, 0);
            return;
        }
        else
        {
            isRollFinishFlag++;
        }
    }
    void SwitchScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void FadeOut()
    {
        startAlpha = 1;
        endAlpha = 0;
        timeSoFar = 0;
        fading = true;
        StartCoroutine(FadeCoroutine());
    }

    IEnumerator FadeCoroutine()
    {
        changeRate = (endAlpha - startAlpha) / changeTimeSeconds;
        SetAlpha(startAlpha);
        while (fading)
        {
            timeSoFar += Time.deltaTime;

            if (timeSoFar > changeTimeSeconds)
            {
                fading = false;
                SetAlpha(endAlpha);
                yield break;
            }
            else
            {
                SetAlpha(canvasGroup.alpha + (changeRate * Time.deltaTime));
            }

            yield return null;
        }
    }

    public void SetAlpha(float alpha)
    {
        canvasGroup.alpha = Mathf.Clamp(alpha, 0, 1);
    }
}
