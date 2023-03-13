public class TurnInstruction : Instruction
{
    protected int degrees;

    public TurnInstruction(string instructionText, int degrees)
    {
        this.instructionText = instructionText;
        this.degrees = degrees;
    }

    public override void ExecuteInstruction(Robot target)
    {
        target.Turn(degrees);
    }
}
