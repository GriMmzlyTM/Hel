using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private readonly JobManager jobManager;
        public static float DeltaTime { get; private set; }

        public SystemManager(Game game, World world) : base(game)
        {
            World = world;
            game.Components.Add(this);
            jobManager = new JobManager();
            InitializeSystems();
        }

        private void InitializeSystems()
        {
            var _ = new Render(this);
            var __ = new Movement(this);
        }

        public void AddSystem(ISystem system) => systems.Add(system);

        public override void Draw(GameTime gameTime)
        {
       
            foreach(ISystem sys in systems)
                sys.Draw(gameTime, World.SpriteBatch);

            //jobManager.RunJobs();

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            DeltaTime = (float) gameTime.ElapsedGameTime.TotalSeconds * 30;
            JobMutator.ApplyMutations(World.EntityManager);

            foreach (ISystem sys in systems)
                sys.Update(gameTime);

            jobManager.RunJobs();

            base.Update(gameTime);
        }
    }
}
