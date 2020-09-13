﻿using System;
using System.Collections.Generic;
using System.Threading;
using Hel.Engine.ECS.Jobs;
using Hel.Engine.Toolkit;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hel.Engine.ECS.Systems
{

    public class SystemManager : DrawableGameComponent
    {
        private readonly List<ISystem> systems = new List<ISystem>();
        public World World { get; private set; }
        //public readonly JobManager jobManager;
        public static float DeltaTime { get; private set; }
        private SpriteFont fpsfont;
        private FrameCounter _frameCounter = new FrameCounter();
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
            fpsfont = Engine.Game.Content.Load<SpriteFont>("TestFont");
        }

        public void AddSystem(ISystem system) => systems.Add(system);

        public void AddSystem<T>() where T : ISystem, new() =>
            systems.Add((T) Activator.CreateInstance(typeof(T), this));

        public override void Draw(GameTime gameTime)
        {

            foreach (ISystem sys in systems)
                sys.Draw(gameTime, World.SpriteBatch);

            World.SpriteBatch.Begin(SpriteSortMode.BackToFront);
            var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            _frameCounter.Update(deltaTime);
            var fps = string.Format("FPS: {0}", _frameCounter.CurrentFramesPerSecond);
            World.SpriteBatch.DrawString(fpsfont, fps, new Vector2(10, 10), Color.Black);
            
            World.SpriteBatch.DrawString(fpsfont, $"Entity count: {World.EntityManager.EntityCount}", new Vector2(10, 40), Color.Black);
            /*var frameRate = 1 / (float)gameTime.ElapsedGameTime.TotalSeconds;
            World.SpriteBatch.DrawString(fpsfont, frameRate.ToString(), new Vector2(10, 10), Color.Black);*/
            World.SpriteBatch.End();
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
