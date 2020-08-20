using Hel.Engine.ECS.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hel.Engine.ECS.Systems
{
    public interface ISystem
    {
        void Update(GameTime gameTime);
        void Draw(GameTime gameTime, SpriteBatch spriteBatch);

    }
    public class System : ISystem
    {
        protected World world;
        public System(SystemManager manager)
        {

            manager.AddSystem(this);
            world = manager.World;

        }

        public virtual void Update(GameTime gameTime) { }
        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch) { }

        protected virtual void JobLogic(EntityDictionary entityList) { }

    }
}