using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

// Credits to Brackeys for starter code
public class Settings : MonoBehaviour
{
	[SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider sliderMusic;
    [SerializeField] private Slider sliderSound;
    [SerializeField] private TMP_Dropdown dropdown;

    private void OnEnable()
	{
		if (PlayerPrefs.HasKey("VolumeMusic") && PlayerPrefs.HasKey("VolumeMusic") && PlayerPrefs.HasKey("Quality"))
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

        sliderMusic.value = PlayerPrefs.GetFloat("VolumeMusic");
        sliderSound.value = PlayerPrefs.GetFloat("VolumeSound");
        dropdown.value = PlayerPrefs.GetInt("Quality");
    }
	
	public void SetMusicVolume (float value)
	{
		audioMixer.SetFloat("Music", Mathf.Log10(value) * 20);
		PlayerPrefs.SetFloat("VolumeMusic", value);
	}
	
	public void SetSoundVolume (float value)
	{
		audioMixer.SetFloat("Sound", Mathf.Log10(value) * 20);
		PlayerPrefs.SetFloat("VolumeSound", value);
	}
	
	public void SetQuality (int qualityIndex)
	{
		QualitySettings.SetQualityLevel(qualityIndex);

		if (qualityIndex == 0)
        {
            Application.targetFrameRate = 32;
        }
		else if (qualityIndex == 1)
        {
            Application.targetFrameRate = 62;
        }
        else if (qualityIndex == 2)
        {
            Application.targetFrameRate = 92;
        }

		PlayerPrefs.SetInt("Quality", qualityIndex);
	}
	
	private void OnDisable()
	{
		PlayerPrefs.Save();
	}
}
