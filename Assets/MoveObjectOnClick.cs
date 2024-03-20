using UnityEngine;

public class MoveObjectOnClick : MonoBehaviour
{
    public Camera mainCamera;
    public Transform planeTransform; // Transform del plano sobre el cual se harán los clics
    public float movementSpeed = 5f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform == planeTransform)
            {
                // Obtenemos la posición en el plano donde se hizo clic
                Vector3 targetPosition = hit.point;

                // Movemos el objeto hacia esa posición
                transform.position = targetPosition;
            }
        }
    }

    private void MoveObject(Vector3 targetPosition)
    {
        // Movemos el objeto gradualmente hacia la posición objetivo
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
    }
}
