using System.Collections;
using UnityEngine;

public class GenerateColours : MonoBehaviour
{
    [System.Serializable]
    // Storing the texture index and its height
    public class SplatHeights
    {
        public int index;
        public int startingHeight;
    }

    public SplatHeights[] splatHeights;
    private TerrainData data;
    [SerializeField] private int alphamapWidth;
    [SerializeField] private int alphamapHeight;
    [SerializeField] private int alphamapLayers;

    void Start()
    {
        // Getting terrain data
        data = Terrain.activeTerrain.terrainData;

        // Setting height width and layers
        alphamapWidth = data.alphamapWidth;
        alphamapHeight = data.alphamapHeight;
        alphamapLayers = data.alphamapLayers;

        //3D splatmap array 
        float[,,] splatmapData = new float[alphamapWidth, alphamapHeight, alphamapLayers];

        // Looping through each vertex
        for (int i = 0; i < alphamapHeight; i++)
        {
            for (int j = 0; j < alphamapWidth; j++)
            {
                // Getting terrain height
                float terrainHeight = data.GetHeight(i, j);

                // Alpha values for each texture we have
                float[] splat = new float[splatHeights.Length];

                // Looping through each texture and setting its opacity
                for (int k = 0; k < splatHeights.Length; k++)
                {
                    if (k == splatHeights.Length - 1 && terrainHeight >= splatHeights[k].startingHeight)
                    {
                        splat[i] = 1;
                    }
                    // If terrain height is greater than starting height set opacity to 1
                    else if (terrainHeight >= splatHeights[k].startingHeight && terrainHeight <= splatHeights[k + 1].startingHeight)
                    {
                        splat[k] = 1;
                    }
                }

                // Putting updated opacity setting for each co-ordinate into our 3d array/matrix
                for (int l = 0; l < splatHeights.Length; l++)
                {
                    splatmapData[j, i, l] = splat[l];
                }
            }
        }
        // Putting updated values back into our terrain
        data.SetAlphamaps(0, 0, splatmapData);
    }

}
