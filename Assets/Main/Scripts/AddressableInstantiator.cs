
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.InputSystem;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressableInstantiator : MonoBehaviour
{
    [SerializeField] private AssetReferenceGameObject _enviroment;
    [SerializeField] private Transform _parentForEnviroment;
    private InputAction _loadAssetButton;
    private bool _loaded = false;

    private void Start()
    {
        _loadAssetButton = InputSystem.actions.FindAction("LoadAssets");
        LoadAsset();
    }
    void Update()
    {
        if (!_loaded && _loadAssetButton.WasPressedThisFrame())
        {
            Debug.Log("Presed I");
            LoadAsset();
        }
    }
    private void LoadAsset()
    {
        _enviroment.LoadAssetAsync().Completed += OnAddressableLoaded;
    }
    private void OnAddressableLoaded(AsyncOperationHandle<GameObject> handle)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            _loaded = true;
            Instantiate(handle.Result, _parentForEnviroment);
        }
        else Debug.LogError("Loading Asset Failed!");
    }
}
