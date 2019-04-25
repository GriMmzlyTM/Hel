using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hel.ECS.Entities;
using Hel.ECS.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hel.ECS
{
    internal interface IWorldManager
    {
        /// <summary>
        /// Generates a new world and stores it in the world manager.
        /// The newly generated world will also generate a SystemManager and an EntityManager.
        /// </summary>
        /// <param name="game">Your Game1 instance</param>
        /// <param name="spriteBatch">Game1 spritebatch</param>
        /// <param name="worldName">The name you want this world to be stored with in the dictionary</param>
        /// <returns></returns>
        World GenerateWorld(Game game, SpriteBatch spriteBatch, string worldName);
        /// <summary>
        /// Gets a world from the dictionary by name and returns it.
        /// </summary>
        /// <param name="worldName">The name of the world to return</param>
        /// <returns></returns>
        World GetWorld(string worldName);

    }

    /// <summary>
    /// The world manager contains references to all the instantiated worlds in your game. 
    /// </summary
    public class WorldManager : IWorldManager
    {
       private readonly Dictionary<string, World> worlds = new Dictionary<string, World>();

       public WorldManager()
       {}

       public World GenerateWorld(Game game, SpriteBatch spriteBatch, string worldName)
       {
           World world = new World(game, spriteBatch, worldName);
           worlds.Add(worldName, world);

           return world;
       }

       public World GetWorld(string worldName)
       {
           if (worlds.ContainsKey(worldName))
               return worlds[worldName];

           return null;
       }
    }
}
