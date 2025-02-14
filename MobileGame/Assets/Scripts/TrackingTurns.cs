using NUnit.Framework.Constraints;
using UnityEngine;

public class TrackingTurns : MonoBehaviour
{
    public static TrackingTurns Instance;

    //this class will track what player/opponent can do.
    //and it will check if you have done it and you cant do it again etc. 

    //probarly best to just have an observer? like if player has drawn 1 card it cant do it again etc

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

    public void PlayerCheck()
    {
        //here i will check if player has done all they can do
        //so the only option left will be to click the end turn button
    }

    public void OpponentCheck()
    {
        //same as above but with opponent
    }
}
