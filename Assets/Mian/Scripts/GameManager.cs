using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Entity _Entity;
    [SerializeField] private ComponentManager _ComponentManager;
    [SerializeField] private ComponentPresenter _ComponentPresenter;
    void Start()
    {
        _ComponentManager.Init();
        _ComponentPresenter.Init(_ComponentManager);
        _Entity.Init(_ComponentManager); 
    }

    
}
