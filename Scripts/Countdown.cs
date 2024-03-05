using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    // Create Event/EventHandler to "Sushi.cs"
    public delegate void SushiStartHandler();
    public static event SushiStartHandler SushiStartEvent;

    [SerializeField] private Text three;
    [SerializeField] private Text two;
    [SerializeField] private Text one;
    [SerializeField] private Text start;

    private float timer = 0;
    private bool once = false;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        once = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer < 1) {                     // 3
            three.enabled = true;
            two.enabled = false;
            one.enabled = false;
            start.enabled = false;
        }
        else if (1 <= timer && timer < 2) {  // 2
            three.enabled = false;
            two.enabled = true;
            one.enabled = false;
            start.enabled = false;
        }
        else if (2 <= timer && timer < 3) {  // 1
            three.enabled = false;
            two.enabled = false;
            one.enabled = true;
            start.enabled = false;
        }
        else if (3 <= timer && timer < 5) {  // へいらっしゃい
            three.enabled = false;
            two.enabled = false;
            one.enabled = false;
            start.enabled = true;
            start.fontSize += 1;

            Time.timeScale = 3.5f;
            EventInvoke(once);
            once = true;
        }
        else {                               // 全テキストの非表示
            three.enabled = false;
            two.enabled = false;
            one.enabled = false;
            start.enabled = false;

            this.enabled = false;   // スクリプトの停止
        }
    }

    void EventInvoke(bool once)
    {
        if (once) return;

        SushiStartEvent();
    }
}
