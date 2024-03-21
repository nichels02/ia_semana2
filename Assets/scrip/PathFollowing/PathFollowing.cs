

using UnityEngine;
using System.Collections.Generic;

public class PathFollowing : MonoBehaviour
{
    public List<Transform> pathPoints;
    public float speed = 5f;
    public float arrivalDistance = 0.1f;

    private int currentPointIndex = 0;

    void Update()
    {
        // Verificar si se ha alcanzado el punto de destino
        if (Vector3.Distance(transform.position, pathPoints[currentPointIndex].position) < arrivalDistance)
        {
            // Avanzar al siguiente punto de la ruta
            currentPointIndex++;
            if (currentPointIndex >= pathPoints.Count)
            {
                // Si se llega al final de la ruta, reiniciar desde el principio
                currentPointIndex = 0;
            }
        }

        // Moverse hacia el punto actual de la ruta
        MoveTowards(pathPoints[currentPointIndex].position);
    }

    void MoveTowards(Vector3 targetPosition)
    {
        // Calcular la dirección hacia el punto de destino
        Vector3 direction = (targetPosition - transform.position).normalized;

        // Moverse en la dirección calculada con la velocidad especificada
        transform.position += direction * speed * Time.deltaTime;

        // Rotar hacia la dirección del movimiento (opcional)
        transform.rotation = Quaternion.LookRotation(direction);
    }
}
