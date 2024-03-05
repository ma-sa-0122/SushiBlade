using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FpsDisplay : MonoBehaviour
{
    // 変数
    int frameCount;
    float prevTime;
    float fps;

    public Text Fps;

    // 初期化処理
    void Start()
    {
        Application.targetFrameRate = 60; //FPSを60に設定 
        frameCount = 0;
        prevTime = 0.0f;
    }
    // 更新処理
    void Update()
    {
        frameCount++;
        float time = Time.realtimeSinceStartup - prevTime;

        if (time >= 0.5f)
        {
            fps = frameCount / time;
            float FPS = Mathf.Round(fps * 100) / 100; 
            Fps.text = "fps : " + FPS.ToString();

            frameCount = 0;
            prevTime = Time.realtimeSinceStartup;
        }
    }
}
