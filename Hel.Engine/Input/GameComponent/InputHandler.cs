using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Hel.Engine.Input.GameComponent
{
    /// <summary>
    /// Basic inputhandler for executing commands linked to keybindings.
    ///
    /// Runs as as game component and checks if any keybindings are active. If so, runs all commands linked to the keybinding.
    /// <see cref="KeyBindingManager"/> for more details on keybindings
    /// </summary>
    public class InputHandler : Microsoft.Xna.Framework.GameComponent
    {

        public static KeyboardState KeyboardState { get; private set; } = Keyboard.GetState();
        public static KeyboardState LastKeyboardState { get; private set; } = Keyboard.GetState();

        public static KeyBindingManager KeyBindings { get; private set; } = new KeyBindingManager();

        public InputHandler(Game game) : base(game) { }
        
        public override void Initialize()
        {
            KeyBindings.LoadBindingsJSON();
            KeyBindings.UpdateBindings();

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            LastKeyboardState = KeyboardState;
            KeyboardState = Keyboard.GetState();

            foreach(var pressedKey in KeyboardState.GetPressedKeys())
            {
                var keyBinding = KeyBindings.GetKeyBinding(pressedKey);
                keyBinding?.Commands.ForEach(command => command.Execute());
            }


            base.Update(gameTime);
        }

    }
}
