using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evade : MonoBehaviour
{
    public Transform target; // El objeto al que queremos llegar
    public float SpeedRotation = 5f;
    public float Speed = 5f; // Velocidad máxima del objeto
    public float CuantoSeRota = 5f; // Velocidad máxima del objeto
    public float cantidadMinimaDeCecania = 5f; // Velocidad máxima del objeto

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetDirection = target.position - transform.position;

        
        if(Vector3.Distance(targetDirection, transform.forward) < cantidadMinimaDeCecania)
        {
            
        }


        transform.position += transform.forward * Time.deltaTime * Speed;
    }
}
