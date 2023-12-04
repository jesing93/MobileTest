using System;
using UnityEngine;
using UnityEngine.UI;
using Assets.SimpleLocalization.Scripts;

namespace Assets.SimpleLocalization
{
	/// <summary>
	/// Asset usage example.
	/// </summary>
	public class Example : MonoBehaviour
    {
		[SerializeField]
        private Slider musicSlider;
        [SerializeField]
        private Slider sfxSlider;
        [SerializeField]
        private Dropdown difficulty;
        public Text FormattedText;

		/// <summary>
		/// Called on app start.
		/// </summary>
		public void Awake()
		{
            if (PlayerPrefs.HasKey("MusicVolume"))
            {
                musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
            }
            if (PlayerPrefs.HasKey("SFXVolume"))
            {
                sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
            }
            if (PlayerPrefs.HasKey("Difficulty"))
            {
                difficulty.value = PlayerPrefs.GetInt("Difficulty");
            }

            LocalizationManager.Read();

			if(PlayerPrefs.HasKey("Localization"))
			{
				LocalizationManager.Language = PlayerPrefs.GetString("Localization");
			}
			else
            {
                switch (Application.systemLanguage)
                {
                    case SystemLanguage.German:
                        LocalizationManager.Language = "German";
                        break;
                    case SystemLanguage.Russian:
                        LocalizationManager.Language = "Russian";
                        break;
                    default:
                        LocalizationManager.Language = "English";
                        break;
                }
            }

			// This way you can localize and format strings from code.
			FormattedText.text = LocalizationManager.Localize("Settings.Example.PlayTime", TimeSpan.FromHours(10.5f).TotalHours);

			// This way you can subscribe to LocalizationChanged event.
			LocalizationManager.OnLocalizationChanged += () => FormattedText.text = LocalizationManager.Localize("Settings.Example.PlayTime", TimeSpan.FromHours(10.5f).TotalHours);
		}

		/// <summary>
		/// Change localization at runtime.
		/// </summary>
		public void SetLocalization(string localization)
		{
			LocalizationManager.Language = localization;
			PlayerPrefs.SetString("Localization", localization);
		}

		/// <summary>
		/// Write a review.
		/// </summary>
		public void Review()
		{
			Application.OpenURL("https://www.assetstore.unity3d.com/#!/content/120113");
		}

		public void OnMusicVolChange()
		{
			PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
        }

        public void OnSFXVolChange()
        {
            PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);
        }

        public void OnDifficultyChange()
        {
            PlayerPrefs.SetInt("Difficulty", difficulty.value);
        }
    }
}