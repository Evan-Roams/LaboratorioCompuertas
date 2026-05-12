using System;
using UnityEngine;

public class Bit : MonoBehaviour
{
    private bool state;

    public bool getState()
    {
        return state;
    }

    public void setState(bool set)
    {
        state = set;
    }

    public void toggleState()
    {
        state = !state;
    }
}
