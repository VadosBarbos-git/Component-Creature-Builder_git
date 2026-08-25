
using System.Collections.Generic;
using UnityEngine;


public class ComponentFactory : MonoBehaviour
{
    private Dictionary<string, GameObject> _pool = new();
    public GameObject MakeComponent(ComponentDefinition componentDefinition, Transform transform)
    {
        string nameC = componentDefinition.nameComponent;

        if (!_pool.ContainsKey(nameC))
        {
            var result = Instantiate(componentDefinition.prefab, transform);
            _pool.Add(nameC, result);
            return result;
        }
        return null;
    }
    public bool TryGetCompnentFromPool(out GameObject obj, ComponentDefinition componentDefinition)
    {
        string nameC = componentDefinition.nameComponent;
        bool result = _pool.ContainsKey(nameC);
        obj = null;

        if (result)
        {
            obj = _pool[nameC];
            obj.SetActive(true);
        }
        return result;
    }
    public void HideComponent(string nameComponent)
    {
        if (!_pool.ContainsKey(nameComponent)) return;
        _pool[nameComponent].SetActive(false);
    }
}

