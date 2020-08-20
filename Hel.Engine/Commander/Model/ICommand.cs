namespace Hel.Engine.Commander.Model
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
        abstract void Execute();

        abstract void Undo();
    }

    public interface ICommand<T> : ICommand
    {
        T Payload { get; set; } 
    }
}
