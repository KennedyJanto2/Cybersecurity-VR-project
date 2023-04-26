using System.Collections;
using UnityEngine;

public class HandScannerInteraction : MonoBehaviour
{
    public GameObject player;
    public Animation doorAnimation;

    public void OnHilighted()
    {
       
            
            doorAnimation.Play("Open");

       
    }

    
}
