using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    
    private AudioSource audioSource;

    public AudioClip[] deathSounds;
    public AudioClip victorySound;
    public AudioClip jumpSound;


    private void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }

    public void PlayRandomDeathSound()
    {
        int index = Random.Range(0,deathSounds.Length);
        audioSource.PlayOneShot(deathSounds[index]);
    }
}
