using UnityEngine;

public class CardVisuals : MonoBehaviour
{
    //this should move the visuals on the card! On the child from cardobject!
    //so the scripts wont argue.

    public bool _followMouse;
    public GameObject _ClickedCard;

    Vector2 _orgPos;
    //reference to the pic
 Stashed changes
    //reference to the pic
 Stashed changes
    //reference to the pic
 Stashed changes

 
    void Start()
    {
        _orgPos = transform.position; //gets the cards orgpos
        
 Stashed changes
        
 Stashed changes
 Stashed changes
    }

    void Update()
    {
        if (_followMouse) //when followmouse is true. FollowMouse   
        {
            Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            _ClickedCard = this.gameObject;
            transform.position = mousepos;

        }
        else
        {
            //when followmouse is false. ClickedCard is Null.
            _ClickedCard = null;
            transform.position = _orgPos; 
        }
    }

    
     
    }

     
    }

 Stashed changes
     
    }
 Stashed changes

    public void Init(Card card) //make the card get its gameobject here probarly with the prefabs? 
    {
        Debug.Log("programming jeho");


        //switch (_suit)
        //{
        //    case suitenum.hearts:
        //        return instantiate(heartsprefab);
        //        break;

        //    case suitenum.diamonds:
        //        return instantiate(diamondprefab);
        //        break;

        //    case suitenum.spades:
        //        return instantiate(spadeprefab);
        //        break;

        //    case suitenum.clubs:
        //        return instantiate(cloverprefab);
        //        break;


        //    default:
        //        {

        //            return null;
        //        }

        //}



        // on card hovered - do hover visuals
        // etc
    }
}
