using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour
{

    public int scoreAmount = 0; 
    void Start() { }
    void Update() { }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            Destroy(gameObject); 
            GameManager.gm.ChangeScore(scoreAmount);
        }
    }

}
