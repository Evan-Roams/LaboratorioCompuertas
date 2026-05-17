using UnityEngine;
using UnityEngine.AI;

public class NPCPathFollower : MonoBehaviour
{
    public Animator anim;
    public Transform[] startPath;

    public Transform[] truePath;
    public Transform[] falsePath;
    public ForDoorButton forDoorButton;
    private bool waitingDecision = false;

    private bool? decisionResult = null;

    private NavMeshAgent agent;

    private int currentPoint = 0;

    private Transform[] currentPath;

    private bool choosingRoute = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        agent.speed = 2f;

        currentPath = startPath;

        GoToNextPoint();
    }

    void Update()
    {
        anim.SetBool("isWalking", agent.velocity.magnitude > 0.1f);
        if (waitingDecision)
        return;

        if (agent.pathPending)
            return;

        // Si llegó al punto
        if (agent.remainingDistance <= 0.2f)
        {
            currentPoint++;

            // ¿Terminó el camino actual?
            if (currentPoint >= currentPath.Length)
            {
                // Si aún no decidió ruta
                if (!choosingRoute)
                {
                    choosingRoute = true;

                    waitingDecision = true;

                    agent.isStopped = true;

                    Debug.Log("Esperando decisión...");
                }
            }
            else
            {
                GoToNextPoint();
            }
        }
    }

    void GoToNextPoint()
    {
        agent.SetDestination(currentPath[currentPoint].position);
    }

    bool MiFuncionDecision()
    {
        // Aquí tu lógica

        // ejemplo random
        return Random.value > 0.5f;
    }

    public void SetDecision(bool result)
    {
        decisionResult = result;

        waitingDecision = false;

        agent.isStopped = false;

        if (decisionResult == true)
        {
            currentPath = truePath;
        }
        else
        {
            currentPath = falsePath;
        }

        currentPoint = 0;

        GoToNextPoint();
    }
}