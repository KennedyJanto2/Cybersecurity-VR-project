using System.Collections;
using UnityEngine;
using TMPro;

public class SpawnController : MonoBehaviour
{
    public GameObject zone;
    [SerializeField]
    public GameObject remyPrefab;
    public Transform spawnPoint;
    public GameObject quizCanvas;
    private GameObject remyInstance;
    public GameObject Object1;
    public GameObject Object2;
    public Material glowMaterial;
    private Material originalMaterial1;
    private Material originalMaterial2;
    private Renderer objectRenderer1;
    private Renderer objectRenderer2;


public float maxGlowIntensity = 133f;
    public float glowSpeed = 2f;

    private bool isGlowing = false;

void Start(){
    quizCanvas.SetActive(false);
    objectRenderer1 = Object1.GetComponent<Renderer>();
        objectRenderer2 = Object2.GetComponent<Renderer>();
        originalMaterial1 = objectRenderer1.material;
        originalMaterial2 = objectRenderer2.material;
}
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && remyInstance == null)
        {
            SpawnRemy();
        }
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

   private void SpawnRemy()
{
    
    remyInstance = Instantiate(remyPrefab, spawnPoint.position, spawnPoint.rotation);
    remyInstance.GetComponent<Animator>().Play("remy@waving");
    remyInstance.GetComponent<AudioSource>().Play();
    StartCoroutine(ShowQuizAfterDelay(2f));
    zone.SetActive(false);

}


    // private void OnTriggerExit(Collider other)
    // {
    //     if (other.CompareTag("Player") && remyInstance != null)
    //     {
    //         Destroy(remyInstance);
    //     }
    // }
    private IEnumerator ShowQuizAfterDelay(float delay)
{
    yield return new WaitForSeconds(delay);
    quizCanvas.SetActive(true);
}

}
