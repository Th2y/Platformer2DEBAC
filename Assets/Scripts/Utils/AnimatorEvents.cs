using UnityEngine;

public class AnimatorEvents : MonoBehaviour
{
    [Header("Death")]
    [SerializeField] private GameObject objectToDestroy;
    [SerializeField] private float delay = 1f;

    [Header("References")]
    [SerializeField] private Animator animator;
    [SerializeField] private SOStringAnimations stringAnimations;

    public void DestroyOnDeath()
    {
        Destroy(objectToDestroy, delay);
    }

    public void PauseAttackAnim()
    {
        animator.SetBool(stringAnimations.Attack, false);
    }
}
