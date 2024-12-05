using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabbingTheAirProvider : LocomotionProvider
{
    [SerializeField]
    InputActionProperty m_GrabButton;
    public InputActionProperty GrabButton
    {
        get => m_GrabButton;
        set => m_GrabButton = value;
    }

    // Use this for initialization
    void Start()
    {
        m_GrabButton.action.started += ctx => {
            Debug.Log("Grab button pressed!");
        };
        m_GrabButton.action.performed += ctx => {
            Debug.Log("Grab button released!");
        };
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: implement the Grabbing-the-air technique
    }
}
