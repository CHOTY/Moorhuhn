using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunScript : MonoBehaviour
{
    public GameObject projectile;   // odkaz na prefab projectilu
    public GameObject laser;
    public TMP_Text ammoText;
    public float power = 10.0f;     // sila/rýchlosť výstrelu
    public GameObject shootPoint;   // pozícia na ktorej vznikne projektil
    public GameObject grabPoint;
    public AudioClip reloadSound; // Assign the audio clip in the Unity Editor
    public AudioClip emptyMagSound;
    public AudioClip gunShotSound;
    private AudioSource audioSource;
    public string hand;

    public int ammoMax = 10;
    private int ammo;
    private bool reloading = false;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        ammo = ammoMax;
        ammoText.text = "Ammo" + hand +": " + ammo.ToString();
    }
    void Update()
    {
        if (ammo == 0 && reloading == false)
        {
            reloading = true;
            ammoText.text = "Reload";
            StartCoroutine(ReloadCoroutine(2.0f));
        }
    }

    private IEnumerator ReloadCoroutine(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Reload();
    }
    public void Shoot()
    {
        if (ammo > 0)
        {
            if (reloadSound != null && audioSource != null)
            {
                audioSource.volume = 0.25f;
                audioSource.pitch = 1;
                audioSource.PlayOneShot(gunShotSound);
            }
            GameObject newProjectile = Instantiate(projectile,
                                    shootPoint.transform.position,
                                    shootPoint.transform.rotation) as GameObject;
            // nasmerujeme projektil podľa natočenia grabPointu s danou silou
            newProjectile.GetComponent<Rigidbody>().AddForce(
                                         grabPoint.transform.forward * power,
                          ForceMode.VelocityChange);
            ammo -= 1;
            ammoText.text = "Ammo" + hand +": " + ammo.ToString();
        }
        else if (reloadSound != null && audioSource != null)
        {
            audioSource.volume = 1f;
            audioSource.pitch = 1.5f;
            audioSource.PlayOneShot(emptyMagSound);
        }
    }

    public void EnableLaser() {
        laser.SetActive(true);
    }
    public void DisableLaser() {
        laser.SetActive(false);
    }
    

    private void Reload()
    {
        if (reloadSound != null && audioSource != null)
        {
            audioSource.volume = 0.5f;
            audioSource.pitch = 1;
            audioSource.PlayOneShot(reloadSound);
        }
        ammo = ammoMax;
        ammoText.text = "Ammo" + hand +": " + ammo.ToString();
        reloading = false;
    }
}
