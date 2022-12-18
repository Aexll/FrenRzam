using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_UI : MonoBehaviour
{

    public GameObject LoseWidget;
    public string menuMapName;

    public void ShowLose()
    {
        LoseWidget.SetActive(true);
    }

    public void Restart()
    {
        menuMapName = PlayerPrefs.GetString("map");
        SceneManager.LoadScene(menuMapName);
    }

    private void Update()
    {
        if (LoseWidget.active && (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Space)))
        {
            Restart();
        }
    }
}
