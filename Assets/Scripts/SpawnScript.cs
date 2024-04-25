using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{

    // zoznam objektov, ktoré sa budú vytvárať – naše prefaby
    public GameObject[] spawnObjects;

    private float nextSpawnTime; // čas, kedy dôjde k vytvoreniu ďalšieho

    // Start is called before the first frame update
    void Start()
    {
        nextSpawnTime = Time.time + Random.Range(2, 10);
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time >= nextSpawnTime)
        {
            int randomizer = Random.Range(2, 10);
            MakeThingToSpawn(); // vytvor dáky objekt
            nextSpawnTime = Time.time + randomizer; // vypočítaj ďalší čas
        }
    }

    void MakeThingToSpawn()
    {
        Transform objectTransform = transform;

        // Retrieve the position (x, y, z)
        float x = objectTransform.position.x;
        float y = objectTransform.position.y;
        float z = objectTransform.position.z;
        Vector3 spawnPosition;
        // definujú sa náhodné súradnice na všetkých osiach z definovaných rozsahov
        spawnPosition.x = x;
        spawnPosition.y = y;
        spawnPosition.z = z;


        // vytvorí sa objekt zo zoznamu objektov, ktoré definujeme v editore
        GameObject spawnedObject = Instantiate(spawnObjects[0],
                                    spawnPosition, transform.rotation) as GameObject;

        // make the parent the spawner so hierarchy doesn't get super messy 
        // = vkladá objekty v rámci hierarchie do spawnera
        spawnedObject.transform.parent = gameObject.transform;
    }
}