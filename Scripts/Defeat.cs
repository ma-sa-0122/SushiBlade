using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Defeat : MonoBehaviour
{
    Stopwatch sw = new Stopwatch();
    private List<GameObject> sushis = new List<GameObject>();
    private LinkedList<string> sushiNames = new LinkedList<string>();
    private string lastOne;
    private string message = "へいらっしゃい！\n";

    private TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("MessageText").GetComponent<TMP_Text>();
        sushis.AddRange(GameObject.FindGameObjectsWithTag("Sushi"));
        foreach (GameObject sushi in sushis){
            sushiNames.AddLast((sushi).name);

            // add listener to Events
            sushi.GetComponent<Sushi>().StudiumoutEvent.AddListener(StudiumOut);
            sushi.GetComponent<Sushi>().SleepoutEvent.AddListener(SleepOut);
        }
    }


    public void StudiumOut(GameObject sushi)
    {
        string name = sushi.name;

        sushi.SetActive(false);
        sushiNames.Remove(name);
        message += name + "がスタジアムアウト！\n";
        text.SetText(message);

        Winner();
    }

    public void SleepOut(GameObject sushi)
    {
        string name = sushi.name;

        sushi.SetActive(false);
        sushiNames.Remove(name);
        message += name + "がスリープアウト！\n";
        text.SetText(message);

        Winner();
    }


    void Winner(){
        int size = sushiNames.Count;
        if (size >= 2) {
            return;
        }
        else if (sushiNames.Count == 1) {
            sw.Start();
            lastOne = sushiNames.First.Value;
        }
        else if (sushiNames.Count == 0) {
            sw.Stop();
            TimeSpan interval = sw.Elapsed;
            if (interval.TotalMilliseconds > 100) {
                message += "勝者、" + lastOne + "！！！";
                text.SetText(message);
            }
            else{
                message += "引き分け！！！";
                text.SetText(message);
            }
        }
    }


    // button Script
    public void OnClickMouissen()
    {
        RemoveMethod();
        SceneManager.LoadScene("Select");
    }

    public void OnClickReStart()
    {
        RemoveMethod();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OnClickReset()
    {
        RemoveMethod();
        SceneManager.LoadScene("Title");
    }

    void RemoveMethod()
    {
        foreach (GameObject sushi in sushis) {
            sushi.GetComponent<Sushi>().removeEvent();
        }
    }
}