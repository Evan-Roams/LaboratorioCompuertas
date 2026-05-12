using System.Collections;
using UnityEngine;

public class SensorInput : MonoBehaviour
{
    public bool signal;

    public void ActivateSignal()
    {
        StartCoroutine(Pulse());
    }

    IEnumerator Pulse()
    {
        signal = true;

        yield return new WaitForSeconds(0.2f);

        signal = false;
    }
}