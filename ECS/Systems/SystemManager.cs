using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Hel.Jobs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hel.ECS.Systems
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
            new Movement(this);
        }

        public void AddSystem(ISystem system) => systems.Add(system);

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

            JobManager.RunJobs();

            var runningJobs = JobManager.GetRunningJobs();

            while (runningJobs.Count != 0) {
                Thread.Sleep(1);
            }

            JobMutator.ApplyMutations(World.EntityManager);

            base.Update(gameTime);
        }
    }
}
