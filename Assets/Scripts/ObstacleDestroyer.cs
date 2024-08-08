using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour
{
    ObstacleSpawner obstacle;
    // Start is called before the first frame update
    void Start()
    {
        obstacle = GameObject.FindObjectOfType<ObstacleSpawner>();
    }
     void OnTriggerExit(Collider other) 
     {
        Destroy(gameObject,2);
     }
     private void OnTriggerEnter(Collider other) 
    {
        obstacle.SpawnTile();
    }
   
}

