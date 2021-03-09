using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingleBehaviour<AudioManager>
{
    public List<AudioData> allAudios;
    public AudioSource generalAudioSource;

    public void PlayAudio(string audioID)
    {
      AudioData findedaudio=allAudios.Find(x => x.ID == audioID);
        generalAudioSource.PlayOneShot(findedaudio.audioClip);

    }

    [System.Serializable]
    public class AudioData
    {
        public string ID;
        public AudioClip audioClip;
    }
}
