using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GetMouseClicks : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private TMP_Text Left;
    [SerializeField] private TMP_Text Right;
    
    private bool countZero = false;
    private bool calculated = false;
    private int left = 0;
    private int right = 0;
    private float precision;

    private int MinClicks = 15;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        HashiCountdown.ZeroEvent += ChangeFlag;
    }

    // Update is called once per frame
    void Update()
    {
        if (!countZero) GetClick();
        else {
            if (calculated) return;
            if (left >= MinClicks && right >= MinClicks) {
                int error = Math.Abs(left - right);
                float average = (left + right) / 2;
                precision = 1 - error / average;
                text.SetText("精度：" + (precision * 100).ToString("F0") + " %");

                calculated = true;
            }
            else {
                text.SetText("力不足！");
                GameObject.Find("Confirm").GetComponent<Button>().interactable = false;
            }
        }
    }

    void GetClick()
    {
        //左クリックを受け付ける
        if (Input.GetMouseButtonDown(0)) {
            left += 1;
            Left.SetText("左：" + left);
        }
 
        //右クリックを受け付ける
        if (Input.GetMouseButtonDown(1)) {
            right += 1;
            Right.SetText("右：" + right);
        }
    }

    void ChangeFlag()
    {
        countZero = true;
    }


    // button functions
    public void OnClickConfirm()
    {
        GrobalVariables.hashiPrecision = precision;
        SceneManager.LoadScene("ReadySpeed");
    }
    public void OnClickRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
