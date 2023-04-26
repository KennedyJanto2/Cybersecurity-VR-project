using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class USBInsert : MonoBehaviour
{
    public GameObject NextObjective1;
    public GameObject NextObjective2;
    public TextMeshProUGUI PrevObjective;
    public void OnPlace1()
    {
        PrevObjective.text=""; 
        NextObjective1.SetActive(true);
    }
    public void OnPlace2()
    {
        PrevObjective.text=""; 
        NextObjective2.SetActive(true);
    }
}
