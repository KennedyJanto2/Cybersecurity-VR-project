using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TotalPoints : MonoBehaviour
{
    private int startingPoints = 0;
    public Text pointsTracker;

    // Update is called once per frame
    void Update()
    {
        pointsTracker.text = "Total Points: " + startingPoints;

        if (Input.GetKeyDown(KeyCode.Keypad0))

        {
            startingPoints++;
        }
    }
}
