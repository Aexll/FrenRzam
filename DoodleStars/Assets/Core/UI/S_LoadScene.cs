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
        PlayerPrefs.SetString("Map", defaultScene);
    }

    public void ChangeScene()
    {
        Debug.Log(PlayerPrefs.GetString("Map"));
        SceneManager.LoadScene(PlayerPrefs.GetString("Map"));
        OnLoadScene?.Invoke();
    }
}
