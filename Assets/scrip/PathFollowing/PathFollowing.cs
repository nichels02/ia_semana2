

using UnityEngine;
using System.Collections.Generic;

public class PathFollowing : MonoBehaviour
{
    public List<Transform> pathPoints;
    public Transform currentPoints;
    //public float speed = 5f;
    //public float SpeedRotation = 5f;
    public float arrivalDistance = 0.1f;

    private int currentPointIndex = 0;
    public bool loop;

    public bool IsDrawGizmo;
    public Color ColorGizmoPath;
    public Color ColorGizmoCurrentPoint;
    private void Start()
    {
        currentPoints = pathPoints[0];
    }
    public void NextPoint()
    {
        if (Vector3.Distance(transform.position, pathPoints[currentPointIndex].position) < arrivalDistance)
        {
            // Avanzar al siguiente punto de la ruta
            currentPointIndex++;
            if (loop)
                currentPointIndex = currentPointIndex % pathPoints.Count;
            else
                currentPointIndex = Mathf.Clamp(currentPointIndex, 0, pathPoints.Count - 1);
            currentPoints = pathPoints[currentPointIndex];
        }
    }

    private void OnDrawGizmos()
    {
        if (!IsDrawGizmo) return;
        
        if (currentPoints != null)
        {
            Gizmos.color = ColorGizmoCurrentPoint;
            Gizmos.DrawSphere(currentPoints.position, 0.8f);
        }
        Gizmos.color = ColorGizmoPath;
        for (int i = 0; i < pathPoints.Count-1; i++)
        {
            Gizmos.DrawWireSphere(pathPoints[i].position, 0.5f);

            Gizmos.DrawLine(pathPoints[i].position, pathPoints[i + 1].position);
        }

        Gizmos.DrawWireSphere(pathPoints[pathPoints.Count - 1].position, 0.5f);

    }
    //void Update()
    //{
    //    // Verificar si se ha alcanzado el punto de destino
    //    if (Vector3.Distance(transform.position, pathPoints[currentPointIndex].position) < arrivalDistance)
    //    {
    //        // Avanzar al siguiente punto de la ruta
    //        currentPointIndex++;
    //        if (loop)
    //            currentPointIndex = currentPointIndex % pathPoints.Count;
    //        else
    //            currentPointIndex = Mathf.Clamp(currentPointIndex, 0, pathPoints.Count-1);
    //        //if (currentPointIndex >= pathPoints.Count)
    //        //{
    //        //    // Si se llega al final de la ruta, reiniciar desde el principio
    //        //    currentPointIndex = 0;
    //        //}
    //    }
    //    Vector3 targetDirection = pathPoints[currentPointIndex].position - transform.position;
    //    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(targetDirection.normalized), SpeedRotation * Time.deltaTime);


    //    transform.position += transform.forward * Time.deltaTime * speed;

    //}

}
