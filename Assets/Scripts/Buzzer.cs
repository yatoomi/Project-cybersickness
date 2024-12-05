using UnityEngine;

public class Buzzer : MonoBehaviour
{
    public Timer timer;
    public Material unclickedMaterial;
    public Material clickedMaterial;

    private bool isClicked;
    private bool isBuzzed;
    private MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        isClicked = false;
        isBuzzed = false;
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = unclickedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        if (isClicked)
        {
            if (timer.IsStoped())
            {
                if (timer.StartTimer())
                    Buzz();
            }
            else Buzz();
            isClicked = false;
        }

        if (timer.IsReset())
        {
            isBuzzed = false;
            meshRenderer.material = unclickedMaterial;
        }
    }

    public void Clicked()
    {
        if (!isBuzzed)
            isClicked = true;
    }

    private void Buzz()
    {
        timer.GetScore().Increment();
        meshRenderer.material = clickedMaterial;
        isBuzzed = true;
    }
}
