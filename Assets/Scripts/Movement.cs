using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour{

    public Vector3 targetPosition;
    public float rychlost;
    public float maximum;

    void Update() {
       if (transform.position.y <= maximum){
            Vector3 directionToMove = new Vector3(0f, 0f, targetPosition.y - transform.position.x);
            transform.Translate(directionToMove.normalized * rychlost * Time.deltaTime);
        }
       else {
            Vector3 directionToMove = new Vector3(0f, targetPosition.y - transform.position.y, targetPosition.z - transform.position.z);
            transform.Translate(directionToMove.normalized * rychlost * Time.deltaTime);
       }
    }
}