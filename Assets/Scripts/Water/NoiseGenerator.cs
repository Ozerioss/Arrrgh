using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseGenerator : MonoBehaviour {


    public float power = 1.5f;
    public float scale = 1.4f;
    public float timeScale = .5f;


    private float offsetX;
    private float offsetY;
    private MeshFilter mf;


	// Use this for initialization
	void Start () {
        mf = GetComponent<MeshFilter>();
        MakeNoise();
	}
	
	// Update is called once per frame
	void Update () {

        MakeNoise();
        offsetX += Time.deltaTime * timeScale;
        offsetY += Time.deltaTime * timeScale;
		
	}


    void MakeNoise()
    {
        Vector3[] verticies = mf.mesh.vertices;

        for(int i = 0; i < verticies.Length; i++)
        {
            verticies[i].y = CalculateHeight(verticies[i].x, verticies[i].z) * power;
        }

        mf.mesh.vertices = verticies;
    }

    float CalculateHeight(float x, float y)
    {
        float xCoord = x * scale + offsetX;
        float yCoord = y * scale + offsetY;

        return Mathf.PerlinNoise(xCoord, yCoord);
    }
}
