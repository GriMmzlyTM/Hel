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
            WorldManager worldManager = new WorldManager();
            var game = new Mock<Game1>();

            //Action
            worldManager.GenerateWorld(game.Object, new SpriteBatch(game.Object.GraphicsDevice), "test");
            World world = worldManager.GetWorld("test");

            //Assert
            Assert.IsNotNull(world);
            Assert.IsNotNull(world.SpriteBatch);
        }

        [TestMethod]
        public void World_contains_SystemManager()
        {
            //Define
            WorldManager worldManager = new WorldManager();

            using (var game = new Game1())
            {
                //Action
                worldManager.GenerateWorld(game, new SpriteBatch(game.GraphicsDevice), "test");
                World world = worldManager.GetWorld("test");

                //Assert
                Assert.IsNotNull(world.SystemManager);
            }
        }

        [TestMethod]
        public void World_contains_EntityManager()
        {
            //Define
            WorldManager worldManager = new WorldManager();

            using (Game game = new Game1())
            {
                //Action
                worldManager.GenerateWorld(game, new SpriteBatch(game.GraphicsDevice), "test");
                World world = worldManager.GetWorld("test");

                //Assert
                Assert.IsNotNull(world.EntityManager);
            }
        }

    }
}
