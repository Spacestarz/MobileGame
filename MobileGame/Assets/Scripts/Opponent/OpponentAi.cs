using System.Collections.Generic;
using UnityEngine;

public class OpponentAi : CardPile
{
    public static OpponentAi instance;

   
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        cards = new List<Card>();
    }


   public void OpponentTurn()
   {
        CanIPlayAnyCard();
   }

    private void CanIPlayAnyCard()
    {
        Debug.Log("can i play anycard OPPONENT method");
        TrackingTurns.Instance.CheckCardsVSDropZone();
    }

    public void GuessCard()
    {
        //make the ai guess a card if they cant play any card
        EveryCard.instance.GetCard();
    }

    private void EndMyTurn()
    {

    }


}
