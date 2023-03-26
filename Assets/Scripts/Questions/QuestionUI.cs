using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class QuestionUI : MonoBehaviour
{
    [SerializeField] QuestionCollection questions;

    [SerializeField] Canvas canvas;

    [SerializeField] TextMeshProUGUI questionPrefab;
    [SerializeField] TextMeshProUGUI optionPrefab;

    [SerializeField] float xPaddingRatio;
    [SerializeField] float startingYPaddingRatio;
    [SerializeField] float ypaddingRatio;
    [SerializeField] float questionOptionPaddingRatio;

    private int currentQuestion;
    private int displayedQuestion;


    public int startingPoints = 0;
    public Text pointsTracker;

    // Start is called before the first frame update
    void Start()
    {
        currentQuestion = 0;
        displayedQuestion = -1;
    }


    // Update is called once per frame
    void Update()
    {
        pointsTracker.text = "Total Points: " + startingPoints;
        if (currentQuestion != displayedQuestion && currentQuestion < questions.questions.Count)
        {
            ClearQuestions();
            displayedQuestion = currentQuestion;
            DisplayQuestion(currentQuestion);
        }

        
    }

    public InputActionProperty action;

    void OnEnable()
    {
        action.action.Enable();
        action.action.performed += (e) => { startingPoints++; };
    }

    public void SetCurrentQuestion(int currentQuestion)
    {
        this.currentQuestion = currentQuestion;
    }

    public int GetDisplayedQuestion()
    {
        return displayedQuestion;
    }

    void DisplayQuestion(int id)
    {
        Question question = questions.questions[id];

        RectTransform canvasRect = canvas.GetComponent<RectTransform>();
        float currentY = canvasRect.rect.height / 2 - canvasRect.rect.height * startingYPaddingRatio;
        float currentX = -canvasRect.rect.width / 2 + canvasRect.rect.width * xPaddingRatio;

        questionPrefab.text = question.question;
        Vector3 questionPos = new Vector3(currentX, currentY, 0);
        questionPrefab.GetComponent<RectTransform>().anchoredPosition = questionPos;

        Instantiate(questionPrefab, transform);

        currentY -= (questionPrefab.GetComponent<RectTransform>().rect.height + canvasRect.rect.height * questionOptionPaddingRatio);
        for (int i = 0; i < question.options.Count; i++)
        {
            var option = Instantiate(optionPrefab, transform);
            if (i != 0)
                currentY -= canvasRect.rect.height * ypaddingRatio;

            option.text = question.options[i];
            Vector3 optionPos = new Vector3(currentX, currentY, 0);
            option.GetComponent<RectTransform>().anchoredPosition = optionPos;

            if(question.correctOption == i)
            {
                CorrectOptionButton cb = option.gameObject.AddComponent<CorrectOptionButton>();
                startingPoints++;
            }
        }
    }

    void ClearQuestions()
    {
        foreach (Transform child in gameObject.transform)
        {
            Destroy(child.gameObject);
        }
    }


}
