public class GateAnd : Gate
{
   public override void Evaluate()
   {
        output = inputA && inputB;
    }
}