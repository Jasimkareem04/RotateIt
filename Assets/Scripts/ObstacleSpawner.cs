using System.Collections;
using System.Collections.Generic;
 using Unity.VisualScripting;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] section;
    public int xPos = 15;
    public float ypos = 1;
    public bool creatingSection = false; 
    public int SecNum;

    // Update is called once per frame

    public void SpawnTile()
    {
        SecNum = Random.Range(0, 12);
        GameObject temp = Instantiate(section[SecNum], new Vector3(0, ypos, xPos), Quaternion.identity);
        xPos = xPos + 15;
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            SpawnTile();
        }

    }
    /* void Update()
     {
         if(creatingSection == false)
         {
             creatingSection = true ;
             StartCoroutine(GenerateSection());
         }

         IEnumerator GenerateSection()
         {
             SecNum = Random.Range(0,12);
             Instantiate(section[SecNum], new  Vector3(0,ypos,xPos),Quaternion.identity);
             xPos = xPos + 15;
             yield return new WaitForSeconds(0);
             //creatingSection = true ;
         }

     }*/
}

