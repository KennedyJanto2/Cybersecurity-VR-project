using System.Collections;
using UnityEngine;

public class HandScannerInteraction : MonoBehaviour
{
    public GameObject player;
    public Animation doorAnimation;
    public GameObject quizCanvas;

    void Start(){
                    quizCanvas.SetActive(false);

    }

    public void OnHilighted()
    {  
            doorAnimation.Play("Open");

    }
    public void OnHilighted2()
    {  
            doorAnimation.Play("Open");
            quizCanvas.SetActive(true);
    }

    
}
