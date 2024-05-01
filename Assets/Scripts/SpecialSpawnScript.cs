using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialSpawnScript : MonoBehaviour
{
    // Start is called before the first frame update
    // zoznam objektov, ktoré sa budú vytvárať – naše prefaby
    public GameObject[] spawnObjects;

    private float nextSpawnTime; // čas, kedy dôjde k vytvoreniu ďalšieho

    public AudioClip spawnSound;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        //nextSpawnTime = Time.time + Random.Range(35, 60);
        nextSpawnTime = 5;
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time >= nextSpawnTime && GameManager.gm.gameStarted)
        {
            int randomizer = Random.Range(35, 60);
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
        audioSource.volume = 0.65f;
        audioSource.PlayOneShot(spawnSound);
        spawnedObject.transform.parent = gameObject.transform;
    }
}
