using UnityEngine;

public class GateToGateConnector : MonoBehaviour
{
    public Gate inputGate;
    public Gate outputGate;

    public bool isOutputPrimary;

    private LineRenderer line;

    [Header("Colors")]
    public Color onColor = Color.green;
    public Color offColor = Color.red;

    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (!inputGate || !outputGate)
        {
            Debug.LogError("error: any gate in connector is null");
            return;
        }

        // TRANSMITIR SEÑAL
        if (isOutputPrimary)
        {
            outputGate.inputA = inputGate.output;
        }
        else
        {
            outputGate.inputB = inputGate.output;
        }

        DrawLine();
        UpdateVisual();
    }

    void DrawLine()
    {
        if(line == null) 
        {
            return;
        }

        Vector3 startPos = inputGate.outputPoint.position;

        Vector3 endPos;

        if(isOutputPrimary)
        {
            endPos = outputGate.inputPointA.position;
        }
        else
        {
            endPos = outputGate.inputPointB.position;
        }

        line.SetPosition(0, startPos);
        line.SetPosition(1, endPos);
    }

    void UpdateVisual()
    {
        if(line == null) return;

        Color currentColor = inputGate.output ? onColor : offColor;

        line.startColor = currentColor;
        line.endColor = currentColor;

        line.material.color = currentColor;
    }
}