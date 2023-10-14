using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsText;

    private int coins;

    public static ItemManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins = 0;
        coinsText.text = coins.ToString();
    }

    public void AddCoins(int amount = 1)
    {
        coins += amount;
        coinsText.text = coins.ToString();
    }
}
