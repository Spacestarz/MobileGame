using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections;

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

    //this gets called everytime it is the AI's turn!
   public void OpponentTurn()
   {

        WinCheck(); 

        if (LastPhase.Instance.LastPhaseAIActive == true)
        {
            LastPhase.Instance.CheckIfLastPhaseStillNeededAI();
        }

        HaveAtLeast3Cards();


        if (OpponentHand.instance.cards.Count == 0 )
        {
            LastPhase.Instance.StartEndPhase();
            Debug.LogWarning("opponent have no cards in hand! It will now take from its tablecards opponentai script row 39");
        }

        CanIPlayAnyCard();

    }


    public void WinCheck()
    {
      if (OpponentHand.instance.cards.Count ==0 && OpponentTableCard.Instance.cards.Count == 0)
      {
            Debug.Log("activating player lost stage");
            PlayerHand.instance.ActivateChildren(PlayerHand.instance._PlayerLostStage, true);
      }
    }

    private void HaveAtLeast3Cards()
    {
        if (EveryCard.instance.cards.Count == 0)
        {
            Debug.Log("everycard have no cards return (opponentAI script row 63)");

            return;
        }

        while (OpponentHand.instance.cards.Count < 3)
        {
            Debug.Log("Ai have at least 3 card method getting cards");
            EveryCard.instance.GetCard();
        }
    }

    private void CanIPlayAnyCard()
    {
        Debug.Log("can i play anycard OPPONENT method");
        TrackingTurns.Instance.CheckCardsVSDropZone();
    }

    public void AiHandCardsVsDropzone()
    {
        Card LatestCard = Dropzone.Instance.cards[Dropzone.Instance.cards.Count - 1];
        Card lowestValidCard = null;

        Debug.Log("Aihandcardsvsdropzone opponentai script row 81");

        foreach (var card in OpponentHand.instance.cards) //this is for opponent hand
        {
            if (card._rank >= LatestCard._rank)
            {
                Debug.Log($"{card._suit} with rank {card._rank} can be put in cardzone");

                if (lowestValidCard == null || card._rank < lowestValidCard._rank)
                {
                    lowestValidCard = card;

                    Debug.Log($"the lowest valid card in the opponenthand is {card._suit} with rank {card._rank}");
                }
            }
            else
            {

                // Debug.LogWarning("sending an observer to change draw card text");
            }
        }

        GetLowerstValidCard(lowestValidCard);
    }

    public void AItablecardsVsDropzone()
    {
        Card LatestCard = Dropzone.Instance.cards[Dropzone.Instance.cards.Count - 1];
        Card lowestValidCard = null;

        Debug.LogWarning("AI IS TAKING FROM ITS TABLECARDS. opponentAI script row 113");

            foreach (var card in OpponentTableCard.Instance.cards)
            {
                if (card._rank >= LatestCard._rank)
                {
                    Debug.Log($"{card._suit} with rank {card._rank} can be put in cardzone");

                    if (lowestValidCard == null || card._rank < lowestValidCard._rank)
                    {
                        lowestValidCard = card;
                    }
                }
            }

        GetLowerstValidCard(lowestValidCard);
    }

    public void GetLowerstValidCard(Card lowestValidCard)
    {
        if (lowestValidCard != null)
        {
            Debug.Log($"Opponent plays the lowest valid card: {lowestValidCard._suit} with rank {lowestValidCard._rank}");
            Dropzone.Instance.PutCardInDropzone(lowestValidCard);
            lowestValidCard = null;
        }
        else
        {
            if (EveryCard.instance.cards.Count == 0)
            {
                Debug.Log("no cards in everycards ai will pick up all in dropzone");
                Dropzone.Instance.GetDropZonePile();
                return;
            }

            Debug.LogWarning("opponent cant play any cards in TRACKINGTURN script");
            Dropzone.Instance._IsTakingAChance = true;
            Dropzone.Instance._OnChangedChanceBool?.Invoke(); //invoke the action _onchangedchancebool in dropzone
                                                              //also got a animatetodropzone in dropzone row 316
        }
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
        OpponentHand.instance.endingturnON = false;
        TrackingTurns.Instance.EndTurn();
    }


}
