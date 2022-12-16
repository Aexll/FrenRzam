using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Scene : MonoBehaviour
{
    [SerializeField] private string sceneName;

    public void setPlayerScenePref()
    {
        PlayerPrefs.SetString("scene", sceneName);
    }
}
