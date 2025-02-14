using UnityEngine;

public interface IObserver 
{
    //watching yt video https://www.youtube.com/watch?v=NY_fzd8g5MU

    //observers subscribe to a subject and the subject notifies observers of events

    //subject uses this method to communicate with the observer
    public void OnNotify();
}
