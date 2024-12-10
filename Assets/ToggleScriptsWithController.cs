using UnityEngine;
using UnityEngine.XR;

public class ToggleScriptsWithController : MonoBehaviour
{
    public MonoBehaviour script1; // Référence au premier script
    public MonoBehaviour script2; // Référence au deuxième script
    public MonoBehaviour script3; // Référence au troisième script
    public MonoBehaviour script4; // Référence au quatrième script

    private InputDevice controller;

    void Start()
    {
        // Récupérer l'appareil de la main droite (ou gauche si nécessaire)
        controller = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        if (!controller.isValid)
        {
            Debug.LogError("Aucune manette VR détectée pour la main droite !");
        }
    }

    void Update()
    {
        if (!controller.isValid)
            return;

        // Bouton 1 : Activer/désactiver script1
        if (controller.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButton) && primaryButton)
        {
            ToggleScript(script1);
        }

        // Bouton 2 : Activer/désactiver script2
        if (controller.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryButton) && secondaryButton)
        {
            ToggleScript(script2);
        }

        // Bouton 3 : Activer/désactiver script3
        if (controller.TryGetFeatureValue(CommonUsages.gripButton, out bool gripButton) && gripButton)
        {
            ToggleScript(script3);
        }

        // Bouton 4 : Activer/désactiver script4
        if (controller.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerButton) && triggerButton)
        {
            ToggleScript(script4);
        }
    }

    private void ToggleScript(MonoBehaviour script)
    {
        if (script == null)
        {
            Debug.LogWarning("Un script n'est pas assigné !");
            return;
        }

        // Bascule l'état activé/désactivé du script
        script.enabled = !script.enabled;
        Debug.Log($"{script.GetType().Name} est maintenant {(script.enabled ? "activé" : "désactivé")}");
    }
}
