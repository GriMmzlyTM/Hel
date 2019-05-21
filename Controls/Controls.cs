using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Hel.Controls
{
    class Controls : GameComponent
    {

        public static KeyboardState KeyboardState { get; private set; } = Keyboard.GetState();
        public static KeyboardState LastKeyboardState { get; private set; } = Keyboard.GetState();

        public static KeyBinding KeyBindings { get; private set; } = new KeyBinding();

        public Controls(Game game) : base(game) { }

        public override void Initialize()
        {

            KeyBindings.AddChangeEvent(MoveDirection.UpdateBindings);

            KeyBindings.LoadBindingsJSON();
            KeyBindings.UpdateBindings();

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            LastKeyboardState = KeyboardState;
            KeyboardState = Keyboard.GetState();

            base.Update(gameTime);
        }

    }
}
