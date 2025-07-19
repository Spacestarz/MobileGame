using TMPro;
using UnityEngine;

public class SavePlayerPrefs : MonoBehaviour
{
    public static SavePlayerPrefs instance;

    private const string TenCardCountKey = "PlayerTenCardCount";
    private int tenCardsCount;

    [SerializeField] private TextMeshProUGUI textTenCardCount;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (TenCardCountKey != null)
        {
            tenCardsCount = PlayerPrefs.GetInt(TenCardCountKey);
            
            textTenCardCount.text = $"{tenCardsCount} number 10 cards";
        }
    }

    public void IncreaseTenCardUsedPlayer()
    {
        int current = PlayerPrefs.GetInt(TenCardCountKey, 0);
        current++; 
        PlayerPrefs.SetInt(TenCardCountKey, current);
        PlayerPrefs.Save();
    }
}
