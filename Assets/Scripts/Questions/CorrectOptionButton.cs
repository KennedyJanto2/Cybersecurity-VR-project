using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CorrectOptionButton : MonoBehaviour, IClickable
{
    private QuestionUI questionUI;
    private int optionIndex;

    public void SetOptionIndex(int index)
    {
        optionIndex = index;
    }

    public void Click()
    {
        questionUI = gameObject.transform.parent.GetComponent<QuestionUI>();
        StartCoroutine(feedback());
    }

    public void UnClick()
    {
        questionUI.SetClickedOption(-1); //one minor bug is that if the user moves the mouse and enters the trigger it sets the index, but if they don't click and move it outside of the trigger and just click then the next question still gets loaded.
                                         //As another easy fix added a OnTriggeExit2D and made it unset the index. 
    }

    IEnumerator feedback()
    {
        questionUI.SetClickedOption(optionIndex);
        Debug.Log("CORRECT");
        gameObject.GetComponent<TextMeshProUGUI>().color = Color.green;
        yield return new WaitForSeconds(2);
        Debug.Log("HERE");
    }
}
