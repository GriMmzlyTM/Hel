using System;
using Hel.Engine.ECS.Components.Container;
using Hel.Engine.ECS.Components.Model;
using Hel.Engine.ECS.Systems.System;

namespace Hel.Engine.ECS.Entities.Matcher.Groups
{

    /// <summary>
    /// EntityMatchers 
    /// </summary>
    public interface IEntityGroup
    {
        void RunSystems();
        void OnEntitiesChanged(int[] entitiesList, ComponentContainer.EntityChangeDirection changeDirection);
    }
    public interface IEntityGroup<TComponent1> : IEntityGroup
        where TComponent1 : struct, IComponent
    {
        void ForEach(Func<int, TComponent1, TComponent1?> func);
        void AddSystem(ISystem<TComponent1> system);
    }

    public interface IEntityGroup<TComponent1, TComponent2> : IEntityGroup 
        where TComponent1 : struct, IComponent 
        where TComponent2 : struct, IComponent
    {
        public void ForEach(Func<int, TComponent1, TComponent2, (TComponent1?, TComponent2?)?> action);
        void AddSystem(ISystem<TComponent1, TComponent2> system);
    }

    public interface IEntityGroup<TComponent1, TComponent2, TComponent3> :IEntityGroup
        where TComponent1 : struct, IComponent 
        where TComponent2 : struct, IComponent
        where TComponent3 : struct, IComponent
    {
        public void ForEach(Func<int, TComponent1, TComponent2, TComponent3,
            (TComponent1?, TComponent2?, TComponent3?)?> action);
        void AddSystem(ISystem<TComponent1, TComponent2, TComponent3> system);
    }

}