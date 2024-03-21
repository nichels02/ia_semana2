using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour
{
    public Transform target; // El objeto al que queremos llegar
    public float SpeedRotation = 5f;
    public float Speed = 5f; // Velocidad máxima del objeto


    void Start()
    {

    }

    void Update()
    {


        // Calcula la dirección hacia el objetivo
        Vector3 targetDirection = target.position - transform.position;

        // Calcula la distancia al objetivo
        float distance = targetDirection.magnitude;



        // Calcula la fuerza de dirección hacia la velocidad deseada
        //transform.rotation = Quaternion.LookRotation(targetDirection.normalized);

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(targetDirection.normalized), SpeedRotation * Time.deltaTime);


        transform.position += transform.forward * Time.deltaTime * Speed;

    }
}

