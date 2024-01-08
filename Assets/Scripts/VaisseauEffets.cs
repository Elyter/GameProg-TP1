using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // N'oubliez pas d'importer ce module pour utiliser les composants UI


public class VaisseauEffets : MonoBehaviour
{
    private bool bouclierActif = false;

    private Material vaisseauMaterial;

    private bool peutEtreEndommage = true;

    private float tempsSurvie = 0f;
    public Text texteTempsSurvie;

    void Start()
    {
        vaisseauMaterial = GetComponent<Renderer>().material;
    }

    void Update()
    {
        // Ajoutez ici le code pour désactiver le bouclier après un certain temps, par exemple.
        if (bouclierActif)
        {
            DesactiverBouclierApresDuree(3f);  // Remplacez 5f par la durée que vous souhaitez.
        }

        tempsSurvie += Time.deltaTime;

        // Mettez à jour le texte affichant le temps de survie pendant la partie
        if (texteTempsSurvie != null)
        {
            texteTempsSurvie.text = "Score : " + tempsSurvie.ToString("F2") + " secondes";
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (peutEtreEndommage)
        {
            if (collision.gameObject.CompareTag("Meteor"))
            {
                FinDuJeu();
            }
        }

        // Ajoutez ici la gestion des collisions avec les bonus (par exemple, activation du bouclier).
        if (collision.gameObject.CompareTag("Bouclier"))
        {
            ActiverBouclier(10f);  // Remplacez 10f par la durée du bouclier que vous souhaitez.
        }
    }

    void FinDuJeu()
    {
        PlayerPrefs.SetFloat("TempsSurvie", tempsSurvie);
        PlayerPrefs.Save();

        SceneManager.LoadScene("EndGameScene");
    }

    public void ActiverBouclier(float duree)
    {
        bouclierActif = true;
        peutEtreEndommage = false;

        vaisseauMaterial.color = Color.blue;

        Invoke("DesactiverBouclier", duree);
    }

    void DesactiverBouclier()
    {
        bouclierActif = false;
        peutEtreEndommage = true;

        vaisseauMaterial.color = Color.white;
    }

    void DesactiverBouclierApresDuree(float duree)
    {
        Invoke("DesactiverBouclier", duree);
    }
}
