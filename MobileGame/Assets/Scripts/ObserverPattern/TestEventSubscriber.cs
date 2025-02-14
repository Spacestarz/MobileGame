using UnityEngine;
using System;

public class TestEventSubscriber : MonoBehaviour
{
    private TestingEvents _testingEvents;
    void Start()
    {
        _testingEvents = GetComponent<TestingEvents>();
        _testingEvents.OnSpacePressed += TestingEvents_OnSpacePressed;

        //subscribing to the action event
        _testingEvents.OnActionEvent += _testingEvents_OnActionEvent;
    }

    private void _testingEvents_OnActionEvent(bool arg1, int arg2)
    {
        Debug.Log($"{arg1} and {arg2} from action sub");
    }

    private void TestingEvents_OnSpacePressed(object sender, TestingEvents.OnSpacePressedEventArgs e )
    {
        Debug.Log("space in subscibe thing" + " " + e.spaceCount);
        _testingEvents.OnSpacePressed -= TestingEvents_OnSpacePressed;
    }

    public void TestingUnityEvent()
    {
        Debug.Log("unityevent here");
    }

    void Update()
    {
        
    }
}
