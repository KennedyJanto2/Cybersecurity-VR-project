using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CorrectOptionButton : MonoBehaviour, IClickable
{
    private QuestionUI questionUI;
    private int currentQuestion;

    void Start()
    {
        questionUI = gameObject.transform.parent.GetComponent<QuestionUI>();
        currentQuestion = questionUI.GetDisplayedQuestion();
    }

    public void Click()
    {
        StartCoroutine(feedback());
    }

    IEnumerator feedback()
    {
        Debug.Log("CORRECT");
        gameObject.GetComponent<TextMeshProUGUI>().color = Color.green;
        yield return new WaitForSeconds(2);
        Debug.Log("HERE");
        questionUI.SetCurrentQuestion(currentQuestion + 1);
    }
}
