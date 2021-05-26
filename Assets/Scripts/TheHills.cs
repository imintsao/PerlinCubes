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
    private Vector3[] vertices;


    // Start is called before the first frame update
    void Start()
    {
      

       //generatePerlinHills();
    }

    void grabComponents()
    {

        myMeshFilter = this.GetComponent<MeshFilter>().mesh;

        myCollider = this.GetComponent<MeshCollider>();

    }


    public void generatePerlinHills()
    {

        if (myMeshFilter == null)

            grabComponents();


        vertices = myMeshFilter.vertices;

        float pX = 0;
        float pZ = 0;


        for (int i = 0; i < vertices.Length; i++)
        {

            pX = (1000000 + this.transform.position.x + vertices[i].x *
                this.transform.lossyScale.x) / gradient + seed;

            pZ = (1000000 + this.transform.position.z + vertices[i].z *
                this.transform.lossyScale.z) / gradient + seed;


            vertices[i].y = Mathf.PerlinNoise(pX, pZ) * height;

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            seed += 0.3f;

            generatePerlinHills();

        }

    }
}
