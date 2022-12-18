using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ChangePlayerpref : MonoBehaviour
{
    [SerializeField] private string fieldName;

    public void Save(int selectedOption)
    {
        Debug.Log("saved yaa" + selectedOption + " to " + fieldName);
        PlayerPrefs.SetInt(fieldName, selectedOption);
        
    }
}
