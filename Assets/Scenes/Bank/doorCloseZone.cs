using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorCloseZone : MonoBehaviour
{
    public GameObject zone;
    public GameObject player;
    public Animation doorAnimation;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            
            doorAnimation.Play("Close");
            zone.SetActive(false);
        }
    }
}
