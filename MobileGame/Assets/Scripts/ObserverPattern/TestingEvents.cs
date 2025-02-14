using UnityEngine;
using System;
using UnityEngine.Events;

public class TestingEvents : MonoBehaviour
{
    //from yt codemonkey https://www.youtube.com/watch?v=OuZrhykVytg

    //defining our event
    //you do not need to use eventhandler its just the standard deligate
    public event EventHandler <OnSpacePressedEventArgs> OnSpacePressed; 
    //the event args is the standard way to pass more info through the event.  
    //action is very similar

    //unityevent is also similar but it shows in the inspector
    public class OnSpacePressedEventArgs: EventArgs
    {
        //in here we define whatever field we want
        //for an example:
        public int spaceCount;
    }

    //here is action
    public event Action<bool, int> OnActionEvent;

    //here is unityevent
    public UnityEvent OnUnityEvent;

    private int spaceCount; 

    void Start()
    {

    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //space pressed
            spaceCount++;
            OnSpacePressed?.Invoke(this, new OnSpacePressedEventArgs { spaceCount = spaceCount });

            OnActionEvent?.Invoke(true, 56);

            OnUnityEvent?.Invoke();
        }
    }

}


