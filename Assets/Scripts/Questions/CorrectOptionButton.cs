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

    IEnumerator feedback()
    {
        questionUI.SetClickedOption(optionIndex);
        Debug.Log("CORRECT");
        gameObject.GetComponent<TextMeshProUGUI>().color = Color.green;
        yield return new WaitForSeconds(2);
        Debug.Log("HERE");
    }
}
