using UnityEngine;

public class MoveObjectOnClick : MonoBehaviour
{
    public Camera mainCamera;
    public Transform planeTransform; // Transform del plano sobre el cual se har�n los clics

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform == planeTransform)
            {
                // Obtenemos la posici�n en el plano donde se hizo clic
                Vector3 targetPosition = hit.point;

                // Movemos el objeto hacia esa posici�n
                transform.position = targetPosition;
            }
        }
    }

}
