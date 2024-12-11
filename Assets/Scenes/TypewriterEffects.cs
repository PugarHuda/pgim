using System.Collections;
using UnityEngine;
using UnityEngine.UI; // Menggunakan namespace untuk Text Legacy

public class TypewriterEffectLegacy : MonoBehaviour
{
    [SerializeField] private Text textComponent; // Assign your Legacy Text component here
    [SerializeField] private float typingSpeed = 0.05f; // Speed of typing in seconds

    private Coroutine typingCoroutine;

    public void StartTyping(string message)
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }
        typingCoroutine = StartCoroutine(TypeText(message));
    }

    private IEnumerator TypeText(string message)
    {
        textComponent.text = ""; // Clear the text before starting
        foreach (char letter in message.ToCharArray())
        {
            textComponent.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
