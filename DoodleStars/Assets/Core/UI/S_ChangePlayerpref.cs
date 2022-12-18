using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ChangePlayerpref : MonoBehaviour
{
    [SerializeField] private string fieldName;

    public void Save(int selectedOption)
    {
        PlayerPrefs.SetInt(fieldName, selectedOption);
    }
}
