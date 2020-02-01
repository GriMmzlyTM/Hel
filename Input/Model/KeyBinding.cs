using Hel.Commander.Model;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Hel.Input.Model
{
    public class KeyBinding : IEquatable<KeyBinding>
    {

        public HashSet<Keys> Keys { get; set; }
        public List<ICommand> Commands { get; set; }

        public KeyBinding(HashSet<Keys> keys, List<ICommand> commands)
        {
            Keys = keys;
            Commands = commands;
        }

        public override bool Equals(object other)
        {
            if (other == null || !(other is KeyBinding)) return false;
            var obj = (KeyBinding)other;
            return Keys.SetEquals(obj.Keys);
        }

        public bool Equals(KeyBinding other) =>
            other == null ? false : Keys.SetEquals(other.Keys);

        public override int GetHashCode() =>
            Keys.GetHashCode();
    }
}
