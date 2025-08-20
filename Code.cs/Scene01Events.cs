using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene01Events : MonoBehaviour
{
    public GameObject fadeScreenIn;
    public GameObject charKasumi;
    public GameObject charHaruka;
    public GameObject textBox;
    [SerializeField] AudioSource girlSigh;
    [SerializeField] AudioSource girlGasp;
    [SerializeField] string textToSpeak;
    [SerializeField] int currentTextLength;
    [SerializeField] int textLength;
    [SerializeField] GameObject mainTextObject; // corrected casing of the variable name
    [SerializeField] GameObject nextButton;
    [SerializeField] int eventPos = 0;
    [SerializeField] GameObject charName;

    void Update()
    {
        textLength = TextCreator.charCount; // corrected the typo, changed 'textlength' to 'textLength'
    }

    void Start()
    {
        StartCoroutine(EventStarter());
    }

    IEnumerator EventStarter()
    {
        //event 0
        yield return new WaitForSeconds(2);
        fadeScreenIn.SetActive(false);
        charKasumi.SetActive(true);
        yield return new WaitForSeconds(2);
        // Text function will go here in future tutorial
        mainTextObject.SetActive(true); // corrected casing of the variable name
        textToSpeak = "I wonder where Levi has got to. She was supposed to be here."; // corrected "supoosed" typo
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
         girlSigh.Play();
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
        eventPos = 1;
    }   
    
    IEnumerator EventOne()
     {
        // event 1
        nextButton.SetActive(false);
        charHaruka.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Levi";
        textToSpeak = "I was hiding over in the corner.";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        girlGasp.Play();
        nextButton.SetActive(true);
        eventPos = 2;
    }

    public void NextButton()
    {
        if (eventPos == 1)
        {
            StartCoroutine(EventOne());
        }
    }


}



