using System;
using System.Collections.Generic;
using Hel.Engine.ECS.Components.Container;
using Hel.Engine.ECS.Components.Model;
using Hel.Engine.ECS.Systems.System;
using Hel.Engine.Toolkit.DataStructure.Arrays;

namespace Hel.Engine.ECS.Entities.Matcher.Groups
{
    public class EntityGroup<TComponent1, TComponent2, TComponent3> : IEntityGroup <TComponent1, TComponent2, TComponent3>
        where TComponent1 : struct, IComponent
        where TComponent2 : struct, IComponent
        where TComponent3 : struct, IComponent
    {
        private ComponentContainer Component1 { get; }
        private ComponentContainer Component2 { get; }
        private ComponentContainer Component3 { get; }
        private DynamicArray<bool> Entities { get; }

        private delegate (TComponent1?, TComponent2?, TComponent3?) SystemMethods(int id,
            TComponent1 component,
            TComponent2 component2,
            TComponent3 component3);

        private event SystemMethods RunSystemEvents;
        
        private int _runSystemsCounter = 0;
        
        public EntityGroup(ref Dictionary<Type, ComponentContainer> componentContainer,
            IEnumerable<ISystem<TComponent1, TComponent2, TComponent3>> systems = default)
        {
            Entities = new DynamicArray<bool>(256);

            componentContainer.TryGetValue(typeof(TComponent1), out var component1);
            Component1 = component1;
            Component1!.OnEntitiesModified += OnEntitiesChanged;
            
            componentContainer.TryGetValue(typeof(TComponent2), out var component2);
            Component2 = component2;
            Component2!.OnEntitiesModified += OnEntitiesChanged;
            
            componentContainer.TryGetValue(typeof(TComponent3), out var component3);
            Component3 = component3;
            Component3!.OnEntitiesModified += OnEntitiesChanged;

            if (systems == null) return;
            
            AddSystems(systems);
        }

        public void OnEntitiesChanged(int[] entitiesList, ComponentContainer.EntityChangeDirection changeDirection)
        {
            switch (changeDirection)
            {
                case ComponentContainer.EntityChangeDirection.Removed:
                    RemoveEntities(entitiesList);
                    break;
                case ComponentContainer.EntityChangeDirection.Added:
                    AddEntities(entitiesList);
                    break;
            }
        }

        private void RemoveEntities(int[] entitiesList)
        {
            for (int i = 0; i < entitiesList.Length; i++)
            {
                Entities[entitiesList[i]] = false;
            }
        }

        private void AddEntities(int[] entitiesList)
        {
            for (int i = 0; i < entitiesList.Length; i++)
            {
                var compIndex = entitiesList[i];
                if (Component1[compIndex] == default) continue;
                if (Component2[compIndex] == default) continue;
                if (Component3[compIndex] == default) continue;
                Entities[compIndex] = true;
            }
        }

        public void AddSystem(ISystem<TComponent1, TComponent2, TComponent3> system)
        {
            RunSystemEvents += system.RunSystem;
        }
        
        public void AddSystems(IEnumerable<ISystem<TComponent1, TComponent2, TComponent3>> systems)
        {
            foreach (var system in systems)
            {
                AddSystem(system);
            }
        }
        
        public void RunSystems()
        {
            for (_runSystemsCounter = 0; _runSystemsCounter < Entities.Size; _runSystemsCounter++)
            {
                if (Entities[_runSystemsCounter])
                {
                    var entityData = RunSystemEvents?.Invoke(
                        _runSystemsCounter,
                        (TComponent1) Component1[_runSystemsCounter],
                        (TComponent2) Component2[_runSystemsCounter],
                        (TComponent3) Component3[_runSystemsCounter]);

                    UpdateValues(entityData);
                }
            }
        }

        private void UpdateValues((TComponent1?, TComponent2?, TComponent3?)? values)
        {
            if (!values.HasValue) return; 
            if (values.Value.Item1.HasValue) 
                Component1.UpdateComponent(_runSystemsCounter, values.Value.Item1.Value);
            
            if (values.Value.Item2.HasValue) 
                Component2.UpdateComponent(_runSystemsCounter, values.Value.Item2.Value);
            
            if (values.Value.Item3.HasValue) 
                Component3.UpdateComponent(_runSystemsCounter, values.Value.Item3.Value);
        }
        
        public void ForEach(Func<int,
            TComponent1,
            TComponent2,
            TComponent3,
            (TComponent1?, TComponent2?, TComponent3?)?> func)
        {
            for (int i = 0; i < Entities.Size; i++)
            {
                if (Entities[i])
                {
                    UpdateValues(func(i,
                        (TComponent1) Component1[i],
                        (TComponent2) Component2[i],
                        (TComponent3) Component3[i]));
                }
            }
        }
    }
}