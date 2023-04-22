using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZoneAudioController : MonoBehaviour
{
    [Header("Audio Settings")]
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private Vector3 audioPosition;
    private AudioSource audioSource;
    public TextMeshProUGUI Objective;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.spatialBlend = 1f;
        audioSource.loop = true;
        audioSource.playOnAwake = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.transform.position = audioPosition;
            audioSource.Play();
            Objective.text="Seems like someone is knocking on the door, try opening the door";
        }
    }

    

   
}
