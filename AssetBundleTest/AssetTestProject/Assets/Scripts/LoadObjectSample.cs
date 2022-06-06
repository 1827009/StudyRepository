using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class LoadObjectSample : MonoBehaviour
{
    [SerializeField]
    List<string> callObject;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in callObject)
        {
            var handle = Addressables.InstantiateAsync(item);
        }
    }
}
