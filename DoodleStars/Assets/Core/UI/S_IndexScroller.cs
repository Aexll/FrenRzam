using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TextCore.Text;

public class S_IndexScroller : MonoBehaviour
{
    [SerializeField] private UnityEvent<string, int> OnChange;

    [SerializeField] private int min, max;

    [SerializeField] private string fieldPlayerPref;

    private int selectedOption;

    private void Awake()
    {
        selectedOption = 0;
    }

    private void Start()
    {
        if (!PlayerPrefs.HasKey(fieldPlayerPref))
        {
            selectedOption = min;
        }
        else
        {
            Load();
        }

        OnChange.Invoke(fieldPlayerPref, selectedOption);
    }

    public void NextOption()
    {
        selectedOption++;

        if (selectedOption >= max)
        {
            selectedOption = min;
        }

        OnChange?.Invoke(fieldPlayerPref, selectedOption);
    }

    public void PreviousOption()
    {
        selectedOption--;
        
        if (selectedOption < 0)
        {
            selectedOption = max - 1;
        }

        OnChange?.Invoke(fieldPlayerPref, selectedOption); 
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt(fieldPlayerPref);
    }
}
