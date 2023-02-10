using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class CallbackExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InputManager.instance.playerActions.DefaultControls.Jump.started += Jump;
        InputManager.instance.playerActions.DefaultControls.Jump.canceled += Jump;
    }

    private void Jump(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            Debug.Log("Started Jump");
        }
        else if (value.canceled)
        {
            Debug.Log("Canceled Jump");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
