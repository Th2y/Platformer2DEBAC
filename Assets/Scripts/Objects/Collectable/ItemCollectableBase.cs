using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{
    [SerializeField] protected string tagPlayer = "Player";
    [SerializeField] protected int value = 1;

    [SerializeField] protected ParticleSystem particle;
    [SerializeField] protected float timeToDisableParticle = 1f;

    protected Transform particleParent;

    private void Start()
    {
        particleParent = GameManager.Instance.particleParent;

        if(particle != null) particle.transform.SetParent(particleParent);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(tagPlayer))
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        gameObject.SetActive(false);
        OnCollect();
    }

    protected virtual void OnCollect()
    {
        
    }

    protected void DisabeleParticle()
    {
        if(particle != null) particle.gameObject.SetActive(false);
    }
}
