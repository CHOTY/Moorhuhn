using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootScript : MonoBehaviour
{
    public GameObject projectile;
    public GameObject shootPoint;
    public float power = 10.0f; 
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("LaunchProjectile", 2.0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LaunchProjectile()
    {
        GameObject newProjectile = Instantiate(projectile,
                                            shootPoint.transform.position,
                                            shootPoint.transform.rotation) as GameObject;
        // nasmerujeme projektil podľa natočenia grabPointu s danou silou
        newProjectile.GetComponent<Rigidbody>().AddForce(
                                     shootPoint.transform.forward * power,
                      ForceMode.VelocityChange);
    }
}
