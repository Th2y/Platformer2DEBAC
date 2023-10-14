using UnityEngine;

public class AnimatorEvents : MonoBehaviour
{
    [SerializeField] private GameObject objectToDestroy;
    [SerializeField] private float delay = 1f;

    public void DestroyOnDeath()
    {
        Destroy(objectToDestroy, delay);
    }
}
