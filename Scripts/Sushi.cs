using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Sushi : MonoBehaviour
{
    // Create events to "Defeat.cs" in Studium
    public UnityEvent<GameObject> StudiumoutEvent = new UnityEvent<GameObject>();
    public UnityEvent<GameObject> SleepoutEvent = new UnityEvent<GameObject>();

    // sushi parametors
    [SerializeField] private float speed = 0;
    [SerializeField] private bool isTamago = false;

    // SE
    private AudioSource audioSource;
    private AudioClip se;

    private Rigidbody rb;
    private bool flagStart = false;
    private bool firstStep = false;
    private int timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        firstStep = false;
        flagStart = false;

        audioSource = gameObject.AddComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        Countdown.SushiStartEvent += SushiStart;

        se = (AudioClip)Resources.Load("kinzoku");
    }

    // Active when Countdown.cs.timer = 4
    void SushiStart()
    {
        rb.isKinematic = false;
        rb.maxAngularVelocity = 1145148101919;

        Vector3 force = -transform.forward * speed * 0.5f;
        rb.AddForce(force, ForceMode.VelocityChange);               // 初速, 下に落とすのでマイナス

        flagStart = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!flagStart) return;
        
        if (Math.Abs(rb.angularVelocity.y) <= 0.3 && firstStep) {
            timer += 1;
            if (timer >= 30) {
                SleepoutEvent.Invoke(this.gameObject);
            }
        }
        else {
            timer = 0;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Studium" && !firstStep) {
            firstStep = true;
            StartCoroutine("Rotate");
        }
        if (collision.gameObject.name == "studium-out Collider") {
            StudiumoutEvent.Invoke(this.gameObject);
        }

        if (collision.gameObject.tag == "Sushi") {
            audioSource.PlayOneShot(se);
        }
    }

    IEnumerator Rotate() 
    {
        yield return new WaitForSeconds(0.01f);

        int flag = isTamago ? -1 : 1;       // たまごなら左回転
        Vector3 angularforce = flag * transform.forward * Mathf.PI * speed * 8;
        rb.AddTorque(angularforce, ForceMode.Impulse);     // 角速度
    }


    // setters
    public void SetSpeed(float speed) {
        this.speed = speed;
    }
    public void SetTamago(bool tf) {
        this.isTamago = tf;
    }


    // remove EventHandler (used in Defeat.cs)
    public void removeEvent() {
        Countdown.SushiStartEvent -= SushiStart;
    }
}
