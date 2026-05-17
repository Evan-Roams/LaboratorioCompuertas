using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Transform doorBody;

    public Transform openPosition;
    public Transform closedPosition;

    public bool isOpened;
    public bool isClosed = true;

    [Tooltip("Tiempo en segundos que tarda en abrir/cerrar")]
    public float movementTime = 2f;

    private float movementSpeed;

    void Start()
    {
        // Calcula automáticamente la velocidad necesaria
        float distance = Vector3.Distance(openPosition.position, closedPosition.position);

        movementSpeed = distance / movementTime;
    }

    void Update()
    {
        if (isOpened)
        {
            OpenDoor();
        }

        if (isClosed)
        {
            CloseDoor();
        }
    }

    void OpenDoor()
    {
        doorBody.position = Vector3.MoveTowards(
            doorBody.position,
            openPosition.position,
            movementSpeed * Time.deltaTime
        );

        // Cuando llegue al destino
        if (Vector3.Distance(doorBody.position, openPosition.position) < 0.01f)
        {
            doorBody.position = openPosition.position;

            isOpened = false;
        }
    }

    void CloseDoor()
    {
        doorBody.position = Vector3.MoveTowards(
            doorBody.position,
            closedPosition.position,
            movementSpeed * Time.deltaTime
        );

        // Cuando llegue al destino
        if (Vector3.Distance(doorBody.position, closedPosition.position) < 0.01f)
        {
            doorBody.position = closedPosition.position;

            isClosed = false;
        }
    }

    // Funciones públicas para llamar desde otros scripts
    public void Open()
    {
        isOpened = true;
        isClosed = false;
    }

    public void Close()
    {
        isClosed = true;
        isOpened = false;
    }
}
