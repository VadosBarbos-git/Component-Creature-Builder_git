
using System.Collections.Generic;
using UnityEngine;


public class ComponentFactory : MonoBehaviour
{
    private Dictionary<string, GameObject> _pool = new();
    public GameObject MakeComponent(ComponentDefinition componentDefinition, Transform transform)
    {
        string nameC = componentDefinition.nameComponent;

        if (!_pool.ContainsKey(nameC))
            _pool.Add(nameC, Instantiate(componentDefinition.prefab, transform)); 
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
    public void HideComponet(string nameComponent)
    {
        if (!_pool.ContainsKey(nameComponent)) return;
        _pool[nameComponent].SetActive(false);
    }
}

