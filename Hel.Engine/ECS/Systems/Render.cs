using System;
using Hel.Engine.ECS.Components.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hel.Engine.ECS.Systems
{
    class Render : System
    {

        public Render(SystemManager system) : base(system) { }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            //Job job = new Job(world.EntityManager.GetEntities<IRender>(), JobLogic);
            var rand = new Random();
            spriteBatch.Begin();

            //Draws all entities to the screen that implement the IRender interface.
            foreach (var entity in Engine.WorldManager.PrimaryWorld.EntityManager.GetEntities<RenderComponent>())
            {
                if (!entity.Value.GetComponentOrNull(out RenderComponent renderComponent) ||
                    !entity.Value.GetComponentOrNull(out TransformComponent transformComponent)) continue;

                spriteBatch.Draw(
                    renderComponent.Texture,
                    new Vector2(transformComponent.X + (rand.Next(0, 10) - 5), transformComponent.Y +  (rand.Next(0, 10) - 5)),
                    Color.White);
            }

            spriteBatch.End();
        }

    }
}
