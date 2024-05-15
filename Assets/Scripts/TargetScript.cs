using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{

    public int scoreAmount = 10; 
    public GameObject explosionPrefab;
    void Start() { }
    void Update() { }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            if (explosionPrefab) {
	                Instantiate (explosionPrefab, transform.position, transform.rotation);
            if(gameObject.tag=="ChickS"){
            
                GameManager.gm.setSpecialSpawned(false);
            }
            Destroy(gameObject); 
            GameManager.gm.ChangeScore(scoreAmount);
        }
    }
}
}
