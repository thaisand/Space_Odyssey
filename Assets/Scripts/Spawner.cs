using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject consumivel;
    public float spawnRate;
    public float nextSpawn = 0f; 

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawn){
            nextSpawn = Time.time + spawnRate;
            Instantiate(consumivel, transform.position, consumivel.transform.rotation);
        }
    }
}
