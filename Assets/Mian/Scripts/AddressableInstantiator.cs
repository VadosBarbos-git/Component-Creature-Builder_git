
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.InputSystem;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressableInstantiator : MonoBehaviour
{
    [SerializeField] private AssetReferenceGameObject _enviroment;
    [SerializeField] private Transform _parentForEnviroment;
    private InputAction _loadAssetButton;

    private void Start()
    {
        _loadAssetButton = InputSystem.actions.FindAction("LoadAssets");
    }
    // Update is called once per frame
    void Update()
    {

        if (_loadAssetButton.WasPressedThisFrame())
        {
            Debug.Log("Presed I");
            _enviroment.LoadAssetAsync().Completed += OnAddressableLoaded;
        }
    }
    void OnAddressableLoaded(AsyncOperationHandle<GameObject> handle)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
            Instantiate(handle.Result, _parentForEnviroment);
        else Debug.LogError("Loading Asset Failed!");
    }
}
