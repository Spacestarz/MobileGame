using System;
using UnityEngine;

public class EventsHere : MonoBehaviour
{
    public static EventsHere Instance;

    //this is bit of a test but this script will have the events
    //They will check what player has done etc

    public Action OnActionEvent;


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


    public void TestMethod()
    {
        Debug.Log("Hello, the event is working!");
    }

    void Update()
    {
        
    }
}
