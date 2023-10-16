using UnityEngine;
using UnityEngine.Audio;

public class AudioChangeVolume : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private string param;

    private void Awake()
    {
        if (PlayerPrefs.HasKey(param))
        {
            audioMixer.SetFloat(param, PlayerPrefs.GetFloat("Audio" + param));
        }
        else
        {
            audioMixer.GetFloat(param, out float v);
            PlayerPrefs.SetFloat("Audio" + param, v);
        }
    }

    public void ChangeValue(float v)
    {
        audioMixer.SetFloat(param, v);
        PlayerPrefs.SetFloat("Audio" + param, v);
    }
}
