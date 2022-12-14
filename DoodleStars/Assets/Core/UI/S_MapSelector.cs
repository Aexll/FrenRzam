using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class S_MapSelector : MonoBehaviour
{

    public UnityEvent<string> OnSelectMap;
    public string selectedMap;

    public void SelectMap(string mapName)
    {
        if(mapName!=null && mapName != selectedMap)
        {
            selectedMap = mapName;
            PlayerPrefs.SetString("map", selectedMap);
            OnSelectMap?.Invoke(mapName);
        }
    }

    private void Start()
    {
        SelectMap(PlayerPrefs.GetString("map"));
    }
}
