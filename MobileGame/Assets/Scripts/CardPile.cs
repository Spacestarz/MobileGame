using System.Collections.Generic;
using UnityEngine;

public abstract class CardPile
{
    public List<Card> AllCardlist;
    public List <Card> PlayerHandList;
    public List<Card> OpponentHandList;
    public List<Card> DropZoneList;
    public List<Card> DiscardList;

    private void Start()
    {
        //time to make the whole deck thing. 
        //1-4 for the suit and then the rank 1-13 for each of the suits 

        //first for suit
        for (int s = 1; s <=4; s++)
        {
            //second for ranks
            for (global::System.Int32 r = 1; r <= 13; r++)
            {
               

              // AllCardlist.add(wholedeck);
                //made the whole "deck" now
            }
        }
    }
    
    
    public void AddCard(Card card) //Here you will add cards to lists
    {
      
    }

    public void RemoveCard(Card card) //Here you will remove cards from lists
    {
        
    }
}


