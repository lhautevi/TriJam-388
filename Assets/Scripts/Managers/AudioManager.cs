using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private AudioSource audioSource;

    public AudioClip[] deathSounds;
    public AudioClip victorySound;
    public AudioClip[] jumpSounds;


    private void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }

    public void PlayRandomSound(AudioClip[] audioClips)
    {
        int index = Random.Range(0,audioClips.Length);
        audioSource.PlayOneShot(audioClips[index]);
    }

   
}
