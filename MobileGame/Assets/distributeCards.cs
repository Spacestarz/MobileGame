using UnityEngine;

public class distributeCards : MonoBehaviour
{
   private CardManager cardManager;
    void Start()
    {
       cardManager = GetComponent<CardManager>();
       
    }
  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (cardManager.allCardsList.Count > 0)
            {
                int randomIndex = Random.Range(0, cardManager.allCardsList.Count);
                Distribute(randomIndex);
            }
        }
    }

    public void Distribute(int index)
    {
        if ( index >= 0 && index < cardManager.allCardsList.Count) //ensure index is valid
        {
            Card card = cardManager.allCardsList[index];
            Debug.Log($"Retrieving card. Suit: {card._suit} Rank: {card._rank}");

            cardManager.allCardsList.Remove(card);
            Debug.Log($"Removing suit {card._suit} rank: {card._rank}");

            cardManager.DiscardList.Add(card);
            Debug.Log($"Adding suit {card._suit} rank: {card._rank}");
        }
       
        //take cards from the object pool and then you get a random cards. 
        //same with death he should get random cards. 

        //probably use random.list.count (not how you do that but you know what do do)
    }
}
