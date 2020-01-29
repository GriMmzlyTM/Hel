namespace Hel.Commander.Model
{
    /// <summary>
    /// Interface for all commands to use. 
    /// Commands provide you with a way to map button presses to commands
    /// Example: BUTTON_SPACE -> JumpCommand
    /// BUTTON_A -> MoveUnitCommand
    /// An instance of these commands is created each time its required and is destroyed after the logic is called.
    /// Commands can either have their own logic, or simply call something else. 
    /// </summary>
    public interface ICommand
    {
        void Execute();

        void Undo();
    }
}
