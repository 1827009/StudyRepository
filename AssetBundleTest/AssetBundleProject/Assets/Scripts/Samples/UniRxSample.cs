using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx; 

public class UniRxSample : MonoBehaviour
{
    // 通知が送れる変数
    public ReactiveProperty<int> nanika = new ReactiveProperty<int>(100);
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            nanika.Value -= 1;
            Debug.Log("なにか：" + nanika.Value);
        }
    }
}
