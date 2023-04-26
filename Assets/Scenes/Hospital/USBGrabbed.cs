using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class USBGrabbed : MonoBehaviour
{
    public TextMeshProUGUI NextObjective;
    public TextMeshProUGUI PrevObjective;
    public GameObject usbPort;
    public GameObject tablePlace;
public Material glowMaterial;
    private Material originalMaterial1;
        private Material originalMaterial2;

    private Renderer objectRenderer1;
        private Renderer objectRenderer2;


public float maxGlowIntensity = 133f;
    public float glowSpeed = 2f;

    private bool isGlowing = false;

    private void Start()
    {
        objectRenderer1 = usbPort.GetComponent<Renderer>();
        objectRenderer2 = tablePlace.GetComponent<Renderer>();
        originalMaterial1 = objectRenderer1.material;
        originalMaterial2 = objectRenderer2.material;

    }
    public void OnGrabbed()
    {
        PrevObjective.text=""; 
        NextObjective.text="You can either insert the USB into your laptop port or return it on the table behind you";
    }
    public void ToggleGlow()
    {
        isGlowing = !isGlowing;

        if (!isGlowing)
        {
            objectRenderer1.material.SetColor("_Color", Color.black);
            objectRenderer2.material.SetColor("_Color", Color.black);
        }
        
    }
    private void Update()
    {
        if (isGlowing)
        {
            float glowIntensity = (Mathf.Sin(Time.time * glowSpeed) * 0.5f + 0.5f) * maxGlowIntensity;
            Color emissionColor = glowMaterial.GetColor("_Color") * glowIntensity;
            objectRenderer1.material.SetColor("_Color", emissionColor);
                        objectRenderer2.material.SetColor("_Color", emissionColor);

        }
    }
}
