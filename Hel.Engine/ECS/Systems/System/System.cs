using Hel.Engine.ECS.Components.Model;
using Hel.Engine.ECS.Entities.Container;
using Hel.Engine.ECS.Entities.Logic;
using Hel.Engine.ECS.Entities.Matcher;
using Hel.Engine.ECS.Systems.Logic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hel.Engine.ECS.Systems.System
{
    public interface ISystem<TComponent1>
    where TComponent1 : struct, IComponent
    {
        TComponent1? RunSystem(int entityId, TComponent1 component);
    }
    
    public interface ISystem<TComponent1, TComponent2>
    where TComponent1 : struct, IComponent
    where TComponent2 : struct, IComponent
    {
        (TComponent1?, TComponent2?) RunSystem(int entityId, TComponent1 component, TComponent2 component2);
    }
    
    public interface ISystem<TComponent1, TComponent2, TComponent3>
        where TComponent1 : struct, IComponent
        where TComponent2 : struct, IComponent
        where TComponent3 : struct, IComponent
    {
        (TComponent1?, TComponent2?, TComponent3?) RunSystem(
            int entityId, TComponent1 component, TComponent2 component2, TComponent3 component3);
    }
    
    public interface ISystem<TComponent1, TComponent2, TComponent3, TComponent4>
        where TComponent1 : struct, IComponent
        where TComponent2 : struct, IComponent
        where TComponent3 : struct, IComponent
        where TComponent4 : struct, IComponent
    {
        (TComponent1?, TComponent2?, TComponent3?, TComponent4?) RunSystem(
            int entityId, TComponent1 component, TComponent2 component2, TComponent3 component3, TComponent4 component4);
    }
    
    public interface ICoupledSystem
    {
        void Update(GameTime gameTime, float deltaTiIme);
        void Draw(GameTime gameTime, float deltaTime, SpriteBatch spriteBatch);

    }
    
    /// <summary>
    /// Base class that must be inherited by systems that run 
    /// </summary>
    public class CoupledSystem : ICoupledSystem
    {

        protected EntityManager GetEntityManager() => GetPrimaryWorld().EntityManager;

        protected EntityMatcher GetMatcherQuerier() => GetPrimaryWorld().EntityMatcher;
        protected World.World GetPrimaryWorld() => Engine.WorldManager.PrimaryWorld;
        
        public virtual void Update(GameTime gameTime, float deltaTime) { }
        public virtual void Draw(GameTime gameTime, float deltaTime, SpriteBatch spriteBatch) { }
        protected virtual void JobLogic(EntityLookup entityList) { }

    }
}