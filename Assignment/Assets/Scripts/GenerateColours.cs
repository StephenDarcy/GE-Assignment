using System.Collections;
using UnityEngine;

public class GenerateColours : MonoBehaviour
{
    [System.Serializable]
    public class SplatHeights
    {
        public int index;
        public int startingHeight;
    }

    public SplatHeights[] splatHeights;
    private TerrainData data;

    void Start()
    {
        data = Terrain.activeTerrain.terrainData;
        float[,,] splatmapData = new float[data.alphamapWidth, data.alphamapHeight, data.alphamapLayers];
    }

}
