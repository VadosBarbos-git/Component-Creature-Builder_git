
using Assets.Mian.Scripts.Components;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody3D;
    private ComponentFactory _componentFactory;


    private Dictionary<ComponentDefinition, ComponentDetails> _components = new();

    public void Init(ComponentManager manager, ComponentFactory componentFactory)
    {
        manager.ChangeAppliedComponents += UpdateAppliedComponents;
        _componentFactory = componentFactory;
    }
    public Rigidbody GetRB() => _rigidbody3D;
    private void UpdateAppliedComponents(List<ComponentDefinition> appliedComponents)
    {
        List<ComponentDefinition> valuesForRemove = _components.Keys.Where(a => !appliedComponents.Contains(a)).ToList();
        foreach (var value in valuesForRemove)
        {
            RemoveComponent(value);
        }
        foreach (var item in appliedComponents)
        {
            if (_components.ContainsKey(item)) continue;
            AddComponent(item);
        }
    }

    private void AddComponent(ComponentDefinition value)
    {
        if (_components.ContainsKey(value)) return;

        GameObject obj = _componentFactory.MakeComponent(value.prefab, transform);
        IComponentEntity component = obj.GetComponent<IComponentEntity>();


        component.Initialize(this);
        ComponentDetails cDetails = new(component, obj);
        _components.Add(value, cDetails);

    }
    private void RemoveComponent(ComponentDefinition key)
    {
        if (!_components.ContainsKey(key)) return;
        _components[key].componentEntity.Disable();
        _componentFactory.DestroyComponet(_components[key].objectComponent);
        _components.Remove(key);
    }

    void FixedUpdate()
    {
        foreach (var ite in _components.Values)
        {
            ite.componentEntity.Tick();
        }
    }
}
