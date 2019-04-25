using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hel.ECS.Components;
using Hel.ECS.Entities;
using Hel.Jobs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hel.ECS.Systems
{
    class Render : System
    {

        public Render(SystemManager system) : base(system)
        {
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            //Job job = new Job(world.EntityManager.GetEntityType<IRender>(), JobLogic);
            
                        spriteBatch.Begin();

            //Draws all entities to the screen that implement the IRender interface.
            foreach (IEntity component in world.EntityManager.GetEntityType<IRender>())
            {
                if (!(component is IRender renderComponent)) continue;
                spriteBatch.Draw(
                    renderComponent.texture,
                    new Vector2(renderComponent.X, renderComponent.Y),
                    Color.White);
            }

            spriteBatch.End();
        }

    }
}
