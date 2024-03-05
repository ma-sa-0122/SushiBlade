using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateComputer : MonoBehaviour
{
    private Transform parent;

    // Start is called before the first frame update
    void Start()
    {
        parent = GameObject.Find("-----sushi-----").transform;

        float x = 135;
        float z1 = -130;
        float z2 = -z1;
        float speed1 = 200;
        float speed2 = 400;

        if (GrobalVariables.playerNums <= 3) {
            x = 75f;
            z1 = 10f;
            z2 = 68f;
            speed1 = 100;
            speed2 = 300;
        }

        for (int i = 0; i < GrobalVariables.playerNums - 1; i++) {
            CreateSushi(i+1, -x, x, z1, z2, speed1, speed2);
        }
    }

    void CreateSushi(int num, float x1, float x2, float z1, float z2, float speed1, float speed2)
    {
        int index = Random.Range(0, GrobalVariables.sushiObjects.Length);
        Vector3 position = new Vector3(Random.Range(x1, x2), 70f, Random.Range(z1, z2));
        float speed = Random.Range(speed1, speed2);

        string sushiName = GrobalVariables.sushiObjects[index];
        bool isTamago = (sushiName == "Egg-Drago");
        // load GameObject from Prefabs
        GameObject prefab = (GameObject)Resources.Load(sushiName);
        // Create Instance
        GameObject sushiClone = Instantiate(prefab, position, prefab.transform.rotation);

        sushiClone.transform.SetParent(parent);
        sushiClone.name = "Com" + num + "(" + sushiName + ")";
        sushiClone.GetComponent<Sushi>().SetSpeed(speed);
        sushiClone.GetComponent<Sushi>().SetTamago(isTamago);
    }
}
