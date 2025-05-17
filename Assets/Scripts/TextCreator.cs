using System.Collections;
using UnityEngine;

public class TextCreator : MonoBehaviour
{
    public TMPro.TMP_Text viewText; // Non-static for better object handling
    public static bool runTextPrint;
    public static int charCount;
    [SerializeField] private string transferText;
    [SerializeField] private int internalCount;

    void Start()
    {
        viewText = GetComponent<TMPro.TMP_Text>();
        if(viewText == null)
        {
            Debug.LogError("TMP_Text component not found on this GameObject.");
        }
    }

    void Update()
    {
        internalCount = charCount;
        charCount = viewText.text.Length;

        if (runTextPrint == true)
        {
            runTextPrint = false;
            transferText = viewText.text;
            viewText.text = "";
            StartCoroutine(RollText());
        }
    }

    IEnumerator RollText()
    {
        foreach (char c in transferText)
        {
            viewText.text += c;
            yield return new WaitForSeconds(0.03f);
        }
    }
}



