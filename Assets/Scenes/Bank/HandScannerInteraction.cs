using System.Collections;
using UnityEngine;

public class HandScannerInteraction : MonoBehaviour
{
    public GameObject player;
    public Animation doorAnimation;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            
            doorAnimation.Play("Open");

        }
    }

    
}
