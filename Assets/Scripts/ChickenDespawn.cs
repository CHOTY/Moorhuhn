using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenDespawn : MonoBehaviour
{
    void Start() { }
    void Update() { }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Chick" || other.gameObject.tag == "Projectile")
        {
            Destroy(other.gameObject);
        }
    }
}
