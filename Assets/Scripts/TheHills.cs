using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheHills : MonoBehaviour
{

    private Mesh myMeshFilter;

    public float gradient = 5f;

    public float height = 5f;

    private MeshCollider myCollider;

    public float seed = 0f;


    // Start is called before the first frame update
    void Start()
    {
        myMeshFilter = this.GetComponent<MeshFilter>().mesh;

        myCollider = this.GetComponent<MeshCollider>();

        generatePerlinHills();
    }


    void generatePerlinHills()
    {
        Vector3[] vertices = myMeshFilter.vertices;

        float px = 0;
        float pz = 0;


        for (int i= 0; i < vertices.Length; i++)
        {
            px = (this.transform.position.x + vertices[i].x) / gradient + seed;

            pz = (this.transform.position.z + vertices[i].z) / gradient;

            vertices[i].y = Mathf.PerlinNoise(px, pz) * height;

        }

        myMeshFilter.vertices = vertices;
        myMeshFilter.RecalculateBounds();
        myMeshFilter.RecalculateNormals();
        myCollider.sharedMesh = null;
        myCollider.sharedMesh = myMeshFilter;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            seed += 0.1f;

            generatePerlinHills();

        }
        
    }
}
