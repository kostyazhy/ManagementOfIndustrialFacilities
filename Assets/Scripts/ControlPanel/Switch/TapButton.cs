using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapButton : MonoBehaviour
{
    [SerializeField]
    private Transform _transform;
    private Vector3 _chageScale = new Vector3(0, 1f, 0);
    private float _delay = 0.5f;

    public void Tap()
    {
        _transform.localScale = _transform.localScale - _chageScale;
    }

    public void ReleaseButton()
    {
        StartCoroutine(ButtonNorm());
    }

    public IEnumerator ButtonNorm()
    {
        yield return new WaitForSeconds(_delay);
        _transform.localScale = _transform.localScale + _chageScale;
    }
    
}
