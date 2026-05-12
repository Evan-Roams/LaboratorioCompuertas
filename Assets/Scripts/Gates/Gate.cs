using System.Collections.Generic;
using UnityEngine;

public abstract class Gate : MonoBehaviour
{
    
    [Header("Inputs")]
    public Bit inputA;
    public Bit inputB;

    [Header("Output")]
    public Bit output;

    [Header("Visual")]
    public List<Renderer> renderers = new List<Renderer>();

    public Material onMaterial;
    public Material offMaterial;

    protected virtual void Update()
    {
        Evaluate();
        UpdateVisual();
    }

    public abstract void Evaluate();

    void UpdateVisual()
    {
        if(renderers.Count < 1) return;

        foreach (Renderer rend in renderers)
        {
            rend.material = output.getState() ? onMaterial : offMaterial;
        }
        
    }
}