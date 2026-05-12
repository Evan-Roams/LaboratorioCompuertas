using System.Collections.Generic;
using UnityEngine;

public abstract class Gate : MonoBehaviour
{
    
    [Header("Inputs")]
    public bool inputA;
    public bool inputB;

    [Header("Output")]
    public bool output;

    [Header("Visual")]
    public List<Renderer> renderers = new List<Renderer>();

    public Material onMaterial;
    public Material offMaterial;

    public SensorInput sensorA;
    public SensorInput sensorB;

    public Transform inputPointA;
    public Transform inputPointB;
    public Transform outputPoint;

    protected virtual void Update()
    {
        if(sensorA != null)
        inputA = sensorA.signal;

        if(sensorB != null)
            inputB = sensorB.signal;

        Evaluate();

        UpdateVisual();
    }

    public abstract void Evaluate();

    void UpdateVisual()
    {
        if(renderers.Count < 1) return;

        foreach (Renderer rend in renderers)
        {
            rend.material = output ? onMaterial : offMaterial;
        }
        
    }
}