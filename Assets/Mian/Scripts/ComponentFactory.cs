
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
        else _pool[nameC].SetActive(true);

        return _pool[nameC];
    }
    public void DestroyComponet(string nameComponent)
    {
        if (!_pool.ContainsKey(nameComponent)) return;
        _pool[nameComponent].SetActive(false);
    }
}

