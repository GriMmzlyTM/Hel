using System.IO;
using Hel.Engine.ECS;
using Hel.Engine.Input.GameComponent;
using Microsoft.Xna.Framework;

namespace Hel.Engine
{
    /// <summary>
    /// The Hel Engine's primary class. The Engine class allows you to initialize, manage, and control the engine safely and exposes
    /// certain methods and functions which may be unsafe otherwise. For example, all games must run the Engine.Initialize(game) method
    /// in order to assign the necessary GameComponents from Hel Engine to your Game object.
    /// </summary>
    public class Engine
    {

        public static string FileRoot { get; private set; }
        private static Game _game;

        /// <summary>
        /// The Initialize method is required in-order to initialize and startup the hel engine properly. This will run necessary setup methods, as well as
        /// assign the required _components to your game so they can run automatically.
        /// </summary>
        /// <param name="game">Your Game1 instance.</param>
        public static void Initialize(Game game)
        {
            game.Components.Add(new InputHandler(game));

            FileRoot = Directory.GetCurrentDirectory();
        }

    }
}
