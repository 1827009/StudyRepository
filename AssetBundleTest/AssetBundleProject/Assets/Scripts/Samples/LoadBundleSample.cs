using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LoadBundleSample : MonoBehaviour
{
    [SerializeField]
    private AssetReference cubePrefab;

    // Start is called before the first frame update
    void Start()
    {
        Addressables.LoadAssetAsync<GameObject>(cubePrefab).Completed += (obj) =>
        {
            Addressables.DownloadDependenciesAsync(cubePrefab);
            var prefabHandle = obj;
            Instantiate(obj.Result, Vector3.zero, Quaternion.identity);
            Addressables.ReleaseInstance(prefabHandle);
            Addressables.Release(prefabHandle.Result);
        };
    }
}
