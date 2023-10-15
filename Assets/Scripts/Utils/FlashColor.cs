using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class FlashColor : MonoBehaviour
{
    [Header("Damage")]
    [SerializeField] private List<SpriteRenderer> damageRenderers;
    [SerializeField] private Color damageColor;
    [SerializeField] private float damageDuration = .2f;

    private Tween _damageCurrentTween;

    private void OnValidate()
    {
        if(damageRenderers == null || damageRenderers.Count == 0)
        {
            damageRenderers = new List<SpriteRenderer>();

            foreach (var renderer in transform.GetComponentsInChildren<SpriteRenderer>())
            {
                damageRenderers.Add(renderer);
            }
        }
    }

    public void DamageFlash()
    {
        if(_damageCurrentTween != null)
        {
            _damageCurrentTween.Kill();
            damageRenderers.ForEach(i => i.color = Color.white);
        }

        foreach (var renderer in damageRenderers)
        {
            renderer.DOColor(damageColor, damageDuration).SetLoops(2, LoopType.Yoyo);
        }
    }
}
