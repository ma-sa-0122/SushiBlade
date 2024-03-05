using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SelectPlayers : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;

    void Start()
    {
        Time.timeScale = 1;
    }

    public void OnClick()
    {
        string input = _inputField.GetComponent<TMP_InputField>().text;
        if (2 <= int.Parse(input) && int.Parse(input) <= 9) {
            GrobalVariables.playerNums = int.Parse(input);
            SceneManager.LoadScene("Select");
        }
    }
}
