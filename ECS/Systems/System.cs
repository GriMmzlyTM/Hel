using Hel.ECS.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Hel.ECS.Systems
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

        public virtual void JobLogic(IEnumerable<IEntity> entityList) { }

    }
}