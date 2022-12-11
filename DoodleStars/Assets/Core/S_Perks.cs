using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public struct Wearable
{
    public string name;
    public List<GameObject> wearList;
    public UnityEvent OnUnwear;
    private bool hasHat;
    public bool HasHat
    {
        get { return hasHat; }
        set { 
            hasHat = value;
            foreach (var item in wearList) { item.SetActive(value); }
            if (!value) OnUnwear?.Invoke();
        }
    }
}

public class S_Perks : MonoBehaviour
{

    public List<Wearable> wearables;
    private List<string> names;

    private void Awake()
    {
        names = new List<string>();
        foreach (var item in wearables)
        {
            names.Add(item.name);
        }
    }

    public void SetWearableByName(string name, bool state)
    {
        if(names.Contains(name))
        {
            var a = wearables[names.IndexOf(name)];
            a.HasHat= state;
        }
    }
}
