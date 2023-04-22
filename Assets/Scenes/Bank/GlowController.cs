using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GlowController : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI Objective;
    public GameObject objectToGlow;
    public Material glowMaterial;
    private Material originalMaterial;
    private Renderer objectRenderer;
    public GameObject quizCanvas;

    public float maxGlowIntensity = 133f;
    public float glowSpeed = 2f;

    private bool isGlowing = false;

    private void Start()
    {
        objectRenderer = objectToGlow.GetComponent<Renderer>();
        originalMaterial = objectRenderer.material;
    }

    public void ToggleGlow(string objective)
    {
        isGlowing = !isGlowing;

        if (!isGlowing)
        {
            objectRenderer.material.SetColor("_Color", Color.black);
        }
        quizCanvas.GetComponent<Canvas> ().enabled = false;
        changeObjective(objective);
    }
    private void changeObjective(string objective){
        Objective.text=objective;
    }

    private void Update()
    {
        if (isGlowing)
        {
            float glowIntensity = (Mathf.Sin(Time.time * glowSpeed) * 0.5f + 0.5f) * maxGlowIntensity;
            Color emissionColor = glowMaterial.GetColor("_Color") * glowIntensity;
            objectRenderer.material.SetColor("_Color", emissionColor);
        }
    }
}
