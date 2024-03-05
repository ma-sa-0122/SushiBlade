using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateSushiReadyPosition : MonoBehaviour
{
    GameObject sushiClone;

    void Start()
    {
        string sushiName = GrobalVariables.sushiObjects[GrobalVariables.sushiIndex];
        // load GameObject from Prefabs
        GameObject prefab = (GameObject)Resources.Load(sushiName);
        // Create Instance
        sushiClone = Instantiate(prefab, new Vector3(0.0f, 70.0f, -10.0f), prefab.transform.rotation);

        // remove Sushi.cs component & add GetMousePosition.cs component
        Destroy(sushiClone.GetComponent<Sushi>());
        Destroy(sushiClone.GetComponent<CapsuleCollider>());
        sushiClone.AddComponent<GetMousePosition>();
    }

    // button function
    public void OnClickConfirm()
    {
        GrobalVariables.sushiPosition = sushiClone.transform.position;
        GrobalVariables.sushiRotation = sushiClone.transform.localEulerAngles;
        SceneManager.LoadScene("ReadyHashi");
    }
}
