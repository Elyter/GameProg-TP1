using UnityEngine;

public class GenerateurMeteor : MonoBehaviour
{
    public GameObject MeteorPrefab;
    public float tempsInitialAvantDebutGeneration = 2f;
    public float intervalleMinGeneration = 0.5f;  // Intervalle minimum entre les générations
    public float reductionIntervalle = 0.05f;  // Réduction d'intervalle par seconde
    public float vitesseMin = 3f; // Vitesse minimale des astéroïdes
    public float vitesseMax = 7f;

    private float tempsEcoule = 0f;
    private float tempsTotal = 0f;

    void Update()
    {
        tempsEcoule += Time.deltaTime;
        tempsTotal += Time.deltaTime;

        // Calculer l'intervalle de génération en fonction du temps total écoulé
        float intervalleGeneration = Mathf.Max(intervalleMinGeneration, tempsInitialAvantDebutGeneration - tempsTotal * reductionIntervalle);

        // Générer une météorite à intervalles réguliers
        if (tempsEcoule > intervalleGeneration)
        {
            GenererMeteor();
            tempsEcoule = 0f;  // Réinitialiser le temps écoulé
        }
    }

    void GenererMeteor()
    {
        // Créer une météorite à une position aléatoire sur toute la largeur de l'écran
        float xPosition = Random.Range(Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x, Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x);
        Vector3 positionGenerateur = new Vector3(xPosition, Camera.main.orthographicSize + 1f, 0f);

        GameObject nouvelMeteor = Instantiate(MeteorPrefab, positionGenerateur, Quaternion.identity);

        float vitesseAleatoire = Random.Range(vitesseMin, vitesseMax);

        // Ajouter une force vers le bas pour simuler le mouvement
        Rigidbody2D rigidbodyMeteor = nouvelMeteor.GetComponent<Rigidbody2D>();
        rigidbodyMeteor.velocity = new Vector2(0, -vitesseAleatoire);
    }
}
