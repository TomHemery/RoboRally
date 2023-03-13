public abstract class Instruction
{
    public int instructionPriority = 0;
    public string instructionText = "Instruction";

    public abstract void ExecuteInstruction(Robot target);
}