public class NotGate : Gate
{
    public override void Evaluate()
    {
        output.setState( !inputA.getState() );
    }
}