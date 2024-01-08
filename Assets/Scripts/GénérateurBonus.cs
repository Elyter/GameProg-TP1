using UnityEngine;

public class GenerateurBouclier : MonoBehaviour
{
    public GameObject BouclierPrefab;
    public float intervalleGeneration = 2f;

    void Start()
    {
        // Lancer la génération de boucliers à intervalles réguliers
        InvokeRepeating("GenererBouclier", 0f, intervalleGeneration);
    }

    void GenererBouclier()
    {
        // Créer un bouclier à une position aléatoire en haut de l'écran
        Vector3 positionGenerateur = transform.position;
        positionGenerateur.x = Random.Range(-Camera.main.orthographicSize, Camera.main.orthographicSize);
        GameObject nouveauBouclier = Instantiate(BouclierPrefab, positionGenerateur, Quaternion.identity);

        // Vous pouvez ajouter d'autres logiques ici pour configurer le bouclier si nécessaire
    }
}
