using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_UI : MonoBehaviour
{

    public GameObject LoseWidget;

    public void ShowLose()
    {
        LoseWidget.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Menu");
    }
}
