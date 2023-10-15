using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class FlashColor : MonoBehaviour
{
    [SerializeField] private List<SpriteRenderer> renderers;
    [SerializeField] private Color flashColor;
    [SerializeField] private float duration = .3f;

    private Tween _currentTween;

    private void OnValidate()
    {
        renderers = new List<SpriteRenderer>();

        foreach (var renderer in transform.GetComponentsInChildren<SpriteRenderer>())
        {
            renderers.Add(renderer);
        }
    }

    public void Flash()
    {
        if(_currentTween != null)
        {
            _currentTween.Kill();
            renderers.ForEach(i => i.color = Color.white);
        }

        foreach (var renderer in renderers)
        {
            renderer.DOColor(flashColor, duration).SetLoops(2, LoopType.Yoyo);
        }
    }
}
