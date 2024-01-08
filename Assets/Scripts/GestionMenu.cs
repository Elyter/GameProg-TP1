using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionMenu : MonoBehaviour
{
    public void ChargerSceneJeu()
    {
        SceneManager.LoadScene("GameScene"); // Remplacez "NomDeVotreSceneDeJeu" par le nom de votre scène de jeu.
    }

    public void QuitterJeu()
    {
        Application.Quit();
    }

    public void Replay()
    {
        SceneManager.LoadScene("GameScene");
    }
}
