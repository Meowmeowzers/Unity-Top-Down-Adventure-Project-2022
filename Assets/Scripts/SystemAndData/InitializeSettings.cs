using UnityEngine;
using UnityEngine.Audio;

public class InitializeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    private void Start()
    {
        if (PlayerPrefs.HasKey("VolumeMusic") && PlayerPrefs.HasKey("VolumeSound") && PlayerPrefs.HasKey("Quality"))
        {
            SetMusicVolume(PlayerPrefs.GetFloat("VolumeMusic"));
            SetSoundVolume(PlayerPrefs.GetFloat("VolumeSound"));
            SetQuality(PlayerPrefs.GetInt("Quality"));
        }
        else
        {
            PlayerPrefs.SetFloat("VolumeMusic", .8f);
            PlayerPrefs.SetFloat("VolumeSound", .8f);
            QualitySettings.SetQualityLevel(1);

            SetMusicVolume(.8f);
            SetSoundVolume(.8f);
            SetQuality(1);
        }

        AudioManager.Instance.PlayMusic(0);
    }

    private void SetMusicVolume(float value)
    {
        audioMixer.SetFloat("Music", Mathf.Log10(value) * 20);
    }

    private void SetSoundVolume(float value)
    {
        audioMixer.SetFloat("Sound", Mathf.Log10(value) * 20);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        if (qualityIndex == 0)
        {
            Application.targetFrameRate = 25;
        }
        else if (qualityIndex == 1)
        {
            Application.targetFrameRate = 32;
        }
        else if (qualityIndex == 2)
        {
            Application.targetFrameRate = 62;
        }
    }
}