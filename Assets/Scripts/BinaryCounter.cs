using UnityEngine;
using TMPro;

public class BinaryCounter : MonoBehaviour
{
    [Header("LEDS")]
    public LED[] leds;

    [Header("MATERIALS")]
    public Material onMaterial;
    public Material offMaterial;

    [Header("UI")]
    public TMP_Text counterText;
    public Color limitColor;
    public Color outLimitColor;

    [Header("LIMITS")]
    public int maxPeople = 15;

    public bool IsFull => GetDecimalValue() >= maxPeople;

    void Update()
    {
        UpdateVisuals();
    }

    // =========================
    // INCREMENT
    // =========================

    public void Increment()
    {
        if (IsFull)
            return;

        for (int i = 0; i < leds.Length; i++)
        {
            bool currentState = leds[i].bit.getState();

            if (!currentState)
            {
                leds[i].bit.setState(true);
                break;
            }
            else
            {
                leds[i].bit.setState(false);
            }
        }
    }

    // =========================
    // DECREMENT
    // =========================

    public void Decrement()
    {
        if (GetDecimalValue() <= 0)
            return;

        for (int i = 0; i < leds.Length; i++)
        {
            bool currentState = leds[i].bit.getState();

            if (currentState)
            {
                leds[i].bit.setState(false);
                break;
            }
            else
            {
                leds[i].bit.setState(true);
            }
        }
    }

    // =========================
    // DECIMAL VALUE
    // =========================

    public int GetDecimalValue()
{
    int value = 0;

    for (int i = 0; i < leds.Length; i++)
    {
        if(leds[i].bit.getState())
        {
            value += 1 << i;
        }
    }

    return value;
}

    // =========================
    // VISUALS
    // =========================

    void UpdateVisuals()
    {
        if (counterText)
        {
            counterText.text =GetDecimalValue().ToString();
            if (GetDecimalValue() >= maxPeople)
            {
                counterText.color = outLimitColor;
            }
            else
            {
                counterText.color = limitColor;
            }
        }
    }
}