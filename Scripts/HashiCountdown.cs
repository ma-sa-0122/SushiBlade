using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HashiCountdown : MonoBehaviour
{
    public delegate void ZeroHandler();
    public static event ZeroHandler ZeroEvent;

    [SerializeField] private TMP_Text text;
    private float timer = 0;
    private bool once = false;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer <= 5) {
            text.SetText((5 - Math.Floor(timer)).ToString());
        }
        else {
            EventInvoke(once);
            text.SetText("そこまで！");
            once = true;
        }
    }

    void EventInvoke(bool once)
    {
        if (once) return;

        ZeroEvent();
    }
}
