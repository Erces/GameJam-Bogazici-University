using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Cloud : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();
        transform.DOScale(transform.localScale * Random.Range(0.85f,1.1f), Random.Range(6,12)).SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
