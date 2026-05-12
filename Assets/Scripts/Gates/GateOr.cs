public class GateOr : Gate
{
   public override void Evaluate()
   {
      output.setState( inputA.getState() || inputB.getState() );
   }
}