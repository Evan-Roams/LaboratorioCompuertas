using UnityEngine;

public class LED : MonoBehaviour
{
    public Bit bit;
    public Renderer ledRenderer;
    public Material trueMaterial;
    public Material falseMaterial;

    void Update()
    {
        if (bit.getState())
        {
            ledRenderer.material = trueMaterial;
        }
        else
        {
            ledRenderer.material = falseMaterial;
        }
        
    }

}