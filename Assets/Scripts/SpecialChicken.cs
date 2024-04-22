using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialChicken : MonoBehaviour
{
    void Start() {}
    void Update() {}
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            GameManager.zivoty = GameManager.zivoty-1;
        }
    }
}
