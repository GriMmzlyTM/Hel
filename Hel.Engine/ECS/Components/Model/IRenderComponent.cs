namespace Hel.Engine.ECS.Components.Model
{
    public interface IRenderComponent : IComponent
    {
        public ushort ZIndex { get; set; }
    }
}