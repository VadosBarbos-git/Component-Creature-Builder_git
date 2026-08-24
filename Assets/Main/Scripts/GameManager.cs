using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Entity _Entity;
    [SerializeField] private ComponentManager _ComponentManager;
    [SerializeField] private ComponentUIController _ComponentUIController;
    [SerializeField] private ComponentFactory _ComponentFactory;

    void Start()
    {
        _ComponentManager.Init();
        _Entity.Init(_ComponentManager, _ComponentFactory);
        _ComponentUIController.Init(_ComponentManager);
    }


}
