using TMPro;
using UnityEngine;

public class FadeFlash : MonoBehaviour
{
    public TextMeshProUGUI textToFlash;
    public float flashSpeed;

    // Update is called once per frame
    void Update()
    {
        AnimateSkipPrompt();
    }

    void AnimateSkipPrompt()
    {
        // Ping-pong alpha between 0 and 1
        float alpha = Mathf.PingPong(Time.time * flashSpeed, 1f);

        Color color = textToFlash.color;
        color.a = alpha;
        textToFlash.color = color;
    }
}