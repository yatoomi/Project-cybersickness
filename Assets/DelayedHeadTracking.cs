using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class DelayedHeadTracking : MonoBehaviour
{
    public float delay = 0.1f; // Délai en secondes

    private Queue<Vector3> positionQueue = new Queue<Vector3>();
    private Queue<Quaternion> rotationQueue = new Queue<Quaternion>();

    void Update()
    {
        // Liste des appareils connectés
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.Head, devices);

        if (devices.Count == 0)
        {
            //Debug.LogWarning("Aucun appareil VR pour la tête n'est détecté.");
            return;
        }

        // Récupérer le premier appareil (la tête VR)
        InputDevice headDevice = devices[0];

        // Variables pour stocker les données
        Vector3 currentPosition = Vector3.zero;
        Quaternion currentRotation = Quaternion.identity;

        // Tenter de récupérer la position et la rotation
        bool hasPosition = headDevice.TryGetFeatureValue(CommonUsages.devicePosition, out currentPosition);
        bool hasRotation = headDevice.TryGetFeatureValue(CommonUsages.deviceRotation, out currentRotation);

        if (!hasPosition || !hasRotation)
        {
            //Debug.LogWarning("Impossible de récupérer la position ou la rotation de la tête.");
            return;
        }

        // Ajouter les données à la file d'attente
        positionQueue.Enqueue(currentPosition);
        rotationQueue.Enqueue(currentRotation);

        // Vérifier si nous avons atteint le délai spécifié
        float frameDelayCount = delay / Time.deltaTime;
        if (positionQueue.Count > frameDelayCount)
        {
            // Appliquer la position et la rotation retardées à cet objet
            transform.position = positionQueue.Dequeue();
            transform.rotation = rotationQueue.Dequeue();
        }
    }
}
