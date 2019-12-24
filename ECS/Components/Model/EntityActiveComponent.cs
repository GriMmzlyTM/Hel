namespace Hel.ECS.Components.Model
{
    /// <summary>
    /// Sets if the entity this is attached to is active at all. Inactive entities are not sent to any system. 
    /// </summary>
    public struct EntityActiveComponent : IComponent
    {
        public bool Active { get; set; }
    }
}
