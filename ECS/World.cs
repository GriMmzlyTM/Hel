using Hel.ECS.Entities;
using Hel.ECS.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hel.ECS
{
    /// <summary>
    /// Worlds are stored within World Managers and contain their own instance of
    /// EntityManager, SystemManager and SpriteBatch. 
    /// </summary>
    public class World
    {
        public string Name { get; private set; }
        public IEntityManager EntityManager;
        public SystemManager SystemManager;
        public SpriteBatch SpriteBatch { get; private set; }

        public World(Game game, SpriteBatch spriteBatch, string name)
        {
            SpriteBatch   = spriteBatch;
            Name = name;
            SystemManager = new SystemManager(game, this);
            EntityManager = new EntityManager(this);
        }
    }
}
