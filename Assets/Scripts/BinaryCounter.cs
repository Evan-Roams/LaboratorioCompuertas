using UnityEngine;

public class BinaryCounter : MonoBehaviour
{
    public bool Q0;
    public bool Q1;
    public bool Q2;

    public void Increment()
    {
        if(!Q0)
        {
            Q0 = true;
        }
        else
        {
            Q0 = false;

            if(!Q1)
            {
                Q1 = true;
            }
            else
            {
                Q1 = false;

                if(!Q2)
                {
                    Q2 = true;
                }
                else
                {
                    Q2 = false;
                }
            }
        }
    }
}