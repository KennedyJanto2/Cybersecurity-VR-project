using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUI : MonoBehaviour, IClickable
{
    public void Click()
    {
        Debug.Log("UI ELEMENT CLICK TEST");
    }
}
