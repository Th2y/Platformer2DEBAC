using System.Collections;
using UnityEngine;

public class TranslateGameObject : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Vector3 _value => speed * Vector3.right;

    private Coroutine _currentCoroutine;
    private WaitForSeconds _waitForSeconds => new WaitForSeconds(10f);

    private void Update()
    {
        _currentCoroutine ??= StartCoroutine(ChangeSide());

        transform.Translate(_value * Time.deltaTime);
    }

    private IEnumerator ChangeSide()
    {
        yield return _waitForSeconds;

        speed = -speed;

        StopCoroutine(_currentCoroutine);
        _currentCoroutine = null;
    }
}
