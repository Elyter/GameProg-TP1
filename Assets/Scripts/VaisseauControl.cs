using UnityEngine;

public class VaisseauControl : MonoBehaviour
{
    public float vitesseDeplacement = 20f;

    void Update()
    {
        DeplacerVaisseau();
    }

    void DeplacerVaisseau()
    {
        float deplacementHorizontal = Input.GetAxis("Horizontal");
        float deplacementVertical = Input.GetAxis("Vertical");

        // Calcul du déplacement en fonction des axes horizontaux et verticaux
        Vector3 deplacement = new Vector3(deplacementHorizontal, deplacementVertical, 0) * vitesseDeplacement * Time.deltaTime;

        // Mise à jour de la position du vaisseau
        transform.Translate(deplacement);

        // Limitation du vaisseau à l'écran
        Vector3 positionLimite = Camera.main.WorldToViewportPoint(transform.position);
        positionLimite.x = Mathf.Clamp01(positionLimite.x);
        positionLimite.y = Mathf.Clamp01(positionLimite.y);
        transform.position = Camera.main.ViewportToWorldPoint(positionLimite);
    }
}
