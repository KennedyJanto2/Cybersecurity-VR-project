using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEngine.InputSystem.Controls.AxisControl;

public class Mouse : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Pointer pointer;
    [SerializeField] float mouseSpeedScale;

    private Vector3? previousPos;
   
    void Start()
    {
        previousPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.GetType() == typeof(BoxCollider))
        {
            MoveMouseUI();    
        }

        else if (collision.collider.GetType() == typeof(MeshCollider)) { }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.GetType() == typeof(BoxCollider))
        {
            previousPos = null;
        }
    }

    void MoveMouseUI()
    {
        Vector3 current = transform.position;
        if (previousPos.HasValue && current != previousPos)
        {

            Vector2 difference = new Vector2(current.x - previousPos.Value.x, current.z - previousPos.Value.z);
            difference *= mouseSpeedScale;

            pointer.SetUIPosition(difference);
        }
        previousPos = current;
    }
}
