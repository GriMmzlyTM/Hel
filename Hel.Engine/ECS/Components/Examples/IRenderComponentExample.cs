using Hel.Engine.ECS.Components.Model;

namespace Hel.Engine.ECS.Components.Examples
{
    public interface IRenderComponentExample : IComponent
    {
        public ushort ZIndex { get; set; }
    }
}