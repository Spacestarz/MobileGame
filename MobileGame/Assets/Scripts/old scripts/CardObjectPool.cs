//using System.Collections.Generic;
//using UnityEngine;

//public class CardObjectPool : MonoBehaviour
//{
//    //wait with the pooling thing I REPEAT WAIT

//    //objects in the pool
//    public GameObject _heartPrefab;
//    public GameObject _cloverPrefab;
//    public GameObject _spadePrefab;
//    public GameObject _diamondPrefab;

//    //the max amount
//    [SerializeField] int maxAmount = 52;

//   private List<CardOldScript> allCardsList; //testing

//    //have list with cards from where we can pull the cards from

//    void Start()
//    {
//        /*
//        TODO
//        instantiate the cards so you have em here so they exist but they kinda do in a way? im tired
//        what even is thy poool
//        thy shall drag the cards from the pool so you dont need to instantiate all the cards all the time

//        hantera lista med gameobject
            
//       // allCardsList = new List<Card>(); //testing

//        //first for suit
//        for (int s = 1; s <= 4; s++)
//        {
            
//            //second for ranks
//            for (global::System.Int32 r = 1; r <= 13; r++)
//            {
//                var wholedeck = new Card((Card.SuitEnum)s, r);

//                allCardsList.Add(wholedeck);
//                //made the whole "deck" now
//            }

//        }
        
//    }

//    void Update()
//    {
//        /*
//        if (Input.GetKeyDown(KeyCode.F))
//        {
//            GoThroughDeck();
//        }
//        */
//    }
    
//    private void GoThroughDeck()
//    {
//        foreach (var card in allCardsList)
//        {
//            Debug.Log($"Card: {card}, Suit: {card._suit}, Rank: {card._rank}");
//        }
//    }

//    private void OnDisable() //clear list when done
//    {
        
           
//        allCardsList?.Clear();
//    }

//    public void DestroyCard()
//    {

//    }
//}
