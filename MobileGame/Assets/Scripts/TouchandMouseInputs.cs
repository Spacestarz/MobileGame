using UnityEngine;
using DG.Tweening;

public class TouchandMouseInputs : MonoBehaviour
{
    //will test mouseinput and touch here
    // watched a yt thing https://www.youtube.com/watch?v=aTtheFyh7Ac

    private Vector2 _orgScaleCard;
    private Vector2 _zoomScaleCard;

    [SerializeField] private float _zoomScale = 0.5f;
    [SerializeField] private float _zoomDuration = 2f;

    void Start()
    {
        
    }

    void Update()
    {

        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[0].position);

            RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log($"touched object {hit.collider.name}");
                
            }
        }
        
#if UNITY_EDITOR //if you are in the unity editor. Cool thing i am learning yay
        if (Input.GetMouseButtonDown(0))
        {
            
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log($"you touch/click {hit.collider.name}");

                Transform cardtransform = hit.collider.transform;
                _orgScaleCard = cardtransform.localScale;

                //HAVE TO MAKE A LIMIt also
                //make so the card dont go out of bound of the screen so it adapts to screen!

                //also make so that card that zooms gets put above the other cards
                cardtransform.DOScale(_orgScaleCard * _zoomScale, _zoomDuration);
                
            }
            else
            {
                Debug.Log("you diden hit anything");
            }
        }
#endif
        
    }
}
