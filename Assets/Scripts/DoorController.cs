using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Transform doorBody;

    public Transform openPosition;
    public Transform closedPosition;

    [Header("State")]
    public bool isOpened;
    public bool isClosed = true;

    private bool moving;
    private bool opening;

    [Tooltip("Tiempo en segundos que tarda")]
    public float movementTime = 2f;

    private float movementSpeed;

    private Vector3 targetPosition;

    void Start()
    {
        float distance = Vector3.Distance(
            openPosition.position,
            closedPosition.position
        );

        movementSpeed = distance / movementTime;

        targetPosition = closedPosition.position;
    }

    void Update()
    {
        if (!moving)
            return;

        doorBody.position = Vector3.MoveTowards(
            doorBody.position,
            targetPosition,
            movementSpeed * Time.deltaTime
        );

        if (Vector3.Distance(
            doorBody.position,
            targetPosition) < 0.01f)
        {
            doorBody.position = targetPosition;

            moving = false;

            if (opening)
            {
                isOpened = true;
                isClosed = false;
            }
            else
            {
                isOpened = false;
                isClosed = true;
            }
        }
    }

    public void Open()
    {
        if (moving || isOpened)
            return;

        targetPosition = openPosition.position;

        moving = true;
        opening = true;

        isOpened = false;
        isClosed = false;
    }

    public void Close()
    {
        if (moving || isClosed)
            return;

        targetPosition = closedPosition.position;

        moving = true;
        opening = false;

        isOpened = false;
        isClosed = false;
    }
}