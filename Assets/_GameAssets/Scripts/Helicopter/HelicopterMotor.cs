using UnityEngine;

public class HelicopterMotor : MonoBehaviour
{
    Transform targetPoint;
    HelicopterPointHandler pointHandler;
    private void Awake()
    {
        pointHandler = GetComponent<HelicopterPointHandler>();
    }
    private void Update()
    {
        if (targetPoint == null)
            targetPoint = pointHandler.GetRandomVisitPoint();
            float distance = Vector3.Distance(transform.position, targetPoint.position);
        if (distance <= 0.2f)
            targetPoint = null;
        

        if (targetPoint != null)
        {
            Vector3 newVector = Vector3.MoveTowards(transform.position, targetPoint.position, 0.2f);
            transform.position = new Vector3(newVector.x, transform.position.y, newVector.z);
        }
    }
}
