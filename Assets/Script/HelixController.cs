using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixController : MonoBehaviour
{
    public GameObject[] helixRings;
    public float ySpawn = 0;
    public float ringsDistance = 5;
    public int numberOfRings;


    void Start()
    {
        numberOfRings = GameManager.currentlevelIndex + 5;
        //spawn helix rings
        for(int i = 0; i < numberOfRings; i++)
        {
            if (i == 0)
            {
                SpawnRing(0);
            }
            else
            {
                SpawnRing(Random.Range(1, helixRings.Length - 1));
            }
           
        }

        //spawn last ring
       SpawnRing(helixRings.Length - 1);
        
    }

    public void SpawnRing(int ringIndex)
    {
        GameObject gameObject = Instantiate(helixRings[ringIndex], transform.up * ySpawn, Quaternion.identity);//parenting the array of rings under the helixmanager
        gameObject.transform.parent = transform; 
        ySpawn -= ringsDistance;//the distance between the helix rings that are spawned at intervals
    }
}

