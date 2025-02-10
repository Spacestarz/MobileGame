using UnityEngine;

<<<<<<< Updated upstream
<<<<<<< Updated upstream
public class HoverOverCard : MonoBehaviour
{
    //this script talk to 1 script (cardvisualscript)
    private CardVisuals cardVisualsScript;
    private GameObject _lastHoverCard;

=======
//public class HoverOverCard : MonoBehaviour
//{
//    //this script talk to 1 script (cardvisualscript)

//    private CardVisuals cardVisualsScript;

//    public bool CanIHover = false;

//    private float MoveUp = 0.30f;
//    private Vector3 IamHovering;
>>>>>>> Stashed changes

=======
//public class HoverOverCard : MonoBehaviour
//{
//    //this script talk to 1 script (cardvisualscript)

//    private CardVisuals cardVisualsScript;

//    public bool CanIHover = false;

//    private float MoveUp = 0.30f;
//    private Vector3 IamHovering;

>>>>>>> Stashed changes
//    //this should move the visuals on the card! On the child from cardobject!


//    void Start()
//    {
//        cardVisualsScript = GetComponent<CardVisuals>();
//    }

//    void Update()
//    {
        
//    }

<<<<<<< Updated upstream
<<<<<<< Updated upstream
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
=======
//    private void OnMouseEnter()
//    {
//        if (cardVisualsScript._followMouse == false) //if no card is following mouse
//        {
//            if (InputManager.Instance._lastHoverCard == this.gameObject)
//            {
//                Debug.Log("I cant hovor i did it last lol");
//                return;
//            }
//            cardVisualsScript.CanIHover(); //checking if card can hover

//            if (CanIHover)
//            {
//                InputManager.Instance._lastHoverCard = this.gameObject;
//                float newpos = cardVisualsScript._orgPos.y += MoveUp;
//                IamHovering = new Vector3(cardVisualsScript._orgPos.x, newpos, cardVisualsScript._orgPos.z);

//                transform.position = IamHovering;         
//            }
//            else
//            {
//                Debug.Log("cant hove rsoooory");
//            }
          
//        }

//        if (CanIHover == false  )
//        {
//            return;
//        }
//    }

=======
//    private void OnMouseEnter()
//    {
//        if (cardVisualsScript._followMouse == false) //if no card is following mouse
//        {
//            if (InputManager.Instance._lastHoverCard == this.gameObject)
//            {
//                Debug.Log("I cant hovor i did it last lol");
//                return;
//            }
//            cardVisualsScript.CanIHover(); //checking if card can hover

//            if (CanIHover)
//            {
//                InputManager.Instance._lastHoverCard = this.gameObject;
//                float newpos = cardVisualsScript._orgPos.y += MoveUp;
//                IamHovering = new Vector3(cardVisualsScript._orgPos.x, newpos, cardVisualsScript._orgPos.z);

//                transform.position = IamHovering;         
//            }
//            else
//            {
//                Debug.Log("cant hove rsoooory");
//            }
          
//        }

//        if (CanIHover == false  )
//        {
//            return;
//        }
//    }

>>>>>>> Stashed changes
//    private void OnMouseExit()
//    {
//        CanIHover = false;
//        cardVisualsScript.GoBackOrgPos();
//    }
//}
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
