using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Hel.Engine.ECS.Components.Model;
using Hel.Engine.ECS.Entities.Matcher.Groups;
using Hel.Engine.ECS.Systems.System;

namespace Hel.Engine.ECS.Entities.Matcher
{
    public class EntityMatcher : IEnumerable<IEntityGroup>
    {

        private readonly Dictionary<int, IEntityGroup> _entityMatchers = new Dictionary<int, IEntityGroup>();
        
        public EntityMatcher() { }
        

        public IEntityGroup GetEntityMatcher(int query)
        {
            if(_entityMatchers.TryGetValue(query, out var getEntityMatcher))
                return getEntityMatcher;
            
            throw new Exception("System not registered");
        }

        public void Register<T>(IEnumerable<ISystem<T>> systems = default, World.World world = default) where T: struct, IComponent
        {
            var query = new EntityGroupQuery().Containing<T>().Build();

            if (_entityMatchers.ContainsKey(query))
            {
                Console.WriteLine($"EntityGroup for type {typeof(T)} already exists!");
                ((EntityGroup<T>) _entityMatchers[query]).AddSystems(systems);
                return;
            }
            
            var _world = world ?? Engine.WorldManager.PrimaryWorld;
            var entityMatcher =
                new EntityGroup<T>(ref _world.EntityManager.Components, systems);
            
            _entityMatchers.Add(query, entityMatcher);
            
        }
        
        public void Register<T, T2>(IEnumerable<ISystem<T, T2>> systems = default, World.World world = default) 
            where T : struct, IComponent
            where T2: struct, IComponent
        {
            var query = new EntityGroupQuery().Containing<T>().Containing<T2>().Build();
            
            if (_entityMatchers.ContainsKey(query))
            {
                Console.WriteLine($"EntityGroup for type {typeof(T)} and {typeof(T2)} already exists!");
                ((EntityGroup<T, T2>) _entityMatchers[query]).AddSystems(systems);
                return;
            }
            
            var _world = world ?? Engine.WorldManager.PrimaryWorld;
            
            var entityMatcher =
                new EntityGroup<T, T2>(ref _world.EntityManager.Components, systems);
            
            _entityMatchers.Add(query, entityMatcher);
        }
        
        public void Register<T, T2, T3>(IEnumerable<ISystem<T, T2, T3>> systems = default, World.World world = default)
            where T : struct, IComponent
            where T2: struct, IComponent
            where T3 : struct, IComponent
        {
            var query = new EntityGroupQuery().Containing<T>().Containing<T2>().Containing<T3>().Build();
            
            if (_entityMatchers.ContainsKey(query))
            {
                Console.WriteLine($"EntityGroup for type {typeof(T)}, {typeof(T2)} {typeof(T3)} already exists!");
                ((EntityGroup<T, T2, T3>) _entityMatchers[query]).AddSystems(systems);
                return;
            }
            
            var _world = world ?? Engine.WorldManager.PrimaryWorld;
            
            var entityMatcher =
                new EntityGroup<T, T2, T3>(ref _world.EntityManager.Components, systems);
            
            _entityMatchers.Add(query, entityMatcher);
        }

        public IEnumerator<IEntityGroup> GetEnumerator()
        {
            foreach (var entityMatcher in _entityMatchers)
            {
                yield return entityMatcher.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}