public class GateOr : Gate
{
   public override void Evaluate()
   {
      output = inputA || inputB;
   }
}