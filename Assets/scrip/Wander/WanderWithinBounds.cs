using UnityEngine;

public class WanderWithinBounds : MonoBehaviour
{
    public Transform boundsObject;
    public float wanderRadius = 5f;
    public float wanderInterval = 1f;
    public float velocity;

    private Vector3 targetPosition;
    private float timer;

    void Start()
    {
        timer = wanderInterval;
        SetNewRandomTarget();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SetNewRandomTarget();
            timer = wanderInterval;
        }

        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * velocity);
    }

    void SetNewRandomTarget()
    {
        if (boundsObject == null)
        {
            Debug.LogError("No bounds object assigned!");
            return;
        }

        Vector3 randomPoint = boundsObject.position + Random.insideUnitSphere * wanderRadius;

        // Ensure the random point is within the bounds object
        Collider boundsCollider = boundsObject.GetComponent<Collider>();
        if (boundsCollider != null)
        {
            if (!boundsCollider.bounds.Contains(randomPoint))
            {
                randomPoint = boundsCollider.ClosestPoint(randomPoint);
                randomPoint.y = 0;
            }
        }

        // Set the target position to the random point
        targetPosition = randomPoint;
    }
}
