using UnityEngine;

public class WinGame : MonoBehaviour
{
    [SerializeField] private string playerTag = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            GameManager.Instance.ShowPanelWin();
        }
    }
}
