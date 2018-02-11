using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

    static AudioManager _instance;
    public static AudioManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<AudioManager>();
            }
            return _instance;
        }
    }

    public AudioClip[] backgroundMusic;
    public AudioClip explosion;
    public AudioClip shooting;

    public AudioSource musicSource;
    public AudioSource explosionSource;
    public AudioSource shootingSource;

    public AudioMixerGroup audioMixerGroup;

    public int currentSong;

    void Awake () {
        musicSource = gameObject.AddComponent<AudioSource>();
        currentSong = Random.Range(0, backgroundMusic.Length);
        musicSource.clip = backgroundMusic[currentSong];
        musicSource.outputAudioMixerGroup = audioMixerGroup;
        musicSource.Play();

        explosionSource = gameObject.AddComponent<AudioSource>();
        explosionSource.clip = explosion;
        explosionSource.outputAudioMixerGroup = audioMixerGroup;

        shootingSource = gameObject.AddComponent<AudioSource>();
        shootingSource.clip = shooting;
        shootingSource.outputAudioMixerGroup = audioMixerGroup;
    }

    public void PlayShootingSound()
    {
            shootingSource.Play();
    }

    public void PlayExplosionSound()
    {
            explosionSource.Play();
    }

    private void Update()
    {
        if (!musicSource.isPlaying)
        {
            currentSong++;
            if (currentSong >= backgroundMusic.Length)
            {
                currentSong = 0;
            }
            musicSource.clip = backgroundMusic[currentSong];
        }
    }
}
