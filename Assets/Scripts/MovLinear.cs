using UnityEngine;

public class MovLinear : MonoBehaviour
{
    [SerializeField]
    private Vector2 direcao;

    [SerializeField]
    private float movVel = 1f;

    private void Update()
    {
        transform.Translate(direcao * (movVel * Time.deltaTime));
    }
}