using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{

    public int scoreAmount = 10; 
    void Start() { }
    void Update() { }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            if(gameObject.tag=="ChickS"){
                GameManager.gm.setSpecialSpawned(false);
            }
            Destroy(gameObject); 
            GameManager.gm.ChangeScore(scoreAmount);
        }
    }

}
