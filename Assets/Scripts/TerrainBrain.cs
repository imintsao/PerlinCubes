using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainBrain : MonoBehaviour
{

    public int xTiles = 4;
    public int zTiles = 4;

    public GameObject tilePrefab = null;

    public Vector3 terrainO = new Vector3(-20, 0, 20);

    public string playerName = "Subject";

    // Start is called before the first frame update
    void Start()
    {
        CentreTerrianOnplayer();

        LayoutTerrain();
    }

    void CentreTerrianOnplayer()
    {

    }

    Vector3 ReturnPlayerPos (string _playerName) {

        return GameObject.Find(_playerName).transform.position;
    }

    void LayoutTerrain()
    {

        for (int x = 0; x < xTiles; x++)
        {
            for (int z = 0; z < zTiles; z++) //Instantiate our prefab.

            {
                Vector3 myPos = terrainO;

                myPos.x += x * 10f * tilePrefab.transform.lossyScale.x;

                myPos.z += z * 10f * tilePrefab.transform.lossyScale.z;

                myPos.y = terrainO.y;


                GameObject newT = GameObject.Instantiate(tilePrefab,
                        myPos, Quaternion.identity);

                //newT.transform.Translate(Vector3.right * myPos.x);
                //newT.transform.Translate(Vector3.forward * myPos.z);

                newT.GetComponent<TheHills>().generatePerlinHills();




            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
