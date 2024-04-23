using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO.Pipes;

public enum SoundType
{
    PUPPYJUMP,
    PUPPYLAND,
    PUPPYPOP,
    PUPPYSHOOT,
    PUPPYSHOOTHIT,
    STAR,
    CHECKPOINT,
    POOF
}

[RequireComponent(typeof(AudioSource)), ExecuteInEditMode]
public class SoundManager : MonoBehaviour
{
    [SerializeField] private SoundList[] soundList;
    private static SoundManager instance;
    private AudioSource audioSource;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }



    public static void PlaySound(SoundType sound, float volume = 1)
    {
        AudioClip[] clips = instance.soundList[(int)sound].Sounds;
        AudioClip randomClip = clips[UnityEngine.Random.Range(0, clips.Length)];
        instance.audioSource.PlayOneShot(randomClip, volume);
    }

    private void OnEnable()
    {
        string[] names = Enum.GetNames(typeof(SoundType));
        Array.Resize(ref soundList, names.Length);
        for (int i = 0; i < soundList.Length; i++)
        {
            soundList[i].name = names[i];
        }
    }
}

[Serializable]
public struct SoundList
{
    public AudioClip[] Sounds { get => sounds;  }
    [HideInInspector] public string name;
    [SerializeField] private AudioClip[] sounds;
}

