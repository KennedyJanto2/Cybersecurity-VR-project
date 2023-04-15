using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using Autohand;

public class QuestionUI : MonoBehaviour
{
    public Hand hand;
    [SerializeField] public List<QuestionCollection> questionCollections;

    [SerializeField] Canvas canvas;

    [SerializeField] TextMeshProUGUI questionPrefab;
    [SerializeField] TextMeshProUGUI optionPrefab;

    [SerializeField] float xPaddingRatio;
    [SerializeField] float startingYPaddingRatio;
    [SerializeField] float ypaddingRatio;
    [SerializeField] float questionOptionPaddingRatio;

    private int currentQuestionCollectionIndex = 0;
    private int clickedOptionIndex = -1;

    public int currentPoints = 0;

    public Text pointsTracker;

    // Start is called before the first frame update
    void Start()
    {
        ShuffleList(questionCollections);
        pointsTracker.text = "Total Points: " + currentPoints;

        hand.OnSqueezed += Mousepressed;
    }

    public void Mousepressed(Hand hand, Grabbable clicked)
    {
        if (clickedOptionIndex != -1) {
            bool correctAnswer = false;

            //TODO Check mouse to see which answer is selected and set correctAnswer to true if its the right one
            if (clickedOptionIndex == questionCollections[currentQuestionCollectionIndex].correctAnswer)
                correctAnswer = true;

            //Update UI
            if (correctAnswer)
            {
                currentPoints++;
                pointsTracker.text = "Total Points: " + currentPoints + " out of " + questionCollections.Count;
            }

            clickedOptionIndex = -1;
            ClearQuestions();
            currentQuestionCollectionIndex++;
            DisplayQuestion(currentQuestionCollectionIndex);
        }
    }

     void DisplayQuestion(int id)
    {
        QuestionCollection questionCollection = questionCollections[id];

        RectTransform canvasRect = canvas.GetComponent<RectTransform>();
        float currentY = canvasRect.rect.height / 2 - canvasRect.rect.height * startingYPaddingRatio;
        float currentX = -canvasRect.rect.width / 2 + canvasRect.rect.width * xPaddingRatio;

        questionPrefab.text = questionCollection.question;
        Vector3 questionPos = new Vector3(currentX, currentY, 0);
        questionPrefab.GetComponent<RectTransform>().anchoredPosition = questionPos;

        Instantiate(questionPrefab, transform);

        currentY -= (questionPrefab.GetComponent<RectTransform>().rect.height + canvasRect.rect.height * questionOptionPaddingRatio);
        for (int i = 0; i < questionCollection.possibleAnswers.Count; i++)
        {
            var option = Instantiate(optionPrefab, transform);
            if (i != 0)
                currentY -= canvasRect.rect.height * ypaddingRatio;

            option.text = questionCollection.possibleAnswers[i];
            Vector3 optionPos = new Vector3(currentX, currentY, 0);
            option.GetComponent<RectTransform>().anchoredPosition = optionPos;

            if (questionCollection.correctAnswer == i)
            {
                ////TODO: This most likely detects the collider. Switch it out for mouse click
                CorrectOptionButton cb = option.gameObject.AddComponent<CorrectOptionButton>();
            }
        }
    }

    public void SetClickedOption(int optionIndex)
    {
        clickedOptionIndex = optionIndex;
    }

    void ClearQuestions()
    {
        foreach (Transform child in gameObject.transform)
        {
            Destroy(child.gameObject);
        }
    }
    private List<T> ShuffleList<T>(List<T> inputList)
    {
        System.Random random = new System.Random();
        List<T> shuffledList = new List<T>(inputList);

        int n = shuffledList.Count;
        for (int i = n - 1; i > 0; i--)
        {
            int j = random.Next(0, i + 1);
            T temp = shuffledList[i];
            shuffledList[i] = shuffledList[j];
            shuffledList[j] = temp;
        }

        return shuffledList;
    }
}