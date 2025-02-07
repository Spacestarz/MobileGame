using UnityEngine;

public class HoverOverCard : MonoBehaviour
{
    //this script talk to 1 script (cardvisualscript)
    private CardVisuals cardVisualsScript;
    private GameObject _lastHoverCard;


    //this should move the visuals on the card! On the child from cardobject!


    void Start()
    {
        cardVisualsScript = GetComponent<CardVisuals>();
    }

    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        if (cardVisualsScript._followMouse == false) //if no card is following mouse
        {

        }
    }

    private void OnMouseExit()
    {
        
    }
}
