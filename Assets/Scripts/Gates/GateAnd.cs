public class GateAnd : Gate
{
   public override void Evaluate()
   {
        output.setState( inputA.getState() && inputB.getState() );
    }
}