using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gameplay : MonoBehaviour
{
    //script data

    string SallyA = "Acknowledge her and let her in.";
    string SallyB = "Refuse her on the spot.";
    string SallyC = "Ask for identification.";



    string SallyReplyA = "This is a potential threat because we do not know if her daughter really goes to this school. There can be ill intent. Try again.";
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





    [SerializeField]
    public TextMeshProUGUI targetTextMesh;
    public TextMeshProUGUI buttonAText;
    public TextMeshProUGUI buttonBText;
    public TextMeshProUGUI buttonCText;
public Button buttonA;
public Button buttonB;
public Button buttonC;

    private int conversationState = 0;

    void Start()
{
    UpdateConversation(0);
    buttonA.onClick.AddListener(() => OnButtonClick(0));
    buttonB.onClick.AddListener(() => OnButtonClick(1));
    buttonC.onClick.AddListener(() => OnButtonClick(2));
}



    void UpdateConversation(int state)
    {
        conversationState = state;

        switch (conversationState)
        {
            case 0:
                buttonAText.text = SallyA;
                buttonBText.text = SallyB;
                buttonCText.text = SallyC;
                targetTextMesh.text = "Hi, I'm here to pick up my daugther. She forgot her homework and I need to give it to her.";
                break;
            
        }
    }


    public void OnButtonClick(int buttonIndex)
    {
        switch (conversationState)
        {
            case 0:
                switch (buttonIndex)
                {
                    case 0:
                        targetTextMesh.text = SallyReplyA;
                        break;
                    case 1:
                        targetTextMesh.text = SallyReplyB;
                        break; 
                    case 2:
                        targetTextMesh.text = SallyReplyC;
                        buttonAText.text=SallyCA;
                        buttonBText.text=SallyCB;
                        buttonCText.text=SallyCC;
                        conversationState++;
                        break;
                }
                break;
            case 1:
                switch (buttonIndex)
                {
                    case 0:
                        targetTextMesh.text = SallyReplyCA;
                        break;
                    case 1:
                        targetTextMesh.text = SallyReplyCB;
                        break;
                    case 2:
                        targetTextMesh.text = SallyReplyCC;
                        buttonAText.text=SallyCCA;
                        buttonBText.text=SallyCCB;
                        buttonCText.text=SallyCCC;
                        conversationState++;
                        break;
                }
                break;
            case 2:
                switch (buttonIndex)
                {
                    case 0:
                        targetTextMesh.text = SallyReplyCCA;
                        break;
                    case 1:
                        targetTextMesh.text = SallyReplyCCB;
                        break;
                    case 2:
                        targetTextMesh.text = SallyReplyCCC;
                        break;
                }
                break;
        }
    }

}
