using Hel.Engine.ECS.Entities.Logic;
using Hel.Engine.ECS.Entities.Matcher;
using Hel.Engine.ECS.Systems.Logic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hel.Engine.ECS.World
{
    /// <summary>
    /// Worlds are stored within World Managers and contain their own instance of
    /// EntityManager, SystemManager and SpriteBatch. 
    /// </summary>
    public class World
    {
        public string Name { get; private set; }
        public EntityManager EntityManager;
        public SystemManager SystemManager;
        public EntityMatcher EntityMatcher;
        
        public SpriteBatch SpriteBatch { get; private set; }

        public bool IsPrimary;
        public World(Game game, SpriteBatch spriteBatch, string name)
        {
            SpriteBatch   = spriteBatch;
            Name = name;
            EntityManager = new EntityManager(this);
            EntityMatcher = new EntityMatcher();
            SystemManager = new SystemManager(game, this);
        }
    }
}
