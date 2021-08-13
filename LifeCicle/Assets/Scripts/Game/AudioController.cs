using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [Header("Sound stage 01")]
    [SerializeField] private AudioClip[] soundStage01_;

    [Header("Sound stage 02")]
    [SerializeField] private AudioClip[] soundStage02_;

    [Header("Sound stage 03")]
    [SerializeField] private AudioClip[] soundStage03_;

    [Header("Sound Tutorial")]
    [SerializeField] private AudioClip[] soundTutorial_;

    [Header("Sound Main Menu")]
    [SerializeField] private AudioClip[] soundMainMenu_;

    [Header("Audio Source")]
    [SerializeField] private AudioSource[] audioSources_;
    [SerializeField] private AudioSource sourcesFX_;

    [Header("Sound FX")]
    [SerializeField] private AudioClip soundFx_;

    [Header("tag gamecontroller")]
    [SerializeField] private string tagGameController_;

    [Header("Main menu")]
    [SerializeField] private GameObject mainMenu_;

    private GameController gameController_;

    private void Awake()
    {
        SetComponent();   
    }

    private void SetComponent()
    {
        if (gameController_ == null)
            gameController_ = GameObject.FindGameObjectWithTag(tagGameController_).GetComponent<GameController>();
    }

    private void Update()
    {
        Return();
        if (MenuController.returMenu_)
            return;

        if (MenuController.pauseGame_)
            return;

        tutorial();
        MainMenu();

        Stage01();
        Stage02();
        Stage03();
    }

    private void Return()
    {
        if (MenuController.returMenu_)
        {
            audioSources_[0].clip = null;
            audioSources_[1].clip = null;

            audioSources_[0].Stop();
            audioSources_[1].Stop();

            sourcesFX_.clip = null;
            sourcesFX_.Stop();
        }
    }

    private void Stage01()
    {
        if(gameController_.stageActive_ == GameController.stringStage_01)
        {
            audioSources_[0].clip = soundStage01_[0];
            audioSources_[1].clip = soundStage01_[1];

            if (!audioSources_[0].isPlaying)
                audioSources_[0].Play();

            if (!audioSources_[1].isPlaying)
                audioSources_[1].Play();


            if (gameController_.wind_)
            {
                if (sourcesFX_.clip == null)
                {
                    sourcesFX_.clip = soundFx_;
                }

                if (!sourcesFX_.isPlaying)
                {
                    sourcesFX_.Play();
                }
            }
            else
            {
                sourcesFX_.Stop();
            }
        }
    }

    private void Stage02()
    {
        if (gameController_.stageActive_ == GameController.stringStage_02)
        {
            audioSources_[0].clip = soundStage02_[0];
            audioSources_[1].clip = soundStage02_[1];

            if (!audioSources_[0].isPlaying)
                audioSources_[0].Play();

            if (!audioSources_[1].isPlaying)
                audioSources_[1].Play();
        }
    }

    private void Stage03()
    {
        if (gameController_.stageActive_ == GameController.stringStage_03)
        {
            audioSources_[0].clip = soundStage03_[0];
            audioSources_[1].clip = soundStage03_[1];

            if (!audioSources_[0].isPlaying)
                audioSources_[0].Play();

            if (!audioSources_[1].isPlaying)
                audioSources_[1].Play();
        }
    }

    private void MainMenu()
    {
        if (gameController_.stageActive_ == GameController.stringStageMainMenu)
        {
            Debug.Log("sound menu");
            audioSources_[0].clip = soundMainMenu_[0];
            audioSources_[1].clip = null;

            if (!audioSources_[0].isPlaying)
                audioSources_[0].Play();
        }
    }

    private void tutorial()
    {
        if (gameController_.stageActive_ == GameController.stringStageTutorial)
        {
            audioSources_[0].clip = soundTutorial_[0];
            audioSources_[1].clip = null;

            if (!audioSources_[0].isPlaying)
                audioSources_[0].Play();

            if (sourcesFX_.isPlaying)
                sourcesFX_.Stop();
        }
    }
}
