using UnityEngine;

public class GiantSoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip happySound1;
    [SerializeField] private AudioClip happySound2;
    [SerializeField] private AudioClip snoreSound1;
    [SerializeField] private AudioClip snoreSound2;

    [SerializeField] private AudioSource audioSource;

    private bool isSnorePlaying = false;
    private bool isHappyPlaying = false;

    void Start()
    {
        // Start playing snore sound on loop
        PlaySnoreLoop();
    }

    public void PlayHappySound()
    {
        if (!isHappyPlaying) {
            // Stop the snore loop
            StopSnoreLoop();
            isHappyPlaying = true;
            // Play a random happy sound
            AudioClip selectedSound;
            if (Random.Range(0f, 1f) > 0.5f)
            {
                selectedSound = happySound1;
            }
            else
            {
                selectedSound = happySound2;
            }

            PlaySound(selectedSound);
            
            Invoke(nameof(PlaySnoreLoop), selectedSound.length);
        }
    }

    public void PlaySnoreLoop()
    {
        isHappyPlaying = false;
        
        if (!isSnorePlaying)
        {
            isSnorePlaying = true;
            audioSource.clip = (Random.Range(0f, 1f) > 0.5f) ? snoreSound1 : snoreSound2;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    private void StopSnoreLoop()
    {
        // Stop the snore loop
        isSnorePlaying = false;
        audioSource.Stop();
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}