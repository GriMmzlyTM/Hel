using System;
using System.Collections.Generic;
using Hel.Engine.Commander.Model;
using Microsoft.Xna.Framework.Input;

namespace Hel.Engine.Input.Model
{
    [Serializable]
    public class KeyBinding : IEquatable<KeyBinding>
    {
        public HashSet<Keys> Keys { get; }
        public List<ICommand> Commands { get; set; }

        public KeyBinding(HashSet<Keys> keys, List<ICommand> commands)
        {
            Keys = keys;
            Commands = commands;
        }

        public override bool Equals(object other)
        {
            if (!(other is KeyBinding)) return false;
            var obj = (KeyBinding)other;
            return Keys.SetEquals(obj.Keys);
        }

        public bool Equals(KeyBinding other) =>
            other != null && Keys.SetEquals(other.Keys);

        public override int GetHashCode() =>
            Keys.GetHashCode();
    }
}
