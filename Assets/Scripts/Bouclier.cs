using UnityEngine;

public class Bouclier : MonoBehaviour
{
    // Ajoutez d'autres variables si nécessaire

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Vaisseau"))
        {
            // Gérer la collision avec le vaisseau (bouclier touché)
            DesactiverBouclier();
        }
    }

    void DesactiverBouclier()
    {
        // Ajoutez ici le code pour désactiver le bouclier (par exemple, désactivez le GameObject)
        gameObject.SetActive(false);
    }
}
