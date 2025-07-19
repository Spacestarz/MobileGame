using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    [SerializeField] private AudioSource[] _audioSources;
    
    [SerializeField] private AudioClip _backgroundMusic01;

    [SerializeField] private AudioClip[] _backgroundMusics;
    public AudioClip currentClip;
    private AudioClip newClip;
    private int currentClipIndex = 0;

    public double GoalTime;
    public double musicDuration;
    public int audioToggle;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        
    }

    private void Update()
    {
        //In the update im going to check if the current time is greater than the goal time  and then put something like:
        if (AudioSettings.dspTime > GoalTime -1)
            //this will schedual our new clip  to play once the old one is finished. Using the new goaltime.
        {
            PlayScheduledClip();
            Debug.Log("playing schedual sclip");
        }

    }

    private void PlayScheduledClip()
    {
        //loads the next clip on the music array
        currentClip = _backgroundMusics[currentClipIndex];

        //changes current audiosource to current clip
        _audioSources[audioToggle].clip = currentClip;
        //when we reached the goal time this audio source will play a clip
        _audioSources[audioToggle].PlayScheduled(GoalTime);

        //gravbbing the music duration from our clip and resetting the goaltime
        //to when this clip finishes playing. 
        musicDuration = (double)currentClip.samples / currentClip.frequency;
        GoalTime = GoalTime + musicDuration;

        //flipping the audiotoggle number between 1 and 0. 
        audioToggle = 1 - audioToggle; 

        currentClipIndex = (currentClipIndex + 1) % _backgroundMusics.Length;
    }

    //If you ever want to change the music that gets loaded to come after
    //simply change the current clip 
    private void ChangeCurrentClip(AudioClip clip)
    {
        currentClip = clip;
    }

}
