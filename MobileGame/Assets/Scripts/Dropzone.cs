using System.Collections.Generic;
using UnityEngine;

public class Dropzone : CardPile
{
    public static Dropzone Instance;
    public List<Card> _dropZoneList;

    public override void AddCard(Card cardToAdd)
    {
        _dropZoneList.Add(cardToAdd);
        Debug.Log($"Adding {cardToAdd._suit} and rank {cardToAdd._rank} from Dropzone");
    }

    public override void RemoveCard(Card cardToRemove)
    {
        _dropZoneList.Remove(cardToRemove);
        Debug.Log($"Removing {cardToRemove._suit} and rank {cardToRemove._rank} from dropzone");
    }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        _dropZoneList = new List<Card>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
