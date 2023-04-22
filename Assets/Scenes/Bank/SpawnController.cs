using System.Collections;
using UnityEngine;
using TMPro;

public class SpawnController : MonoBehaviour
{
    public GameObject zone;
    [SerializeField]
    public TextMeshProUGUI Objective;
    public GameObject remyPrefab;
    public Transform spawnPoint;
    public GameObject quizCanvas;
    private GameObject remyInstance;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && remyInstance == null)
        {
            SpawnRemy();
            changeObjective("");
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
private void changeObjective(string objective){
        Objective.text=objective;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && remyInstance != null)
        {
            Destroy(remyInstance);
        }
    }
    private IEnumerator ShowQuizAfterDelay(float delay)
{
    yield return new WaitForSeconds(delay);
    quizCanvas.SetActive(true);
}

}
