﻿using Hel.Input.GameComponent;
using Hel.Toolkit;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Hel.Input.Util
{
    public static class MoveDirection
    {
        public static KeyboardState KeyState => InputHandler.KeyboardState;
        public static KeyboardState LastKeyState => InputHandler.LastKeyboardState;
        private static int _lastX;

        private static Keys Up;
        private static Keys Down;
        private static Keys Left;
        private static Keys Right;

        /// <summary>
        /// KeyboardDirection takes the current keyboard state, and calculates the required direction accordingly. 
        /// </summary>
        /// <returns>Direction to move based on keyboard input.</returns>
        public static Vector2 KeyboardDirection()
        {

            int x = Convert.BoolToInt(KeyState.IsKeyDown(Right)) - Convert.BoolToInt(KeyState.IsKeyDown(Left));
            int y = Convert.BoolToInt(KeyState.IsKeyDown(Down)) - Convert.BoolToInt(KeyState.IsKeyDown(Up));

            if (KeyState.IsKeyDown(Right) && KeyState.IsKeyDown(Left))
            {
                x = LastKeyState.IsKeyDown(Right) && LastKeyState.IsKeyDown(Left) ? _lastX : -_lastX;
            }

            Vector2 dir = new Vector2(x, y);

            _lastX = (int)dir.X;

            if (!dir.Equals(Vector2.Zero)) dir.Normalize(); 

            return dir;
        }

    }
}
