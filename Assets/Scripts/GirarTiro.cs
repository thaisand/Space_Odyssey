using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirarTiro : MonoBehaviour
{

    [SerializeField]
    private float velocidade = 30.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,velocidade * Time.deltaTime);
    }
}
