using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [Header("Sound ambient")]
    [SerializeField] private AudioSource soundAmbient01_;
    [SerializeField] private AudioSource soundAmbient02_;

    [Header("Sound FX")]
    [SerializeField] private AudioSource soundFx_;

    [Header("List ambient sound")]
    [SerializeField] private AudioClip[] soundAmbientList_;
    [SerializeField] private AudioClip[] soundFxtList_;

    [Header("tag gamecontroller")]
    [SerializeField] private string tagGameController_;

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
        Stage01();
        Stage02();
        Stage03();
    }

    private void Stage01()
    {
        if(gameController_.stageActive_ == GameController.stringStage_01)
        {
            soundAmbient01_.clip = soundAmbientList_[0];
            soundAmbient02_.clip = soundAmbientList_[1];

            soundFx_.clip = soundFxtList_[0];

            if (gameController_.playSoundwind_)
            {
                if(soundFx_.isPlaying == false)
                {
                    soundFx_.volume = 0.7f;
                    soundFx_.Play();
                }
            }
            else
            {
                soundFx_.volume -= Time.deltaTime;
                if(soundFx_.volume == 0f)
                {
                    soundFx_.Stop();
                }
            }
        }
    }

    private void Stage02()
    {
        if (gameController_.stageActive_ == GameController.stringStage_02)
        {
            soundFx_.Stop();
        }
    }

    private void Stage03()
    {
        if (gameController_.stageActive_ == GameController.stringStage_03)
        {
            soundFx_.Stop();
        }
    }
}
