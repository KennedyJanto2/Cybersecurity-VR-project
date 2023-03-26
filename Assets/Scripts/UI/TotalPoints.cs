using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class TotalPoints : MonoBehaviour
{
    public int startingPoints = 0;
    public Text pointsTracker;

    // Update is called once per frame
    void Update()
    {
        pointsTracker.text = "Total Points: " + startingPoints;

        if (Input.GetKeyDown(KeyCode.Space))

        {
            startingPoints++;
        }
    }

        public InputActionProperty action;

        void OnEnable()
        {
            action.action.Enable();
            action.action.performed += (e) => { startingPoints++; };
        }
    }
