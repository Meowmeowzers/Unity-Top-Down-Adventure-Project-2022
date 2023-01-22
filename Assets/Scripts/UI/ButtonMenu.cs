using UnityEngine;

public class ButtonMenu : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip soundHover;
    //[SerializeField] private AudioClip soundClick;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySoundHover()
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(soundHover);
        }
    }

    public void PlaySoundClick()
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(soundHover);
        }
    }
}