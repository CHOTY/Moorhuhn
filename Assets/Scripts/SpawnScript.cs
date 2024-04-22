using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public float secondsBetweenSpawning = 1f;




    public GameObject[] spawnObjects; //toto nemusí byť array, či chceš spawnovať rôzne variácie (skiny/rýchlostné)?






    private float nextSpawnTime; //toto by som zmenil aby nebolo zadávané ale tiež náhodné aby tam bola variácia




    public GameObject special;
    private int randomizer;
    void Start()
    {
        nextSpawnTime = Time.time + secondsBetweenSpawning;
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            randomizer = Random.Range(1, 6);  //nevedel som aké vzácne chcete aby bolo to špeciálne kurča
            if (randomizer == 4) {
                if (GameObject.FindGameObjectWithTag("Special") == null){
                    SpawnSpecial();
                    nextSpawnTime = Time.time + secondsBetweenSpawning;
                }
                else {
                    MakeThingToSpawn(); 
                    nextSpawnTime = Time.time + secondsBetweenSpawning;
                }
            } 
            else {
                MakeThingToSpawn(); 
                nextSpawnTime = Time.time + secondsBetweenSpawning;
            }
        }
    }

    void MakeThingToSpawn()
    {
        Transform objectTransform = transform;
        float x = objectTransform.position.x;
        float y = objectTransform.position.y;
        float z = objectTransform.position.z;
        Vector3 spawnPosition;
        spawnPosition.x = x;
        spawnPosition.y = y;
        spawnPosition.z = z;




        GameObject spawnedObject = Instantiate(spawnObjects[0],
                                    spawnPosition, transform.rotation) as GameObject;  //rovnaká otázka ako hore





        spawnedObject.transform.parent = gameObject.transform;
    }

    void SpawnSpecial()
    {
        Transform objectTransform = transform;
        float x = objectTransform.position.x;
        float y = objectTransform.position.y;
        float z = objectTransform.position.z;
        Vector3 spawnPosition;
        spawnPosition.x = x;
        spawnPosition.y = y;
        spawnPosition.z = z;
        GameObject spawnedObject = Instantiate(special, spawnPosition, transform.rotation) as GameObject;
        spawnedObject.transform.parent = gameObject.transform;
    }
}



