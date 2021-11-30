using UnityEngine;

public class GenerateTerrain : MonoBehaviour
{
    // Exposing to unity
    [SerializeField] private int width = 256;
    [SerializeField] private int height = 256;
    [SerializeField] private int depth = 50;
    [SerializeField] private float scale = 10f;
    [SerializeField] private float xOffset;
    [SerializeField] private float yOffset;
    [SerializeField] private float backgroundSpeed = .25f;
    private Terrain terrain;
    private TerrainData data;

    void Start()
    {
        // Generating random offset so terrain will be random each time
        xOffset = Random.Range(0, 10000);
        yOffset = Random.Range(0, 10000);
    }

    void Update()
    {
        // Setting the terrain component
        /*
        terrain = GetComponent<Terrain>();
        BuildTerrain();
        xOffset += Time.deltaTime * backgroundSpeed;
        */
    }


    void BuildTerrain()
    {
        // Storing the current terrain data in 'data' and then updating it with new values
        data = terrain.terrainData;
        data.heightmapResolution = width + 1;
        data.size = new Vector3(width, depth, height);
        data.SetHeights(0, 0, GetHeights());

        // Setting these new values
        terrain.terrainData = data;

    }

    float[,] GetHeights()
    {
        float[,] heights = new float[width, height];
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                heights[i, j] = CalculateHeights(i, j);
            }

        }

        return heights;
    }

    float CalculateHeights(int x, int y)
    {
        float xCoordinate = ((float)x / width) * scale + xOffset;
        float yCoordinate = ((float)y / height) * scale + yOffset;

        return Mathf.PerlinNoise(xCoordinate, yCoordinate);
    }
}
