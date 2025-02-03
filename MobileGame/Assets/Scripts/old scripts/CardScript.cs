using UnityEngine;

public class CardScript : MonoBehaviour
{
    public int rank;
    public Card.SuitEnum suit; // Card suit (Hearts, Diamonds, etc.)


    private void Awake()
    {

    }

    public void SetCardData(int rank, Card.SuitEnum suit)
    {
        this.rank = rank;
        this.suit = suit;
    }

    public Card GetCardData()
    {
        Card card = new(suit, rank);
        return card;
    }

    
}
