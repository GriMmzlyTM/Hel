using System;
using System.Linq;
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

            var entityManager = Engine.WorldManager.PrimaryWorld.EntityManager;
            //Job job = new Job(world.EntityManager.GetEntities<IRender>(), JobLogic);
            spriteBatch.Begin();
            var entityComponents = entityManager.GetEntities(out var entityIds,
                typeof(RenderComponent),
                typeof(TransformComponent));
            
            //Draws all entities to the screen that implement the IRender interface.
            var enumerable = entityIds as int[] ?? entityIds.ToArray();
            for (int i = 0; i < enumerable.Length; i++)
            {
                var entityId = enumerable[i];

                if (!entityComponents[typeof(RenderComponent)]
                    .Get(entityId, out var renderComponentGet)) continue;
                var renderComponent = (RenderComponent) renderComponentGet;

                if (!entityComponents[typeof(TransformComponent)]
                    .Get(entityId, out var transformComponentGet)) continue;
                var transformComponent = (TransformComponent) transformComponentGet;
              
               
                spriteBatch.Draw(
                    renderComponent.Texture,
                    new Vector2(transformComponent.X, transformComponent.Y ),
                    Color.White);
                /*spriteBatch.Draw(
                    renderComponent.Texture,
                    new Vector2( (rand.Next(0, 900)), (rand.Next(0, 900))),
                    Color.White);*/
            }

            spriteBatch.End();
        }

    }
}
