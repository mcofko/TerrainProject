using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandscapeGenerator : MonoBehaviour {

    private static LandscapeGenerator _instance;
    public static LandscapeGenerator Instance
    {
        get { return _instance; }
    }

    public GameObject grass;
    public int mapSizeX = 50;
    public int mapSizeZ = 50;

    public float heightScale = 20.0f;
    public float detailScale = 20.0f;

    float seed = 1.123454321f;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    // Use this for initialization
    void Start () {
        CreateGrassField();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void CreateGrassField()
    {
        int y = 0;
        for (int x = 0; x < mapSizeX; x++)
        {
            for (int z = 0; z < mapSizeZ; z++)
            {
                y = (int) (Mathf.PerlinNoise ( (x + seed) / detailScale, (z + seed) / detailScale ) * heightScale);
                GameObject g = Instantiate(grass);
                g.transform.position = new Vector3(x, y, z);
                g.transform.parent = this.transform;

                // debugging
                if ( x == 5)
                {
                    float y1 = Mathf.PerlinNoise((x + seed), (z + seed));
                    float y2 = Mathf.PerlinNoise((x + seed) / detailScale, (z + seed) / detailScale);
                    Debug.Log("z: "+ z +", y value: " + y1 + ", y with detail: " + y2 + ". ZSeed value: " + (z + seed) / detailScale);
                }
            }
        }
    }
}
