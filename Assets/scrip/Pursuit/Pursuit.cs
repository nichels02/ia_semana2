using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursuit : MonoBehaviour
{
    public MovimientoBasico target; // El objetivo al que seguir
    public float velocidad = 5f; // Velocidad de movimiento del agente
    public float maxPredictTime = 2f; // Tiempo máximo de predicción del objetivo

    void Update()
    {
        // Calcular la dirección hacia el objetivo
        Vector3 direccion = target.transform.position - transform.position;

        // Calcular el tiempo de predicción basado en la velocidad relativa
        float predictTime = Mathf.Clamp(direccion.magnitude / velocidad, 0f, maxPredictTime);

        // Calcular la posición futura del objetivo
        Vector3 targetPosition = target.transform.position + target.direccion * predictTime;

        // Calcular la dirección hacia la posición futura del objetivo
        Vector3 moveDirection = (targetPosition - transform.position).normalized;

        // Mover el agente hacia la posición futura del objetivo
        transform.position += moveDirection * velocidad * Time.deltaTime;

        // Rotar el agente hacia la dirección del movimiento
        if (moveDirection != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = rotation;
        }
    }
}
