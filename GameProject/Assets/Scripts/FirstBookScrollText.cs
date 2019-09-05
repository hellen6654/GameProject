using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.SceneManagement;

public class FirstBookScrollText : MonoBehaviour {
    // Use this for initialization
    public float speed = 2; //速度
    public float goalLen = 100; //最終位置
    private float moveLen = 0;
    void Start () {
        
    }
    
    // Update is called once per frame
    void Update () {
       
        Move();
	}
    void Move()
    {
        //物體向前移動
        Debug.Log(moveLen);
        if (moveLen <= goalLen)
        {
            moveLen += Time.deltaTime * speed;
            GetComponent<RectTransform>().Translate(0, Time.deltaTime * speed, 0);
            return;
        }
        Invoke("switchScene", 2f);
    }
    void switchScene()
    {
        SceneManager.LoadScene("SecondBook");
    }
}
