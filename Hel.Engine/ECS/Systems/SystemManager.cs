using System;
using System.Collections.Generic;
using System.Threading;
using Hel.Engine.ECS.Jobs;
using Microsoft.Xna.Framework;

namespace Hel.Engine.ECS.Systems
{

    public class SystemManager : DrawableGameComponent
    {

        private readonly List<ISystem> systems = new List<ISystem>();
        public World World { get; private set; }
        //public readonly JobManager jobManager;
        public static float DeltaTime { get; private set; }

        public SystemManager(Game game, World world) : base(game)
        {
            World = world;
            game.Components.Add(this);
            //jobManager = new JobManager();
            InitializeSystems();
        }

        private void InitializeSystems()
        {
            new Render(this);
        }

        public void AddSystem(ISystem system) => systems.Add(system);

        public void AddSystem<T>() where T : ISystem, new() =>
            systems.Add((T) Activator.CreateInstance(typeof(T), this));

        public override void Draw(GameTime gameTime)
        {

            foreach (ISystem sys in systems)
                sys.Draw(gameTime, World.SpriteBatch);

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            DeltaTime = (float) gameTime.ElapsedGameTime.TotalSeconds * 30;

            foreach (ISystem sys in systems)
                sys.Update(gameTime);

            EntityJobManager.RunJobs();

            var runningJobs = EntityJobManager.GetRunningJobs();

            while (runningJobs.Count != 0) {
                Thread.Sleep(1);
            }

            EntityJobMutator.ApplyMutations(World.EntityManager);

            base.Update(gameTime);
        }
    }
}
