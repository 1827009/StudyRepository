using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UniRxSample2 : MonoBehaviour
{
    // Start is called before the first frame update
    public UniRxSample sample1;

    void Start()
    {
        // sample1.nanikaが変化したら通知を受けられる
        sample1.nanika.Subscribe(humetu => EventMethod(humetu));
    }

    // Update is called once per frame
    public void EventMethod(int n) {
        Debug.Log("なんか変更" + n);
    }
}
