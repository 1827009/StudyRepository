using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Cysharp.Threading.Tasks;
using System.Threading;

public class GenarateObjects : MonoBehaviour
{
    [SerializeField]
    private AssetReference enemyPrefabs;

    private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

    AsyncOperationHandle<GameObject> enemy;
    private AsyncOperationHandle mate;

    // Start is called before the first frame update
    async void Start()
    {
        enemy = Addressables.LoadAssetAsync<GameObject>(enemyPrefabs);
        mate = Addressables.DownloadDependenciesAsync(enemyPrefabs);
        await enemy.Task;
        await Genarate(_cancellationTokenSource.Token);
    }
    async UniTask Genarate(CancellationToken token = default)
    {
        while (!token.IsCancellationRequested)
        {
            Instantiate(enemy.Result, new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5)), Quaternion.identity);
            await UniTask.Delay(3000);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("消去");
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        Debug.Log("敵のResourceのリリース開始");
        _cancellationTokenSource.Cancel();
        Addressables.ReleaseInstance(enemy);
        Addressables.ReleaseInstance(mate);
        Debug.Log("敵のResourceのリリース完了");

        Application.Quit();
    }
}
