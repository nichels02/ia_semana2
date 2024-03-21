using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evade : MonoBehaviour
{
    public Transform target; 
    public float SpeedRotation = 5f;
    public float Speed = 5f;
    public Vector3 CuantoSeRota;
    public float cantidadMinimaDeCecania = 5f;
    public float distanciaDeRotacion= 5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    void Update()
    {
        Vector3 targetDirection = target.position - transform.position;
        float elAngulo = Vector3.Angle(targetDirection, transform.forward);
        Vector3 Rotacion = transform.rotation.eulerAngles + CuantoSeRota;

        // Si el ángulo es menor que la cantidad mínima y la distancia es menor que la distancia de rotación
        if (elAngulo < cantidadMinimaDeCecania && targetDirection.magnitude < distanciaDeRotacion)
        {
            print("si");

            // Calcular la nueva rotación deseada sumando la rotación deseada a la rotación actual
            Quaternion nuevaRotacion = Quaternion.Euler(Rotacion);

            // Aplicar la rotación utilizando Lerp para suavizar la rotación
            transform.rotation = Quaternion.Lerp(transform.rotation, nuevaRotacion, SpeedRotation * Time.deltaTime);
        }

        transform.position += transform.forward * Time.deltaTime * Speed;
    }





}
