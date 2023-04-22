using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class USBInsert : MonoBehaviour
{
    public GameObject USB;
    public Canvas canvas;
    public Sprite newSprite;

    public void onInsert()
    {
        Debug.Log("Inserted");
        USB.SetActive(false);
        canvas.GetComponent<Image>().sprite = newSprite;
    }
}
