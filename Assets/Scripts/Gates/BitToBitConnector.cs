using UnityEngine;

[ExecuteAlways]
public class BitToBitConnector : MonoBehaviour
{
    public Bit input;
    public Bit output;
    public float size = 0.05f;

    private LineRenderer line;
    public Material onMaterial;
    public Material offMaterial;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 2;
    }
    
    void Update()
    {
        if (!input || !output)
        {
            return;
        }

        output.setState(input.getState());

        DrawLine();
        UpdateVisual();
    }


    void DrawLine()
    {
        if(line == null) 
        {
            return;
        }

        Vector3 startPos = input.transform.position;

        Vector3 endPos = output.transform.position;

        line.SetPosition(0, startPos);
        line.SetPosition(1, endPos);
        line.startWidth = size;
        line.endWidth = size;
    }

    void UpdateVisual()
    {
        if(line == null) return;

        if (input.getState())
        {
            line.material = onMaterial;
        }
        else
        {
            line.material = offMaterial;
        }

        transform.position =  (input.transform.position + output.transform.position) / 2f;

    }


}