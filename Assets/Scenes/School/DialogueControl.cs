using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueControl : MonoBehaviour
{

    public static string currentPOS = "Sally";

    public string SallyA = "Acknowledge her and let her in.";
    public string SallyB = "Refuse her on the spot.";
    public string SallyC = "Ask for identification.";


    
    public string SallyReplyA = "This poses a potential threat because we do not know if her daughter really goes to this school. There can be ill intent. Try again.";
    public string SallyReplyB = "This may be a real parent. Also refusing her on the spot is a little rude. Try again.";

    public string SallyReplyC = "Oh, I must have left it in the car. Can't you just let me in? I promise it will be real quick.";

    public string SallyCA = "Understand her position and let her in.";
    public string SallyCB = "Refuse her on the spot.";
    public string SallyCC = "Ask her to get the identification.";


    public string SallyReplyCA = "Again, we do not know if her daughter really goes to this school. There can be ill intent. Try again.";
    public string SallyReplyCB = "This may be a real parent. Try to dig a little deeper with her intent.";
    public string SallyReplyCC = "This is ridiculous! I don't have time for this! The other guards would have let me in! I personally know the principal!";


    public string SallyCCA = "Begin to shout back.";
    public string SallyCCB = "Ignore her.";
    public string SallyCCC = "De-escalate the situation.";

    public string SallyReplyCCA = "At this point its important to try to de-escalate the situation. Try again.";
    public string SallyReplyCCB = "She may force her way in when you are not looking. Try again.";
    public string SallyReplyCCC = "Correct, try to de-escalate the situation and solve the matter without causing a disturbance. " +
        " It is important to verify identification, and take note of suspicious activity.";



    public Transform Atext;
    public Transform Btext;
    public Transform Ctext;

    public static int points = 0;

    public Transform AIresponse;

    // Start is called before the first frame update
    void Start()
    {
        Atext.GetComponent<TextMesh> ().text = SallyA;
        Btext.GetComponent<TextMesh> ().text = SallyB;
        Ctext.GetComponent<TextMesh> ().text = SallyC;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //how the users select/traverse the dialogue is based on which gameObject they selcted.
    public void OnMouseDown()
    {
        Debug.Log("Testing");

        currentPOS += gameObject.name;

        while(currentPOS != SallyC && currentPOS != SallyCC && currentPOS != SallyCCC) {
            if (currentPOS == SallyA)
            {
                Atext.GetComponent<TextMesh>().text = SallyA;
                Btext.GetComponent<TextMesh>().text = SallyB;
                Ctext.GetComponent<TextMesh>().text = SallyC;

                AIresponse.GetComponent<TextMesh>().text = SallyReplyA;
                currentPOS = "Sally";//here we are resetting the the currentPOS to store nothing. if we did not reset it, it will hold the SallyA
            }

            if (currentPOS == SallyB)
            {
                Atext.GetComponent<TextMesh>().text = SallyA;
                Btext.GetComponent<TextMesh>().text = SallyB;
                Ctext.GetComponent<TextMesh>().text = SallyC;

                AIresponse.GetComponent<TextMesh>().text = SallyReplyB;
                currentPOS = "Sally";//here we are resetting the the currentPOS to store nothing
            }

            if (currentPOS == SallyC)
            {
                Atext.GetComponent<TextMesh>().text = SallyA;
                Btext.GetComponent<TextMesh>().text = SallyB;
                Ctext.GetComponent<TextMesh>().text = SallyC;

                AIresponse.GetComponent<TextMesh>().text = SallyReplyC;

            }



            if (currentPOS == SallyCA)
            {
                Atext.GetComponent<TextMesh>().text = SallyCA;
                Btext.GetComponent<TextMesh>().text = SallyCB;
                Ctext.GetComponent<TextMesh>().text = SallyCC;

                AIresponse.GetComponent<TextMesh>().text = SallyReplyCA;
                currentPOS = "SallyC"; 
            }

            if (currentPOS == SallyCB)
            {
                Atext.GetComponent<TextMesh>().text = SallyCA;
                Btext.GetComponent<TextMesh>().text = SallyCB;
                Ctext.GetComponent<TextMesh>().text = SallyCC;

                AIresponse.GetComponent<TextMesh>().text = SallyReplyCB;
                currentPOS = "SallyC";
            }

            if (currentPOS == SallyCC)
            {
                Atext.GetComponent<TextMesh>().text = SallyCA;
                Btext.GetComponent<TextMesh>().text = SallyCB;
                Ctext.GetComponent<TextMesh>().text = SallyCC;

                AIresponse.GetComponent<TextMesh>().text = SallyReplyCC;

            }


            if (currentPOS == SallyCCA)
            {
                Atext.GetComponent<TextMesh>().text = SallyCCA;
                Btext.GetComponent<TextMesh>().text = SallyCCB;
                Ctext.GetComponent<TextMesh>().text = SallyCCC;

                AIresponse.GetComponent<TextMesh>().text = SallyReplyCCA;
                currentPOS = "SallyCC";
            }

            if (currentPOS == SallyCCB)
            {
                Atext.GetComponent<TextMesh>().text = SallyCCA;
                Btext.GetComponent<TextMesh>().text = SallyCCB;
                Ctext.GetComponent<TextMesh>().text = SallyCCC;

                AIresponse.GetComponent<TextMesh>().text = SallyReplyCCB;
                currentPOS = "SallyCC";
            }

            if (currentPOS == SallyCCC)
            {
                Atext.GetComponent<TextMesh>().text = SallyCCA;
                Btext.GetComponent<TextMesh>().text = SallyCCB;
                Ctext.GetComponent<TextMesh>().text = SallyCCC;

                AIresponse.GetComponent<TextMesh>().text = SallyReplyCCC;

            }

            break;
        }

        


    }
}
