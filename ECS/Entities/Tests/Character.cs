using Hel.ECS.Components;
using System;
using System.Collections.Generic;

namespace Hel.ECS.Entities.Tests
{
    public struct Character : IEntity
    {

        public HashSet<IComponent> Components { get; }

        public void AddComponent(IComponent component)
        {
            Components.Add(component);
        }

        public Character(
            Render render,
            MovementComponent movement)
        {
            Components = new HashSet<IComponent>() { render, movement };
        }

    }
}
