using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private TextMeshPro text;
    private int compter;

    // Start is called before the first frame update
    void Start()
    {
        compter = 0;
        text = GetComponent<TextMeshPro>();
        text.SetText(" 0");
    }

    public void Increment()
    {
        compter++;
        text.SetText(compter.ToString("00"));
    }

    public void Reset()
    {
        compter = 0;
        text.SetText(" 0");
    }
}
