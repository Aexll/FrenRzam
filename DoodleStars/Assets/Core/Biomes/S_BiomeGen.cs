using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;


/* static class (SC) to randomize things */
public static class SC_Randomizer
{
    /* randomize a list with weights */
    public static void RandomWithWeight(List<float> weights, Action<int> callback)
    {
        var sum = weights.Sum();
        var ran = UnityEngine.Random.Range(0f, sum);
        float leftover = 0;
        for(int i = 0; i < weights.Count; i++)
        {
            if(leftover < ran && ran < leftover + weights[i])
            {
                callback(i);
                return;
            }
            leftover+=weights[i];
        }
    }

}


public class S_BiomeGen : MonoBehaviour
{

    public List<SO_Biome> biomes;

    [SerializeField] private float spawnRangeX = 5; /* it will be double */
    [SerializeField] private float stepHeightMultiplier = 1;
    [SerializeField] private float upOffset = 5;
    private float currentHeight = 0;
    private float inBiomeHeight = 0;
    private float enterBiomeheight = 0;
    private SO_Biome currentBiome;

    /* events */
    public UnityEvent<string> OnBiomeChangedString;

    private void Start()
    {
        currentHeight = transform.position.y;
        ChangeBiome(biomes[UnityEngine.Random.Range(0,biomes.Count)]);
    }

    private void Update()
    {
        if (transform.position.y > currentHeight + (currentBiome.step * stepHeightMultiplier))
        {
            currentHeight += (currentBiome.step * stepHeightMultiplier);
            GenStage();
        }

        if (transform.position.y > enterBiomeheight + currentBiome.height)
        {
            ChangeBiome(biomes[UnityEngine.Random.Range(0,biomes.Count)]);
        }
    }

    public void GenStage()
    {
        SC_Randomizer.RandomWithWeight(currentBiome.spawnrate, (int i) =>
        {
            GenPlatform(currentBiome.platforms[i]);
        });
    }

    public void GenPlatform(GameObject platform)
    {
        var spawnY = currentHeight + upOffset;
        var spawnX = UnityEngine.Random.Range(-spawnRangeX,spawnRangeX);
        var s = Instantiate(platform, new Vector3(spawnX, spawnY, 0), Quaternion.identity);
    }

    public void ChangeBiome(SO_Biome biome)
    {
        inBiomeHeight = 0;
        enterBiomeheight = transform.position.y;
        currentBiome = biome;
        OnBiomeChangedString?.Invoke(biome.naming);
    }

}
