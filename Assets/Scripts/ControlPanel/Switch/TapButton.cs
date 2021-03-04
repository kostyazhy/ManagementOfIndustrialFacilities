using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapButton : MonoBehaviour
{
    private Transform _transform;
    private Vector3 _chageScale = new Vector3(0, 0.1f, 0);
    private float _delay = 1.5f;

    void Start()
    {
        _transform = transform;        
    }

    public void Tap()
    {
        _transform.localScale = _transform.localScale - _chageScale;
        StartCoroutine(ButtonNorm());
    }

    public IEnumerator ButtonNorm()
    {
        yield return new WaitForSeconds(_delay);
        _transform.localScale = _transform.localScale + _chageScale;
    }
    
}
