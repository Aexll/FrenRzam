using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_SetStrinPlayerpref : MonoBehaviour
{
    [SerializeField] private string fieldName, data;

    public void Save()
    {
        PlayerPrefs.SetString(fieldName, data);
        Debug.Log(fieldName+ " " + data);
    }
}
