using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CashManager : MonoBehaviour
{
    public static CashManager instance;

    [Header("Settngs")]
    private int coins;
    [SerializeField] private TextMeshProUGUI coinContainer;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(gameObject);

        LoadData();
        UpdateCoinContainer();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        UpdateCoinContainer();
        Debug.Log("You Have " + coins + " coins");
        SaveData();
    }

    private void LoadData()
    {
        coins = PlayerPrefs.GetInt("Coins");
    }

    private void UpdateCoinContainer()
    {
        coinContainer.text = coins.ToString();
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt("Coins", coins);
    }
}
