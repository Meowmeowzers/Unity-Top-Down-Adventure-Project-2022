using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip audioClip;

    [SerializeField] private MusicClip musicClip;

    private static AudioManager instance;

    public static AudioManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            audioSource = GetComponent<AudioSource>();
            instance = this;
        }
    }

    private void Start()
    {
    }

    public void PlayCurrentMusic()
    {
        audioSource.Play();
    }

    public void PauseCurrentMusic()
    {
        audioSource.Pause();
    }

    public void SelectandPlayMusic(AudioClip value)
    {
        audioSource.clip = value;
        PlayCurrentMusic();
    }

    public void SetVolume(float value)
    {
        audioSource.volume = value;
    }

    public void PlayMusic(int index)
    {
        switch(index)
        {
            case 0:
                SelectandPlayMusic(musicClip.menu);
                break;
            case 1:
                SelectandPlayMusic(musicClip.normal1);
                break;
            case 2:
                SelectandPlayMusic(musicClip.normal2);
                break;
            case 3:
                SelectandPlayMusic(musicClip.battle1);
                break;
            case 4:
                SelectandPlayMusic(musicClip.battle2);
                break;
            case 5:
                SelectandPlayMusic(musicClip.safe);
                break;
            default:
                SelectandPlayMusic(musicClip.safe);
                break;
        }
    }
}

/*
private static AudioManager instance = null;

public static AudioManager Instance
{
    get { return instance; }
}

private void Awake()
{
    if (instance != null && instance != this)
    {
        Destroy(this.gameObject);
        return;
    }
    else
    {
        instance = this;
    }

    DontDestroyOnLoad(this.gameObject);
}
*/