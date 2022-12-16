using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class S_LoadScene : MonoBehaviour
{
    public UnityEvent OnLoadScene;
    public string defaultScene;
    public void Awake()
    {
        PlayerPrefs.SetString("scene", defaultScene);
        Debug.Log(PlayerPrefs.GetString("scene"));
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("scene"));
        OnLoadScene?.Invoke();
    }
}
