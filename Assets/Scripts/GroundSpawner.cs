using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTile;
    Vector3 nextSpawanPoint;

    public void SpawnTile()
    {
       GameObject temp =  Instantiate(groundTile,nextSpawanPoint,Quaternion.identity);
       nextSpawanPoint = temp.transform.GetChild(1).transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i<15;i++)
        {
            SpawnTile();
        }
    
    }
}
