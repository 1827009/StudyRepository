using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawUI : MonoBehaviour
{
    [SerializeField]
    GameObject target;

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            GetComponent<Text>().text = "おわり";
        }
    }
}
