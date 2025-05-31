using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;

public class OpponentAi : CardPile
{
    public static OpponentAi Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        cards = new List<Card>();
    }

   public void OpponentTurn()
   {

        WinCheck(); 

        HaveAtLeast3Cards();
        CanIPlayAnyCard();
        if (OpponentHand.instance.cards.Count == 0 )
        {
            Debug.LogWarning("opponent have no cards in hand! It will now take from its tablecards");
        }

   }

    public void CardsandDropZoneCheckAI()
    {

    }

    public void WinCheck()
    {
      if (OpponentHand.instance.cards.Count ==0 && OpponentTableCard.Instance.cards.Count == 0)
      {
            Debug.LogWarning("AI HAS WON");
      }
    }

    private void HaveAtLeast3Cards()
    {
        while (OpponentHand.instance.cards.Count < 3)
        {
            EveryCard.instance.GetCard();
        }
    }

    private void CanIPlayAnyCard()
    {
        Debug.Log("can i play anycard OPPONENT method");
        TrackingTurns.Instance.CheckCardsVSDropZone();
    }

    [Button]
    public void GuessCard()
    {
        Debug.Log("opponentAI script guesscard method");
        //make the ai guess a card if they cant play any card
        EveryCard.instance.GetCard();
    }

    public void EndAITurnDelay()
    {
        Invoke("EndAiTurn", 2f);
        OpponentHand.instance.endingturnON = true;
    }

    public void EndAiTurn()
    {
        TrackingTurns.Instance.EndTurn();
        OpponentHand.instance.endingturnON = false;
    }


}
