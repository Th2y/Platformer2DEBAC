using Ebac.Core.Singletons;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public enum SFXNames
{
    UIButtons,
    Coin,
    Life,
    Fall,
    Jump,
    Step,
    PlayerAttack,
    Enemy1Attack,
    Enemy2Attack,
}

public enum MusicNames
{
    Menu,
    Game,
    Lose,
    Win
}

public class AudioController : Singleton<AudioController>
{
    [Header("Mixer Snapshot")]
    [SerializeField] private AudioMixerSnapshot menuMixerSnapshot;
    [SerializeField] private AudioMixerSnapshot gameMixerSnapshot;
    [SerializeField] private float timeToTransition = .1f;

    [Header("Music")]
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private AudioClip menuMusic;
    [SerializeField] private AudioClip gameMusic;
    [SerializeField] private AudioClip loseMusic;
    [SerializeField] private AudioClip winMusic;

    [Header("SFX")]
    [SerializeField] private AudioSource uiButtonsSFX;
    [SerializeField] private AudioSource coinSFX;
    [SerializeField] private AudioSource lifeSFX;
    [SerializeField] private AudioSource fallSFX;
    [SerializeField] private AudioSource jumpSFX;
    [SerializeField] private AudioSource stepSFX;
    [SerializeField] private AudioSource playerAttackSFX;
    [SerializeField] private AudioSource enemy1AttackSFX;
    [SerializeField] private AudioSource enemy2AttackSFX;

    private Dictionary<MusicNames, AudioClip> musicDic => new Dictionary<MusicNames, AudioClip> 
    {
        { MusicNames.Menu, menuMusic },
        { MusicNames.Game, gameMusic },
        { MusicNames.Lose, loseMusic },
        { MusicNames.Win, winMusic }
    };

    private Dictionary<SFXNames, AudioSource> sfxDic => new Dictionary<SFXNames, AudioSource>
    {
        { SFXNames.UIButtons, uiButtonsSFX},
        { SFXNames.Coin, coinSFX },
        { SFXNames.Life, lifeSFX },
        { SFXNames.Fall, fallSFX },
        { SFXNames.Jump, jumpSFX },
        { SFXNames.Step, stepSFX },
        { SFXNames.PlayerAttack, playerAttackSFX },
        { SFXNames.Enemy1Attack, enemy1AttackSFX },
        { SFXNames.Enemy2Attack, enemy2AttackSFX }
    };

    protected override void Awake()
    {
        base.Awake();

        DontDestroyOnLoad(gameObject);

        SceneManager.activeSceneChanged += OnChangeScene;
    }

    public void PlaySFXByName(SFXNames name)
    {
        sfxDic[name].Play();
    }

    public void PlayMusicByName(MusicNames name)
    {
        backgroundMusic.clip = musicDic[name];
        backgroundMusic.Play();
    }

    private void OnChangeScene(Scene current, Scene next)
    {
        if (next.name == "Menu")
        {
            backgroundMusic.clip = musicDic[MusicNames.Menu];
            menuMixerSnapshot.TransitionTo(timeToTransition);
        }
        else 
        { 
            backgroundMusic.clip = musicDic[MusicNames.Game];
            gameMixerSnapshot.TransitionTo(timeToTransition);
        }

        backgroundMusic.Play();
    }
}
