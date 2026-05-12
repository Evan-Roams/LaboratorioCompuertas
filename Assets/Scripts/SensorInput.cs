using System.Collections;
using UnityEngine;

public class SensorInput : MonoBehaviour
{
    public Bit signal;

    public void ActivateSignal()
    {
        StartCoroutine(Pulse());
    }

    IEnumerator Pulse()
    {
        signal.setState(true);

        yield return new WaitForSeconds(0.2f);

        signal.setState(false);
    }
}