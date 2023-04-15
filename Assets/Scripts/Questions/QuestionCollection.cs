using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class QuestionCollection : ScriptableObject
{
    public string question;
    public List<string> possibleAnswers;
    public int correctAnswer;
}