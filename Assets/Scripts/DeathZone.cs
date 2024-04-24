using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    void Start() { }
    void Update() { }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Chick")
        {
            Destroy(other.gameObject); 
        }
    }
}
