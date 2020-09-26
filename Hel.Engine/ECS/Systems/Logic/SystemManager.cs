using System;
using System.Collections.Generic;
using Hel.Engine.ECS.Systems.System;
using Hel.Engine.Toolkit;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hel.Engine.ECS.Systems.Logic
{

    public class SystemManager : DrawableGameComponent
    {
        private readonly List<ICoupledSystem> systems = new List<ICoupledSystem>();
        public World.World World { get; private set; }
        public SystemManager(Game game, World.World world) : base(game)
        {
            World = world;
            game.Components.Add(this);
            //jobManager = new JobManager();
            InitializeSystems();
        }

        private void InitializeSystems()
        {
        }
        
        public void AddSystem<T>() where T : ICoupledSystem, new()
        {
            systems.Add((T) Activator.CreateInstance(typeof(T)));
        }

        public override void Draw(GameTime gameTime)
        {
            if (!World.IsPrimary) return;
            
            var deltaTime = (float) gameTime.ElapsedGameTime.TotalSeconds;
            
            foreach (ICoupledSystem sys in systems)
                sys.Draw(gameTime, deltaTime, World.SpriteBatch);
            
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            if (!World.IsPrimary) return;

            var deltaTime = (float) gameTime.ElapsedGameTime.TotalSeconds;
            foreach (var entityMatcher in World.EntityMatcher)
            {
                entityMatcher.RunSystems();
            }
            
            foreach (ICoupledSystem sys in systems)
                sys.Update(gameTime, deltaTime);


            World.EntityManager.UpdateEntitiesInStaging();

            base.Update(gameTime);
        }
    }
}
