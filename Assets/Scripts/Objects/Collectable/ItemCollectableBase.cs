using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{
    [SerializeField] protected string tagPlayer = "Player";
    [SerializeField] protected int value = 1;

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
}
