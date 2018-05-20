using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{

    public enum AudioChannel { Master, Sfx, Music };

    public float masterVolumePercent { get; private set; }
    public float sfxVolumePercent { get; private set; }
    public float musicVolumePercent { get; private set; }

    AudioSource sfx2DSource;
    AudioSource[] musicSources;
    public int activeMusicSourceIndex;

    SoundLibrary library;


    public static AudioManager instance;

    void Awake()
    {
        if(instance != null)
            Destroy(this.gameObject);
        else
        {
            DontDestroyOnLoad(this.gameObject);

            library = GetComponent<SoundLibrary>();

            instance = this;

            musicSources = new AudioSource[2];

            GameObject newSfx2Dsource = new GameObject("2D sfx source");
            sfx2DSource = newSfx2Dsource.AddComponent<AudioSource>();
            newSfx2Dsource.transform.parent = transform;

            for (int i = 0; i < 2; i++)
            {
                GameObject newMusicSource = new GameObject("Music source " + (i + 1));
                musicSources[i] = newMusicSource.AddComponent<AudioSource>();
                newMusicSource.transform.parent = transform;
            }
            masterVolumePercent = PlayerPrefs.GetFloat("master vol", 1);
            musicVolumePercent = PlayerPrefs.GetFloat("music vol", 1);
            sfxVolumePercent = PlayerPrefs.GetFloat("sfx vol", 1);
        }
    }

    public void PlayMusic(AudioClip clip)
    {
        activeMusicSourceIndex = 1 - activeMusicSourceIndex;
        musicSources[activeMusicSourceIndex].clip = clip;
        musicSources[activeMusicSourceIndex].loop = true;
        musicSources[activeMusicSourceIndex].Play();
        StartCoroutine(AnimateMusicCrossfade());
    }

    public void PlayClip(AudioClip clip, Vector3 pos)
    {
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, pos, sfxVolumePercent * 0.5f * masterVolumePercent);
        }
    }

    public void PlayClip(AudioClip clip, Vector3 pos, float volume)
    {
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, pos, sfxVolumePercent * volume * masterVolumePercent);
        }
    }

    public void PlaySound(string soundName, Vector3 pos)
    {
        PlayClip(library.GetClipFromName(soundName), pos);
    }

    public void PlaySound(string soundName, Vector3 pos, float volume)
    {
        PlayClip(library.GetClipFromName(soundName), pos, volume);
    }

    public void PlaySound2D(string soundName)
    {
        sfx2DSource.PlayOneShot(library.GetClipFromName(soundName), sfxVolumePercent * masterVolumePercent);
    }

    IEnumerator AnimateMusicCrossfade()
    {
        float percent = 0.0f;

        while (percent < 1)
        {
            percent += 0.02f;
            musicSources[activeMusicSourceIndex].volume = Mathf.Lerp(0, musicVolumePercent * masterVolumePercent, percent);
            musicSources[1 - activeMusicSourceIndex].volume = Mathf.Lerp(musicVolumePercent * masterVolumePercent, 0, percent);
            yield return null;
        }
    }

    public void SetVolume(float volumePercent, AudioChannel channel)
    {
        switch (channel)
        {
            case AudioChannel.Master:
                masterVolumePercent = volumePercent;
                break;
            case AudioChannel.Sfx:
                sfxVolumePercent = volumePercent;
                break;
            case AudioChannel.Music:
                musicVolumePercent = volumePercent;
                break;
        }

        musicSources[0].volume = musicVolumePercent * masterVolumePercent;
        musicSources[1].volume = musicVolumePercent * masterVolumePercent;

        PlayerPrefs.SetFloat("master vol", masterVolumePercent);
        PlayerPrefs.SetFloat("sfx vol", sfxVolumePercent);
        PlayerPrefs.SetFloat("music vol", musicVolumePercent);
        PlayerPrefs.Save();
    }
}