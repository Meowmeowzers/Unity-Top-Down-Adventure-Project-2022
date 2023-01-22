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

	private float music, sound;
	private int gfx;

    private void OnEnable()
	{
		music = PlayerPrefs.GetFloat("VolumeMusic");
		sound = PlayerPrefs.GetFloat("VolumeSound");
		gfx = PlayerPrefs.GetInt("Quality");
		SetMusicVolume(music);
		SetSoundVolume(sound);
		SetQuality(gfx);
		sliderMusic.value = music;
		sliderSound.value = sound;
		dropdown.value = gfx;
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
		else if (qualityIndex == 3)
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
