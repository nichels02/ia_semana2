using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoBasico : MonoBehaviour
{
    public float Speed;
    public Vector3 direccion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.W))
            {
                print("w");
                transform.position += transform.forward * Time.deltaTime * Speed;
                direccion = transform.forward * Speed;
            }
            if (Input.GetKey(KeyCode.S))
            {
                print("s");
                transform.position += transform.forward * Time.deltaTime * -Speed;
                direccion = -transform.forward * Speed;
            }
            if (Input.GetKey(KeyCode.D))
            {
                print("d");
                transform.position += transform.right * Time.deltaTime * Speed;
                direccion = transform.right * Speed;
            }
            if (Input.GetKey(KeyCode.A))
            {
                print("a");
                transform.position += transform.right * Time.deltaTime * -Speed;
                direccion = -transform.right * Speed;
            }
        }
        else
        {
            direccion = Vector3.zero;
        }
        
    }
}
