using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiDescription : MonoBehaviour
{
    [SerializeField] private string sushiName;
    [SerializeField] private string description;

    public string GetName() {
        return this.sushiName;
    }
    public string GetDescription() {
        return this.description;
    }
}
