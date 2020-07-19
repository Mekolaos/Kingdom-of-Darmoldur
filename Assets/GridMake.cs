using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class GridMake : MonoBehaviour
{
    public int sizeX, sizeY;
    public float waiTime = 0.05f;
    private Vector3[] vertices;
    private Mesh mesh;

    void Awake()
    {
        StartCoroutine(Generate());
    }

    public IEnumerator Generate()
    {
        WaitForSeconds wait = new WaitForSeconds(waiTime);

        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
        mesh.name = "Painting";
        vertices = new Vector3[(sizeX + 1) * (sizeY + 1)];
        Vector2[] uv = new Vector2[vertices.Length];
        for (int i = 0, y = 0; y <= sizeY; y++)
        {
            for(int x = 0; x <= sizeX; x++, i++)
            {
                vertices[i] = new Vector3(x, y);
                uv[i] = new Vector2((float)x / sizeX, (float)y / sizeY);
                yield return wait;
            }
        }
        mesh.vertices = vertices;
        mesh.uv = uv;

        int[] triangles = new int[sizeX * sizeY * 6];
        for (int ti = 0, vi = 0, y = 0; y < sizeY; y++, vi++){
            for (int x = 0; x < sizeX; x++, ti += 6, vi++) {
                triangles[ti] = vi;
                triangles[ti + 3] = triangles[ti + 2] = vi + 1;
                triangles[ti + 4] = triangles[ti + 1] = vi + sizeX + 1;
                triangles[ti + 5] = vi + sizeX + 2;
                yield return wait;
                mesh.triangles = triangles;
                mesh.RecalculateNormals();
                yield return wait;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
}
