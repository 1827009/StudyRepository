using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class ObservableSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 更新ごとにイベント
        TimeSpan time = TimeSpan.FromSeconds(2);
        this.UpdateAsObservable()
            //.Where(_ => Input.GetKeyDown(KeyCode.Space))// 条件
            .ThrottleFirst(time)// クールタイム
            .Subscribe(_ => SampleMethod());// 呼び出し先

        IObservable<string> result = GetString();
        result.Subscribe(x => Debug.Log(x));
    }

    #region sample用Method

    void SampleMethod()
    {
        Debug.Log("SampleMethod");
    }

    #endregion

    #region コルーチンをObservableで包んで返り値をもらう

    IObservable<string> GetString()
    {
        var result=Observable.FromCoroutine<string>(o => StringSample(o));

        return result;
    }

    IEnumerator StringSample(IObserver<string> observable)
    {
        yield return new WaitForSeconds(2);

        observable.OnNext("StringGet!");
        observable.OnCompleted();
    }

    #endregion
}
