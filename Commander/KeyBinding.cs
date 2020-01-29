
using Hel.Commander.Model;
using Hel.Engine;
using Microsoft.Xna.Framework.Input;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Hel.Commander
{
    internal interface IKeyBinding
    {
        /// <summary>
        /// Finds the key associated with a certain action, and returns said key.
        /// Useful if searching for a specific action. Slower then GetKey due to the fact that
        /// Bindings use Keys as TKey and KeyActions as TValues.   
        /// </summary>
        /// <param name="action">ICommand you are searching for.</param>
        /// <returns>Key associated with said action, if available. Returns 0 or Keys.None if Action does not exist.</returns>
        Keys GetAction(ICommand action);
        /// <summary>
        /// Uses the provided key to return the ICommand associated with a specific key.
        /// Faster than GetKey due to the Bindings dictionary using Keys as TKeys
        /// </summary>
        /// <param name="key">The key you're trying to get the action of.</param>
        /// <returns>Returns the action associated with said key. If key does not exist in dictionary, returns 0 or ICommand.None</returns>
        ICommand GetKey(Keys key);
        /// <summary>
        /// Adds a Key-ICommand pair to the bindings dictionary. If key is already in use, replaces the associated action. 
        /// </summary>
        /// <param name="key">The key to bind</param>
        /// <param name="action">The action to bind to the key</param>
        void SetAction(Keys key, ICommand action);
        /// <summary>
        /// Adds multiple Key-ICommand pairs to the bindings dictionary. If key is already in use, replaces the associated action. 
        /// </summary>
        /// <param name="key">The key to bind</param>
        /// <param name="action">The action to bind to the key</param>
        void SetActions(Dictionary<Keys, ICommand> actions);
        /// <summary>
        /// Removes a key from the dictionary entirely. 
        /// </summary>
        /// <param name="key">Key to remove from the dictionary.</param>
        void RemoveKey(Keys key);
        /// <summary>
        /// Saves temporary bindings. All binding changes are temporary until this method is called.
        /// </summary>
        void UpdateBindings();
        /// <summary>
        /// Reverts the temporary bindings to how they were prior to being changed.
        /// </summary>
        void UndoBindings();
        /// <summary>
        /// Saves bindings to a JSON file.
        /// </summary>
        void SaveBindingsJSON();
        /// <summary>
        /// Loads bindings from the JSON file. UpdateBindings() must be called to save the bindings.
        /// </summary>
        void LoadBindingsJSON();
    }
    public class KeyBinding : EventChange<KeyBinding>, IKeyBinding
    {
        /// <summary>
        /// Permanent key bindings used by Get methods
        /// </summary>
        private Dictionary<Keys, ICommand> _bindings;
        /// <summary>
        /// Temporary key bindings used to safely modify bindings, and revert if needed. 
        /// </summary>
        private Dictionary<Keys, ICommand> _tempBindings;

        public KeyBinding(Dictionary<Keys, ICommand> dict)
        {
            _bindings = new Dictionary<Keys, ICommand>();
            _tempBindings = new Dictionary<Keys, ICommand>();

            foreach (var entry in dict)
            {
                _bindings.Add(entry.Key, entry.Value);
                _tempBindings.Add(entry.Key, entry.Value);
            }
        }

        public KeyBinding() : this(new Dictionary<Keys, ICommand>()) {}

        public ICommand GetKey(Keys key) =>
            _bindings.ContainsKey(key) ? _bindings[key] : null;
     

        public Keys GetAction(ICommand action) =>
            _bindings.FirstOrDefault((v => v.Value == action)).Key;

        public void RemoveKey(Keys key) =>
            _tempBindings.Remove(key);
        

        public void SetAction(Keys key, ICommand action)
        {
            if (GetKey(key) != null)
                _tempBindings[0] = action;
            else
                _tempBindings.Add(key, action);
        }

        public void SetActions(Dictionary<Keys, ICommand> actions)
        {
            foreach (var pair in actions)
            {
                SetAction(pair.Key, pair.Value);
            }
        }

        public void UpdateBindings()
        {
            _bindings = new Dictionary<Keys, ICommand>(_tempBindings);
            OnChangeEvents(this);
        }

        public void UndoBindings() =>
            _tempBindings = new Dictionary<Keys, ICommand>(_bindings);

        public void SaveBindingsJSON()
        {
            string output = JsonConvert.SerializeObject(_bindings);
            System.IO.File.WriteAllText($"{Engine.Engine.FileRoot}/Bindings.json", output);
        }

        public void LoadBindingsJSON()
        {
            string input = System.IO.File.ReadAllText($"{Engine.Engine.FileRoot}/Bindings.json");
            _tempBindings = JsonConvert.DeserializeObject<Dictionary<Keys, ICommand>>(input);
        }
    }
}
