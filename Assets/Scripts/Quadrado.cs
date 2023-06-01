using UnityEngine;

public class Quadrado : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float upperLimit = 5f;
    public float lowerLimit = -5f;

    private bool movingUp = true;

    private void Update()
    {
        if (movingUp)
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            if (transform.position.y >= upperLimit)
            {
                movingUp = false;
            }
        }
        else
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
            if (transform.position.y <= lowerLimit)
            {
                movingUp = true;
            }
        }
    }
}
