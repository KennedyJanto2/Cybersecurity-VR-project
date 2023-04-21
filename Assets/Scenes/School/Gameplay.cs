using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    //script data
        string SallyA = "Acknowledge her and let her in.";
     string SallyB = "Refuse her on the spot.";
     string SallyC = "Ask for identification.";



    string SallyReplyA = "This poses a potential threat because we do not know if her daughter really goes to this school. There can be ill intent. Try again.";
     string SallyReplyB = "This may be a real parent. Also refusing her on the spot is a little rude. Try again.";

     string SallyReplyC = "Oh, I must have left it in the car. Can't you just let me in? I promise it will be real quick.";

     string SallyCA = "Understand her position and let her in.";
     string SallyCB = "Refuse her on the spot.";
     string SallyCC = "Ask her to get the identification.";


     string SallyReplyCA = "Again, we do not know if her daughter really goes to this school. There can be ill intent. Try again.";
     string SallyReplyCB = "This may be a real parent. Try to dig a little deeper with her intent.";
     string SallyReplyCC = "This is ridiculous! I don't have time for this! The other guards would have let me in! I personally know the principal!";


     string SallyCCA = "Begin to shout back.";
     string SallyCCB = "Ignore her.";
     string SallyCCC = "De-escalate the situation.";

     string SallyReplyCCA = "At this point its important to try to de-escalate the situation. Try again.";
     string SallyReplyCCB = "She may force her way in when you are not looking. Try again.";
     string SallyReplyCCC = "Correct, try to de-escalate the situation and solve the matter without causing a disturbance. " +
        " It is important to verify identification, and take note of suspicious activity.";





    [SerializeField] // Make sure to add this line
    public TextMesh targetTextMesh; // Reference to the TextMesh you want to change

    public void firstAnswerSallyA()
    {
        targetTextMesh.text = SallyA;
    }

    public void firstAnswerSallyB()
    {
        targetTextMesh.text = "Button clASfsafaicked!";
    }

    public void firstAnswerSallyC()
    {
        targetTextMesh.text = "Button clASfsafaicked!";
    }
}
