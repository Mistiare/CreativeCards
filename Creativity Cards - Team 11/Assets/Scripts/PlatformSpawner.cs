using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;

    public GameObject[] platforms;
    public int numberOfPlatforms;
    public float SceneWidth;
    private int index;

    [SerializeField]
    private Transform player;
    private float currentPlayerHeight;

    [SerializeField]
    private float minPositionPlatformX;
    [SerializeField]
    private float maxPositionPlatformX;

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


    private void GeneratePlatforms(int startHeight, int maxHeight, float platformDistance)
    {
        List<float> availableHeights = GenerateHeightList(startHeight, maxHeight, platformDistance);

        for (int i = 0; i < availableHeights.Count - 1; i++)
        {
            float height = availableHeights[i];
            availableHeights.Remove(i);

            Vector2 randomHeight = new Vector2(UnityEngine.Random.Range(minPositionPlatformX, maxPositionPlatformX), height);
            SpawnPlatforms(randomHeight);
        }
    }

    private List<float> GenerateHeightList(int startHeight, int maxHeight, float platformDistance)
    {
        List<float> availableHeights = new List<float>();
        for (float i = startHeight; i < maxHeight; i+=platformDistance)
        {
            availableHeights.Add(i);
        }

        return availableHeights;
    }

    private void SpawnPlatforms(Vector2 position)
    {
        Instantiate(platformPrefab, position, Quaternion.identity);
    }
}
