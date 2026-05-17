using System.Collections;
using UnityEngine;

public class Button : MonoBehaviour
{
    public LED led;
    public Bit bit;

    public Transform buttonButton;

    [Header("Animation")]
    public float pressDistance = 0.02f;
    public float pressSpeed = 8f;

    private Vector3 originalLocalPosition;

    private bool isAnimating;

    void Start()
    {
        originalLocalPosition = buttonButton.localPosition;
    }

    public bool PressButton()
    {
        if (bit.getState())
        {
            if (!isAnimating)
            {
                StartCoroutine(ButtonAnimation());
            }

            return true;
        }

        return false;
    }

    IEnumerator ButtonAnimation()
    {
        isAnimating = true;

        Vector3 pressedPosition =
            originalLocalPosition + Vector3.back * pressDistance;

        // Ir hacia atrás
        while (Vector3.Distance(buttonButton.localPosition, pressedPosition) > 0.001f)
        {
            buttonButton.localPosition = Vector3.Lerp(
                buttonButton.localPosition,
                pressedPosition,
                pressSpeed * Time.deltaTime
            );

            yield return null;
        }

        yield return new WaitForSeconds(0.05f);

        // Volver
        while (Vector3.Distance(buttonButton.localPosition, originalLocalPosition) > 0.001f)
        {
            buttonButton.localPosition = Vector3.Lerp(
                buttonButton.localPosition,
                originalLocalPosition,
                pressSpeed * Time.deltaTime
            );

            yield return null;
        }

        buttonButton.localPosition = originalLocalPosition;

        isAnimating = false;
    }
}
