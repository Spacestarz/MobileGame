using System.Collections.Generic;
using UnityEngine;

public class PlayerTableCards : CardPile 
{
    public static PlayerTableCards instance;

    public List<Card> _CardPlayerTable;

    public override void AddCard(Card cardToAdd)
    {
        _CardPlayerTable.Add(cardToAdd);
    }

    public override void RemoveCard(Card cardToRemove)
    {
        _CardPlayerTable.Remove(cardToRemove);
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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
      
    }
}
