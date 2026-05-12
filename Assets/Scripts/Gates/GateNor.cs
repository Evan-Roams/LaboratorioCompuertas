public class GateNor : Gate
{
   public override void Evaluate()
   {
      output = !(inputA || inputB);
   }
}