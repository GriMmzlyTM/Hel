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
            
                        spriteBatch.Begin();

            //Draws all entities to the screen that implement the IRender interface.
            foreach (var entity in world.EntityManager.GetEntities<RenderComponent>())
            {
                if (entity.Value.GetComponentOrNull(out RenderComponent renderComponent)
                    && entity.Value.GetComponentOrNull(out TransformComponent transformComponent))
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
