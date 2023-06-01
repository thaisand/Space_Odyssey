using UnityEngine;

public class MovLinearPlaneta : MonoBehaviour {
    public float speed = 5f;
    Vector3 startPosition;
    Vector3 direction = Vector3.right;
    Renderer planetRenderer;

    void Start() {
        startPosition = transform.position;
        planetRenderer = GetComponent<Renderer>();
    }

    void Update() {
        // Move o planeta
        transform.Translate(direction * speed * Time.deltaTime);

        // Verifica se o planeta não está visível e reposiciona o objeto vazio
        if (!planetRenderer.isVisible) {
            transform.position = startPosition;
        }
    }
}
