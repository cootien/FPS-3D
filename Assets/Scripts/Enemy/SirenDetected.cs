using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SirenDetected : MonoBehaviour
{
    public AudioSource Siren;
    private bool sirenPlaying;

    public void OnTriggerEnter(Collider other)
    {
        if (sirenPlaying) return;
        if (other.gameObject.CompareTag("Player"))
        {
            Siren.Play();
            //Debug.Log("==SirennPlay");

            sirenPlaying = true;
            StartCoroutine(SirenTime());
        }
    }
    private IEnumerator SirenTime()
    {
        yield return new WaitForSeconds(4f); // Wait for 3 seconds
        sirenPlaying = false;
    }
}
