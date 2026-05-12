public class GateNand : Gate
{
   public override void Evaluate()
   {
      output = !(inputA && inputB);
   }
}