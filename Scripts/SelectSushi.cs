using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SelectSushi : MonoBehaviour
{
    [SerializeField] private TMP_Text TMPtext_Name;
    [SerializeField] private TMP_Text TMPtext_Description;
    private List<GameObject> sushis = new List<GameObject>();
    private int numOfSushi;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        sushis.AddRange(GameObject.FindGameObjectsWithTag("Sushi"));
        numOfSushi = sushis.Count;
        SushisSetVisible();
    }

    public void OnClickLeft() {
        if (0 < index) {
            index -= 1;
            SushisSetVisible();
        } else {    // 左端まで来たら、右端にループ
            index = sushis.Count - 1;
            SushisSetVisible();
        }
    }

    public void OnClickRight() {
        if (index < (numOfSushi - 1)) {
            index += 1;
            SushisSetVisible();
        } else {    // 右端まで来たら、左端にループ
            index = 0;
            SushisSetVisible();
        }
    }

    public void OnClickConfirm() {
        GrobalVariables.sushiIndex = index;
        SceneManager.LoadScene("ReadyPosition");
    }

    private void SushisSetVisible() {
        for (int i = 0; i < numOfSushi; i++) {
            GameObject sushi = sushis[i];
            bool visible = (i == index);

            if (visible) {
                TMPtext_Name.SetText(sushi.GetComponent<SushiDescription>().GetName());
                TMPtext_Description.SetText(sushi.GetComponent<SushiDescription>().GetDescription());
            }
            sushi.SetActive(visible);
        }
    }
}
