public class NotGate : Gate
{
    public override void Evaluate()
    {
        output = !inputA;
    }
}