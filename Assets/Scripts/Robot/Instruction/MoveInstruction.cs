public class MoveInstruction : Instruction
{
    protected int distance;

    public MoveInstruction(string instructionText, int distance) 
    {
        this.instructionText = instructionText;
        this.distance = distance;
    }

    public override void ExecuteInstruction(Robot target)
    {
        target.TriggerMove(distance);
    }
}
