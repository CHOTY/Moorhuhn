using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDelete : MonoBehaviour
{
    void Start() { }
    void Update() { }
    private void OnCollisionEnter(Collision other)
    {
            Destroy(gameObject);
    }

}
