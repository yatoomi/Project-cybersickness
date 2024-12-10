using System;
using UnityEngine;

public class RotateOnPressR : MonoBehaviour
{
    Boolean penche = true;
    public float rotation = 10f;
    void Update()
    {
        // Vérifie si la touche "R" est pressée
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Ajoute 10 degrés de rotation sur l'axe X
            if (penche == true) {
                 transform.Rotate(rotation, 0f, 0f);
                 penche = !penche;
                 return;
            }

             if (penche == false) {
             transform.Rotate(-rotation, 0f, 0f);
             penche =! penche;
            return;
             }
        }
    }
}
