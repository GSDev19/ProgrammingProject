using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance;

    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField] private AudioSource SFXAudioSource;

    public UDictionary <SFX, AudioClip> sfxClipDic;
    public UDictionary <Music, AudioClip> musicClipDic;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (!Instance)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnEnable()
    {
        AreaDamage.OnCreateAreaSound += PlaySXF;
        ExperienceComponent.OnLevelUpSound += PlaySXF;
        LifeComponent.OnEntityDeathSound += PlaySXF;
        Projectile.OnFireProjectileSound += PlaySXF;   
        DiamondObject.OnDiamondPickedSound += PlaySXF;

        LifeComponent.OnPlayerDeathSound += PlaySXF;
        GameManager.OnGameWinSound += PlaySXF;


        MainMenuController.OnMainMenuStart += PlayMusic;
        GameManager.OnGameStarted += PlayMusic;
    }

    private void OnDisable()
    {
        AreaDamage.OnCreateAreaSound -= PlaySXF;
        ExperienceComponent.OnLevelUpSound -= PlaySXF;
        LifeComponent.OnEntityDeathSound -= PlaySXF;
        Projectile.OnFireProjectileSound -= PlaySXF;
        DiamondObject.OnDiamondPickedSound -= PlaySXF;

        LifeComponent.OnPlayerDeathSound -= PlaySXF;
        GameManager.OnGameWinSound -= PlaySXF;

        MainMenuController.OnMainMenuStart -= PlayMusic;
        GameManager.OnGameStarted -= PlayMusic;
    }

    public void PlaySXF(SFX sfx)
    {
        foreach (SFX item in sfxClipDic.Keys)
        {
            if(item == sfx)
            {
                SFXAudioSource.PlayOneShot(sfxClipDic[item]);
            }
        }
    }

    public void PlayMusic(Music music)
    {
        foreach (Music item in sfxClipDic.Keys)
        {
            if (item == music)
            {
                musicAudioSource.clip = musicClipDic[item];
                musicAudioSource.Play();
            }
        }
    }


}

public enum SFX
{
    CreateArea,
    FireProjectile,
    KillEnemy,
    LevelUp,
    PickDiamond,
    WinGame,
    LooseGame
}

public enum Music
{
    MenuMusic,
    GameMusic
}
