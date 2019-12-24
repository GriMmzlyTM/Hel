using Hel.ECS.Components;
using Hel.ECS.Components.Model;
using Hel.ECS.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Hel.ECS.Systems
{
    class Render : System
    {

        public Render(SystemManager system) : base(system)
        {
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            //Job job = new Job(world.EntityManager.GetEntities<IRender>(), JobLogic);
            
                        spriteBatch.Begin();

            //Draws all entities to the screen that implement the IRender interface.
            foreach (var entity in world.EntityManager.GetEntities<RenderComponent>())
            {
                if (entity.Value.GetComponentOrFail(out RenderComponent renderComponent)
                    && entity.Value.GetComponentOrFail(out TransformComponent transformComponent))
                {
                    spriteBatch.Draw(
                        renderComponent.Texture,
                        new Vector2(transformComponent.X, transformComponent.Y),
                        Color.White);
                }
            }

            spriteBatch.End();
        }

    }
}
