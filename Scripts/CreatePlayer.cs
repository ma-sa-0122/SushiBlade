using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlayer : MonoBehaviour
{
    private Transform parent;
    // Start is called before the first frame update
    void Start()
    {
        parent = GameObject.Find("-----sushi-----").transform;

        string sushiName = GrobalVariables.sushiObjects[GrobalVariables.sushiIndex];
        bool isTamago = (sushiName == "Egg-Drago");
        // load GameObject from Prefabs
        GameObject prefab = (GameObject)Resources.Load(sushiName);
        // Create Instance
        GameObject sushiClone = Instantiate(prefab, GrobalVariables.sushiPosition, Quaternion.Euler(GrobalVariables.sushiRotation));

        sushiClone.transform.SetParent(parent);
        sushiClone.name = "Player(" + sushiName + ")";
        sushiClone.GetComponent<Sushi>().SetSpeed(GrobalVariables.sushiSpeed);
        sushiClone.GetComponent<Sushi>().SetTamago(isTamago);
    }
}
