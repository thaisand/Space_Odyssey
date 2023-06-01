using UnityEngine;

public class MovSenoidal : MonoBehaviour
{

    public float speed; 
    public float amplitude; 
    public float invert;
    Vector3 posStart; 

    public void Start() {
        posStart = transform.position;
    }

    public void FixedUpdate()
    {
        Vector3 pos = transform.position;
        pos += Vector3.left * speed * Time.fixedDeltaTime;
        pos.y = posStart.y + Mathf.Sin(pos.x * 5.0f) * amplitude * invert;
        transform.position = pos;
        
    }
}