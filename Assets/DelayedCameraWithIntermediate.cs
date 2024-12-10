using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedCameraWithIntermediate : MonoBehaviour
{
    public Transform vrHeadTransform; // Le Transform de la tête (source de données VR)
    public float delay = 0.1f;        // Délai en secondes

    private Vector3 delayedPosition;
    private Quaternion delayedRotation;

    private Queue<Vector3> positionQueue = new Queue<Vector3>();
    private Queue<Quaternion> rotationQueue = new Queue<Quaternion>();

    void Start()
    {
        if (vrHeadTransform == null)
        {
            Debug.LogError("Veuillez assigner le Transform de la tête VR.");
            enabled = false;
            return;
        }

        // Initialisation des files pour gérer le délai
        StartCoroutine(TrackHeadMovement());
    }

    IEnumerator TrackHeadMovement()
    {
        while (true)
        {
            // Enfile la position et la rotation actuelles de la tête
            positionQueue.Enqueue(vrHeadTransform.position);
            rotationQueue.Enqueue(vrHeadTransform.rotation);

            // Si le délai est atteint, défiler les données et appliquer les données retardées
            if (positionQueue.Count > Mathf.CeilToInt(delay / Time.fixedDeltaTime))
            {
                delayedPosition = positionQueue.Dequeue();
                delayedRotation = rotationQueue.Dequeue();
            }

            yield return new WaitForFixedUpdate();
        }
    }

    void Update()
    {
        // Appliquer les positions et rotations retardées
        transform.position = delayedPosition;
        transform.rotation = delayedRotation;
    }
}
