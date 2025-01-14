using TMPro;
using UnityEngine;

public class CardsCount : MonoBehaviour
{
    [SerializeField] private int _HowManyCards = 0;
    public bool NoMoreCards = false;

    public TextMeshProUGUI _CardCountText;

    private SpadeCards SpadeCards;
    private HeartCards HeartCards;
    private DiamondCards DiamondCards;
    private CloverCards CloverCards;


    //scritableobjects when have a lot of things with similar thing like different weapons
    //finns 13 kort av varje spader, hearts etc
    //göra spader, hearts in a list and when k heart is gone it gets removed in the list?

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpadeCards = GetComponent<SpadeCards>();
        HeartCards = GetComponent<HeartCards>();
        DiamondCards = GetComponent<DiamondCards>();
        CloverCards = GetComponent<CloverCards>();

        //_CardCountText = GetComponent<TextMeshProUGUI>();

        _HowManyCards = SpadeCards._SpadeCount + HeartCards._heartCount + DiamondCards._DiamondCount + CloverCards._CloverCount;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ChangeCount();
        }

        if (_HowManyCards == 0)
        {
            NoMoreCards = true;
            Debug.Log("No cards left");
        }
    }

    private void ChangeCount()
    {
        _CardCountText.text = _HowManyCards.ToString() + " " + "cards left";
    }
}
