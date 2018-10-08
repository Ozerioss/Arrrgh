using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPlaneGenerator : MonoBehaviour {

    public float size = 1f;
    public int gridSize = 16;

    private MeshFilter filter;

	void Start () {
        filter = GetComponent<MeshFilter>();
        filter.mesh = GenerateMesh();	
	}


    private Mesh GenerateMesh()
    {
        Mesh _mesh = new Mesh();
        var vertices = new List<Vector3>();
        var normals = new List<Vector3>();
        var uvs = new List<Vector2>(); // x, z


        for(int x = 0; x < gridSize + 1; x++)
        {
            for(int y = 0; y < gridSize + 1; y++)
            {
                vertices.Add(new Vector3(-size * 0.5f + size * (x / ((float)gridSize)), 0, -size * 0.5f + size * (y / (float)gridSize)));
                normals.Add(Vector3.up);
                uvs.Add(new Vector2(x / (float)gridSize, y / (float)gridSize));
            }
        }

        var triangles = new List<int>();
        var verticesCount = gridSize + 1;

        for(int i = 0; i < verticesCount * verticesCount - verticesCount; i++)
        {
            if((i + 1) % verticesCount == 0)
            {
                continue;
            }

            // Adds two triangles
            triangles.AddRange(new List<int>()
            {
                i + 1 + verticesCount, i + verticesCount, i,
                i, i+1, i + verticesCount + 1
            });
        }

        _mesh.SetVertices(vertices);
        _mesh.SetNormals(normals);
        _mesh.SetUVs(0, uvs);
        _mesh.SetTriangles(triangles, 0);

        return _mesh;
    }
}
