using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSushiReadySpeed : MonoBehaviour
{
    GameObject sushiClone;

    // Start is called before the first frame update
    void Start()
    {
        string sushiName = GrobalVariables.sushiObjects[GrobalVariables.sushiIndex];
        // load GameObject from Prefabs
        GameObject prefab = (GameObject)Resources.Load(sushiName);
        // Create Instance
        sushiClone = Instantiate(prefab, new Vector3(83.0f, 121.0f, -67.0f), Quaternion.identity);

        // remove Sushi.cs component & settings
        Destroy(sushiClone.GetComponent<Sushi>());
        Destroy(sushiClone.GetComponent<CapsuleCollider>());
        Destroy(sushiClone.GetComponent<Rigidbody>());
        sushiClone.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
    }
}
