using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Cysharp.Threading.Tasks;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float spead = 1.0f;
    [SerializeField]
    float powor = 1500.0f;

    [SerializeField]
    private AssetReference bulletPrefab;

    AsyncOperationHandle<GameObject> bullet;
    private AsyncOperationHandle mate;

    // Start is called before the first frame update
    void Start()
    {
        bullet = Addressables.LoadAssetAsync<GameObject>(bulletPrefab);
        mate = Addressables.DownloadDependenciesAsync(bulletPrefab);
    }
    private void OnDestroy()
    {
        Debug.Log("プレイヤーのResourceのリリース開始");
        Addressables.ReleaseInstance(mate);
        Addressables.ReleaseInstance(bullet);
        Debug.Log("プレイヤーのResourceのリリース終了");
    }

    // Update is called once per frame
    async void Update()
    {
        float timeSpeed = Time.deltaTime * spead;
        //if (Input.GetKey(KeyCode.W))
            //transform.Translate(Vector3.forward * timeSpeed);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * timeSpeed);
        //if (Input.GetKey(KeyCode.S))
            //transform.Translate(Vector3.back * timeSpeed);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * timeSpeed);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var b = Instantiate(bullet.Result, transform.position + new Vector3(0, 0, 1.5f), Quaternion.identity);
            b.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, powor));
            await bulletDestroy(b);
        }

        if (Input.GetKey(KeyCode.Escape))
            Destroy(gameObject);
    } 
    async UniTask bulletDestroy(GameObject b)
    {
        await UniTask.Delay(1000);
        GameObject.Destroy(b);
    }
}
