/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAvoidance : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float Speed;
    [SerializeField] float RotationSpeed;
    [SerializeField] float distancia;
    public Vector3 CuantoSeRota;
    bool EstaEvitando;
    float time = 0;
    [SerializeField] float timeMax;
    [SerializeField] float timeMax2;
    RaycastHit elRaycast;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetDirection = target.position - transform.position;
        if (Physics.Raycast(transform.position, targetDirection, out elRaycast, distancia))
        {
            time = 0;
            EstaEvitando = true;
            Quaternion nuevaRotacion = Quaternion.Euler(transform.rotation.eulerAngles + CuantoSeRota);
            transform.rotation = Quaternion.Lerp(transform.rotation, nuevaRotacion, RotationSpeed * Time.deltaTime);
        }
        else if (EstaEvitando)
        {
            time += Time.deltaTime;
            Quaternion nuevaRotacion = Quaternion.Euler(transform.rotation.eulerAngles + CuantoSeRota);
            transform.rotation = Quaternion.Lerp(transform.rotation, nuevaRotacion, RotationSpeed * Time.deltaTime);
            if (time > timeMax)
            {
                EstaEvitando = false;
                time = 0;
            }

        }
        else if(time > timeMax2)
        {
            time += Time.deltaTime;
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(targetDirection.normalized), RotationSpeed * Time.deltaTime);
        }
        transform.position += transform.forward * Time.deltaTime * Speed;
    }
}

*/

using UnityEngine;

public class ObstacleAvoidance : MonoBehaviour
{
    public Transform target; // Objeto al que seguir
    public float movementSpeed = 5f; // Velocidad de movimiento
    public float rotationSpeed = 5f; // Velocidad de movimiento
    public float avoidanceForce = 10f; // Fuerza de evitación
    public float maxAvoidanceDistance = 5f; // Distancia máxima para detectar obstáculos

    private void Update()
    {
        AvoidObstacles();
    }

    private void Move()
    {
        // Si hay un objetivo para seguir, mover hacia él
        if (target != null)
        {
            // Calcular la dirección hacia el objetivo
            Vector3 targetDirection = target.position - transform.position;
            targetDirection.y = 0f; // Restringir la rotación solo al plano XZ

            // Rotar hacia el objetivo
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * 360f);

            // Mover hacia adelante
            transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
        }
    }



    private void AvoidObstacles()
    {
        RaycastHit hit;

        // Verificar si hay un obstáculo adelante
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxAvoidanceDistance))
        {
            // Calcular una dirección de rotación aleatoria para evitar el obstáculo
            Vector3 randomDirection = Vector3.up + Random.insideUnitSphere * 0.5f;
            randomDirection.y = 0f; // Asegurarse de que la rotación solo se aplique en el plano XZ

            // Rotar gradualmente hacia la dirección aleatoria para evitar el obstáculo
            //Quaternion targetRotation = Quaternion.LookRotation(randomDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(randomDirection), rotationSpeed * Time.deltaTime);

            //transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
        }
        else
        {
            Move();
        }
    }


    /*
    private void AvoidObstacles()
    {
        RaycastHit hit;

        // Verificar si hay un obstáculo adelante
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxAvoidanceDistance))
        {
            // Calcular la dirección de evitación
            Vector3 avoidanceDirection = Vector3.Normalize(transform.position - hit.point);

            // Aplicar la fuerza de evitación

            transform.Translate(avoidanceDirection * avoidanceForce * Time.deltaTime);
        }
        else
        {
            Move();
        }
    }
    */
}
