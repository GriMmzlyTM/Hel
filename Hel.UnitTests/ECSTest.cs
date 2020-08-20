using System;
using Hel.ECS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Moq;

namespace Hel.UnitTests
{
    [TestClass]
    public class ECSTest
    {

        [TestMethod]
        public void GenerateWorld_generates_proper_World()
        {
            //Define
            var game = new Mock<Game1>();
            WorldManager worldManager = new WorldManager(game.Object);

            //Action
            worldManager.GenerateWorld(new SpriteBatch(game.Object.GraphicsDevice), "test");
            World world = worldManager.GetWorld("test");

            //Assert
            Assert.IsNotNull(world);
            Assert.IsNotNull(world.SpriteBatch);
        }

        [TestMethod]
        public void World_contains_SystemManager()
        {
            using var game = new Game1();
            //Define
            WorldManager worldManager = new WorldManager(game);
            //Action
            worldManager.GenerateWorld(new SpriteBatch(game.GraphicsDevice), "test");
            World world = worldManager.GetWorld("test");

            //Assert
            Assert.IsNotNull(world.SystemManager);
        }

        [TestMethod]
        public void World_contains_EntityManager()
        {
            using Game game = new Game1();
            //Define
            WorldManager worldManager = new WorldManager(game);
            //Action
            worldManager.GenerateWorld(new SpriteBatch(game.GraphicsDevice), "test");
            World world = worldManager.GetWorld("test");

            //Assert
            Assert.IsNotNull(world.EntityManager);
        }

    }
}
