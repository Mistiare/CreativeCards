using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Chunk
{
    public GameObject[] platforms;
    public int minHeight;
    public int maxHeight;
}


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
    private List<Chunk> currentChunks = new List<Chunk>();

    [SerializeField]
    private float minPositionPlatformX;
    [SerializeField]
    private float maxPositionPlatformX;

    [SerializeField]
    private int startHeight;
    [SerializeField]
    private int maxHeight;

    private Sprite aSprite;

    void Start()
    {
        GenerateHeightList(startHeight, maxHeight, 2);
    }


    private void GeneratePlatforms(int startHeight, int maxHeight, int platformDistance)
    {
        List<int> availableHeights = GenerateHeightList(startHeight, maxHeight, platformDistance);

        for (int i = 0; i < availableHeights.Count - 1; i++)
        {
            int height = availableHeights[UnityEngine.Random.Range(0, availableHeights.Count)];
            availableHeights.Remove(height);

            Vector2 randomHeight = new Vector2(UnityEngine.Random.Range(minPositionPlatformX, maxPositionPlatformX), height);
            SpawnPlatforms(randomHeight);
        }
    }

    private List<int> GenerateHeightList(int startHeight, int maxHeight, int platformDistance)
    {
        List<int> availableHeights = new List<int>();
        for (int i = startHeight; i < maxHeight; i+=platformDistance)
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
