using System.Collections.Generic;
using UnityEngine;

public class PlayerTableCards : CardPile 
{
    public static PlayerTableCards instance;

    public List<Card> _CardPlayerTable;

    public override void AddCard(Card cardToAdd)
    {
        _CardPlayerTable.Add(cardToAdd);
        Debug.Log($"Adding {cardToAdd._suit} with rank {cardToAdd._rank} to CardPlayerCards");
    }

    public override void RemoveCard(Card cardToRemove)
    {
        _CardPlayerTable.Remove(cardToRemove);
        Debug.Log($"Removing  {cardToRemove._suit}  with rank  {cardToRemove._rank}  from dropzone");
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        _CardPlayerTable = new List<Card>();
    }

    void Start()
    {
        
    }

    void Update()
    {
       
      
    }
}
