using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SO_Biome : ScriptableObject
{
    public string naming;
    public string description;
    public float height;
    public float step;
    public List<GameObject> platforms;
    public List<float> spawnrate;
}
