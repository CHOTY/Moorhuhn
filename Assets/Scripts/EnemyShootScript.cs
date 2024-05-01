using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootScript : MonoBehaviour
{

    public AudioClip hitSound;
    private AudioSource audioSource;
    public AudioClip characterDamageSound;
    private AudioSource audioSource2;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource2 = gameObject.AddComponent<AudioSource>();
        InvokeRepeating("Hit", 5.0f, 5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Hit()
    {
        audioSource.volume = 0.25f;
        audioSource.PlayOneShot(hitSound);
        GameManager.gm.DoDamage(1);
        audioSource2.volume = 0.25f;
        audioSource2.PlayOneShot(characterDamageSound);
    }
}
