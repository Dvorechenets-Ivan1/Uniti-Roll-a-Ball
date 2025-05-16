using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControler : MonoBehaviour
{
    public string volumeParameter = "MasterVolume";
    public AudioMixer mixer;
    public Slider slider;

    private const float _multiplier = 20f;

    private void Awake()
    {
        slider.onValueChanged.AddListener(HandleSliderValueChanged);
    }
    private void HandleSliderValueChanged(float value)
    {
        if (value <= 0.0001f)  // захист від логарифму 0
            mixer.SetFloat(volumeParameter, -80f); // мінімальна гучність (mute)
        else
        {
            float volumeValue = Mathf.Log10(value) * _multiplier;
            mixer.SetFloat(volumeParameter, volumeValue);
        }
    }

    void Start()
    {
        
    }

}
