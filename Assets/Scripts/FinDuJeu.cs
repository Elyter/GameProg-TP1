using UnityEngine;
using UnityEngine.UI; // N'oubliez pas d'importer ce module pour utiliser les composants UI

public class FinDuJeu : MonoBehaviour
{
    public Text texteTempsSurvieFin; // Référence au texte UI pour afficher le temps de survie

    void Start()
    {
        // Récupérez le temps de survie depuis PlayerPrefs ou d'autres méthodes
        float tempsSurvie = PlayerPrefs.GetFloat("TempsSurvie", 0f);

        // Affichez le temps de survie sur l'écran de fin
        if (texteTempsSurvieFin != null)
        {
            texteTempsSurvieFin.text = "Temps de survie : " + tempsSurvie.ToString("F2") + " secondes";
        }
    }

    // Ajoutez d'autres logiques de l'écran de fin ici
}
