using UnityEngine;

public class Girar : MonoBehaviour
{
    public float rotationSpeed = 50f;

    // Update is called once per frame
    void Update()
    {
        // Rotacionar o meteoro em torno do eixo Y
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}