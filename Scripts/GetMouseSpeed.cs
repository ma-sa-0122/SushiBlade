using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GetMouseSpeed : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    private float prevPos = 0;
    private float tempSpeed = 0;
    private float speed = 0;
    private bool isCollide = false;

    private static int width = Screen.width;
    private static int height = Screen.height;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().isKinematic = true;
    }

    // Handlers
    void OnTriggerEnter(Collider collider)
    {
        if (!isCollide) {
            speed = tempSpeed;
            isCollide = true;
        }
    }

    void OnMouseDrag()
    {
        float posx = Input.mousePosition.x;

        if (!isCollide) {
            // move object
            float adjust = ((height) + width * 0.46f)/2 - (143 * height/600f)*0.54f;
            Vector3 objPos = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 mousePos = new Vector3(posx, adjust - posx * 0.46f, 128);
            transform.position = Camera.main.ScreenToWorldPoint(mousePos);

            // get mouse speed
            tempSpeed = Math.Abs(posx - prevPos) * (800f / width);
        }
        text.SetText("速度：" + tempSpeed.ToString() + (isCollide ? "   確" : ""));
        prevPos = posx;
    }


    // button functions
    public void OnClickConfirm()
    {
        float adj = (GrobalVariables.playerNums <= 3) ? 0.8f : 1;
        GrobalVariables.sushiSpeed = speed * GrobalVariables.hashiPrecision * adj;

        if (GrobalVariables.playerNums <= 3) {
            SceneManager.LoadScene("Fight");
        }
        if (GrobalVariables.playerNums >= 4) {
            SceneManager.LoadScene("Fight_over4");
        }
    }

    public void OnClickRetry()
    {
        SceneManager.LoadScene("ReadySpeed");    // 再読み込みでやり直し実装
    }
}
