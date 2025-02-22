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
        TrackingTurns.Instance.CheckCardsVSDropZone();
    }



}
