﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.AddressableAssets;
using Cysharp.Threading.Tasks;
using UnityEngine.ResourceManagement.AsyncOperations;

public class WebRequestSample : MonoBehaviour
{
    [SerializeField]
    private AssetReference cubePrefab;

    [SerializeField]
    bool on;

    // Start is called before the first frame update
    void  Start()
    {
        Addressables.LoadAssetAsync<GameObject>(cubePrefab).Completed += (obj) =>
        {
            var prefabHandle = obj;
            Instantiate(obj.Result, Vector3.zero, Quaternion.identity);
            Addressables.ReleaseInstance(prefabHandle);
            Addressables.Release(prefabHandle.Result);
        };
    }
}
