using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;

    public GameObject[] platforms;
    //public int numberOfPlatforms;
    public float SceneWidth;
    private int index;

    [SerializeField]
    private Transform player;
    private float currentPlayerHeight;

    [Header("Platform X Bounds")]
    [SerializeField]
    private float minPositionPlatformX;
    [SerializeField]
    private float maxPositionPlatformX;

    [Header("Default Platform Heights")]
    [SerializeField]
    private int startHeight;
    [SerializeField]
    private int maxHeight;
    [SerializeField]
    private float platformDistance;

    void Start()
    {
        GeneratePlatforms(startHeight, maxHeight, platformDistance);
    }

    /*
     * Spawns the platforms using a list of heights made in GenerateHeightList(...)
     * once it has spawned it removes that height option from the list so that no
     * two platforms spawn on the same height.
     * 
     * You'll want to use this function and provide it the starting height of the new 
     * 'chunk' to load as well as the highest point you want to render it to until the
     * next chunk.
     * 
     * You'll have to implement a script that uses the function below every so often 
     * for performance purposes.
     */
    private void GeneratePlatforms(int startHeight, int maxHeight, float platformDistance)
    {
        List<float> availableHeights = GenerateHeightList(startHeight, maxHeight, platformDistance);

        for (int i = 0; i < availableHeights.Count - 1; i++)
        {
            float height = availableHeights[i];
            //Removing it ensures it will only be used once
            availableHeights.Remove(i);

            Vector2 randomHeight = new Vector2(UnityEngine.Random.Range(minPositionPlatformX, maxPositionPlatformX), height);
            SpawnPlatforms(randomHeight);
        }
    }

    //Generates a list using a minimum and maximum height. It also uses a distance to state how many platform positions are between
    private List<float> GenerateHeightList(int startHeight, int maxHeight, float platformDistance)
    {
        //Declaring an empty list of floats
        List<float> availableHeights = new List<float>();
        for (float i = startHeight; i < maxHeight; i+=platformDistance)
        {
            availableHeights.Add(i);
        }

        return availableHeights;
    }

    //Deals with just the Platform Instantiation using a position
    private void SpawnPlatforms(Vector2 position)
    {
        Instantiate(platformPrefab, position, Quaternion.identity);
    }
}
