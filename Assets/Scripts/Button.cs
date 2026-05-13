using UnityEngine;

public class Button : MonoBehaviour
{
    public LED led;
    public Bit bit;
    public Transform button;

    public bool pressButton()
    {
        if(bit.getState())
        {

            return true;
        }
        else
        {
            return false;
        }
    }
}
