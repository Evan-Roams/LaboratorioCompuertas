using UnityEngine;

public class Button : MonoBehaviour
{
    public LED led;
    public Bit bit;
    public Transform button;
    public DoorController door;
    public bool forOpen;

    public bool pressButton()
    {
        if(bit.getState())
        {
            if (forOpen)
            {
                door.Open();
            }

        }
        else
        {
            return false;
        }
        return false;
    }
}
