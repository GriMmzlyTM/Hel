using Hel.Engine.ECS.Components.Examples;
using Hel.Engine.ECS.Components.Model;
using Hel.Engine.ECS.Entities.Matcher;
using Hel.Engine.ECS.Entities.Matcher.Groups;
using Hel.Engine.ECS.Systems.Logic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hel.Engine.ECS.Systems.ExampleSystems
{
    public class TestCoupledSystemRender : System.CoupledSystem
    {
        
        /// <summary>
        /// Draws MUST run through the <see cref="SystemManager"/>. 
        /// </summary>
        public override void Draw(GameTime gameTime, float deltaTime, SpriteBatch spriteBatch)
        {
            
            spriteBatch.Begin();

            ((IEntityGroup<TransformExample, RenderExample>) GetMatcherQuerier().GetEntityMatcher(
                    new EntityGroupQuery()
                        .Containing<TransformExample>()
                        .Containing<RenderExample>()
                        .Build()))
                .ForEach((entityId, transform, render) =>
                {
                    spriteBatch.Draw(
                        render.Texture,
                        new Vector2(transform.X, transform.Y),
                        Color.White);

                    return default;
                });
            
          
            spriteBatch.End();
        }
    }
}
