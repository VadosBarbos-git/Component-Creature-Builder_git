
using UnityEngine;

namespace Assets.Main.Scripts.Components
{
    public class ComponentDetails
    {
        public readonly IComponentEntity componentEntity;
        public readonly GameObject objectComponent;
        public ComponentDetails(IComponentEntity component, GameObject objectEntity)
        {
            this.componentEntity = component;
            this.objectComponent = objectEntity;
        }
    }
}