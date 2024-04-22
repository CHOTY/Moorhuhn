using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour{

    public Vector3 targetPosition;
    public float rychlost;

    void Update() {
        Vector3 directionToMove = new Vector3(targetPosition.x - transform.position.x, 0f, 0f);
        transform.Translate(directionToMove.normalized * rychlost * Time.deltaTime);
    }
}