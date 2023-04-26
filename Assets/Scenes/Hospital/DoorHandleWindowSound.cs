using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorHandleWindowSound : MonoBehaviour
{
    [Header("Audio Settings")]
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private Vector3 audioPosition;
    private AudioSource audioSource;
    public TextMeshProUGUI NextObjective;
    public TextMeshProUGUI PrevObjective;
    public GameObject USB;


    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.spatialBlend = 1f;
        audioSource.loop = true;
        audioSource.playOnAwake = false;
        USB.SetActive(false);
    }

    public void onGrabbed()
    {

            audioSource.transform.position = audioPosition;
            audioSource.Play();
            PrevObjective.text=""; 
            NextObjective.text="Where did this usb come from?";
                    USB.SetActive(true);

             
        
    }
}
