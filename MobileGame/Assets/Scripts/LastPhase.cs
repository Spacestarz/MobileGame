using NaughtyAttributes;
using UnityEngine;

public class LastPhase : MonoBehaviour
{
    public static LastPhase Instance;

    public bool LastPhaseActive = false;
    //here i will put logic with the last phase
    //when player have no cards in their hand and want to now activate tablecards cards

    //when those that are visible is gone i want to make the same effect when taking a chance is on (the animation etc)
    //with the cards that are upside down

    // im making this a seperate script because i got so much going on in the other scripts
    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [Button]
    public void StartEndPhase() //this should work for both opponent and player
    {
        LastPhaseActive = true;
        Dropzone.Instance._IsTakingAChance = true;

        PlayerTableCards.instance.MakeVisibleCardsInteractable();
        
        Debug.LogWarning("lastphase active player");
        //this i will activate when the player have no cards in their hand.
        //and want to activate the cards on the table
    }

    public void endlastphase()
    {
        Debug.Log("ending lastphase player");
        LastPhaseActive = false;
        Dropzone.Instance._IsTakingAChance = true;
    }

    public void CheckIfLastPhaseStillNeeded()
    {
        int cardcount = 0;

        //checking if any card is in playerhand
       if  (PlayerHand.instance.cards.Count == 0)
        {
            
        }
        else
        {
             LastPhaseActive = false;
        }

       //checking if any cards are in playertablecard if not then activate the invisible cards
        foreach (var card in PlayerTableCards.instance.cards)
        {
           if ( card.CompareTag("Card"))
            {
                cardcount++;
            }
            
        }

        if (cardcount == 0)
        {
            PlayerTableCards.instance.MakeInvisibleCardsInteractable();
          
        }
    }

}
