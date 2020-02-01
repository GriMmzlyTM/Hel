using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Hel.Commander
{
    class InputHandler : GameComponent
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
                if (keyBinding != null)
                    keyBinding.Commands.ForEach(command => command.Execute());
            }


            base.Update(gameTime);
        }

    }
}
