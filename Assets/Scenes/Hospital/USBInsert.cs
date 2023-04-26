using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class USBInsert : MonoBehaviour
{
    public TextMeshProUGUI NextObjective1;
    public TextMeshProUGUI NextObjective2;
    public TextMeshProUGUI PrevObjective;
    public void OnPlace1()
    {
        PrevObjective.text=""; 
        NextObjective1.text="You got hacked bro click the button to go back";
    }
    public void OnPlace2()
    {
        PrevObjective.text=""; 
        NextObjective2.text="You did the right thing click the button to go back";
    }
}
