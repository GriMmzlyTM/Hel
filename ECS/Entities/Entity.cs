namespace Hel.ECS.Entities
{
    /// <summary>
    /// IEntity is the base component all entities need to use. 
    /// The entire ECS system uses the IEntity interface to store, remove
    /// and send entities to their respective systems. 
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// The ID of the entity in the world. 
        /// This Id needs to be unique. If no ID is provided 
        /// when creating the entity, an ID will be assigned 
        /// when passed to the entity manager.
        /// </summary>
        uint Id { get; }

        /// <summary>
        /// Whether or not the entity is active. 
        /// Active is set to FALSE by default.
        /// Inactive entities should be ignored by systems 
        /// by default. When creating your systems, make sure to check 
        /// the active state. 
        /// 
        /// Active is NOT checked prior to sending entities to a system 
        /// due to the fact that some systems may want to run regardless of
        /// activation state. 
        /// </summary>
        bool Active { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">The ID to set </param>
        void SetId(uint id);
    }

}
