using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;

public class OpponentAi : CardPile
{
    public static OpponentAi Instance;

    [SerializeField] private ButtonInteractable _EndButtonInteractScript;



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
        CanIPlayAnyCard();
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
    }

    public void EndAiTurn()
    {
        TrackingTurns.Instance.EndTurn();
    }


}
