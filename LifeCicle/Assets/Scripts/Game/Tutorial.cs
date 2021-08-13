using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [Header("Tuorial Stage 1")]
    [SerializeField] private GameObject[] tutorial01_;

    [Header("Tuorial Stage 2")]
    [SerializeField] private GameObject[] tutorial02_;

    [Header("Tuorial Stage 3")]
    [SerializeField] private GameObject[] tutorial03_;

    [Header("Tuorial Stage 4")]
    [SerializeField] private GameObject[] tutorial04_;

    [Header("Mask Tutorial")]
    [SerializeField] private GameObject mask_;
    [SerializeField] private GameObject parentMask_;

    [Header("Buttons skip tutorial")]
    [SerializeField] private GameObject buttonSkip01_;
    [SerializeField] private GameObject buttonSkip02_;
    [SerializeField] private GameObject buttonSkip03_;
    [SerializeField] private GameObject buttonSkip04_;

    public static bool WindTutor_;
    public static float tutorView_;

    public static bool tutorial01Complet_;
    public static bool tutorial02Complet_;
    public static bool tutorial03Complet_;
    public static bool tutorial04Complet_;

    private float timeViewTutorial_;

    [Header("Tag GameController")]
    [SerializeField] private string tagGameController_;

    private GameController gameController_;

    private void Awake()
    {
        SetComponent();
    }

    private void Update()
    {
        Return();

        if (MenuController.returMenu_)
            return;

        if (MenuController.pauseGame_)
            return;

        PlayTutorial01();
        PlayTutorial02();
        PlayTutorial03();
        PlayTutorial04();
    }

    private void Return()
    {
        if (MenuController.returMenu_)
        {
            timeViewTutorial_ = 0;
        }
    }

    private void SetComponent()
    {
        if (gameController_ == null)
            gameController_ = GameObject.FindGameObjectWithTag(tagGameController_).GetComponent<GameController>();
    }

    private void PlayTutorial01()
    {
        if (GameController.playTutorial01_)
        {
            //fade 1 = fade in. fade 2 = fade out
            string _parameter = "fade";
            Animator _animator = mask_.GetComponent<Animator>();

            if (parentMask_.activeInHierarchy == false)
                parentMask_.SetActive(true);

            buttonSkip01_.SetActive(true);
            buttonSkip02_.SetActive(false);
            buttonSkip03_.SetActive(false);
            buttonSkip04_.SetActive(false);

            timeViewTutorial_ += Time.deltaTime;
            if(timeViewTutorial_ < 4f)
            {
                _animator.SetInteger(_parameter, 2);
                tutorial01_[0].SetActive(true);
                tutorial01_[1].SetActive(false);
                tutorial01_[2].SetActive(false);
                tutorial01_[3].SetActive(false);
                tutorial01_[4].SetActive(false);
                tutorial01_[5].SetActive(false);
            }

            if(timeViewTutorial_ > 4f)
            {
                _animator.SetInteger(_parameter, 1);
            }

            if(timeViewTutorial_ > 5.5f)
            {
                _animator.SetInteger(_parameter, 2);
                tutorial01_[0].SetActive(false);
                tutorial01_[1].SetActive(true);
                tutorial01_[2].SetActive(false);
                tutorial01_[3].SetActive(false);
                tutorial01_[4].SetActive(false);
                tutorial01_[5].SetActive(false);
            }

            if(timeViewTutorial_ > 9.5f)
            {
                _animator.SetInteger(_parameter, 1);
            }

            if(timeViewTutorial_ > 11f)
            {
                _animator.SetInteger(_parameter, 2);
                tutorial01_[0].SetActive(false);
                tutorial01_[1].SetActive(false);
                tutorial01_[2].SetActive(true);
                tutorial01_[3].SetActive(false);
                tutorial01_[4].SetActive(false);
                tutorial01_[5].SetActive(false);
            }

            if (timeViewTutorial_ > 15f)
            {
                _animator.SetInteger(_parameter, 1);
            }

            if (timeViewTutorial_ > 16.5f)
            {
                _animator.SetInteger(_parameter, 2);
                tutorial01_[0].SetActive(false);
                tutorial01_[1].SetActive(false);
                tutorial01_[2].SetActive(false);
                tutorial01_[3].SetActive(true);
                tutorial01_[4].SetActive(false);
                tutorial01_[5].SetActive(false);
            }

            if (timeViewTutorial_ > 20.5f)
            {
                _animator.SetInteger(_parameter, 1);
            }

            if (timeViewTutorial_ > 22f)
            {
                _animator.SetInteger(_parameter, 2);
                tutorial01_[0].SetActive(false);
                tutorial01_[1].SetActive(false);
                tutorial01_[2].SetActive(false);
                tutorial01_[3].SetActive(false);
                tutorial01_[4].SetActive(true);
                tutorial01_[5].SetActive(false);
            }

            if (timeViewTutorial_ > 26f)
            {
                _animator.SetInteger(_parameter, 1);
            }

            if (timeViewTutorial_ > 27.6f)
            {
                _animator.SetInteger(_parameter, 2);
                tutorial01_[0].SetActive(false);
                tutorial01_[1].SetActive(false);
                tutorial01_[2].SetActive(false);
                tutorial01_[3].SetActive(false);
                tutorial01_[4].SetActive(false);
                tutorial01_[5].SetActive(true);
            }

            if (timeViewTutorial_ > 31.5f)
            {
                _animator.SetInteger(_parameter, 1);
                tutorial01Complet_ = true;
                GameController.playTutorial01_ = false;
                timeViewTutorial_ = 0;

                tutorial01_[0].SetActive(false);
                tutorial01_[1].SetActive(false);
                tutorial01_[2].SetActive(false);
                tutorial01_[3].SetActive(false);
                tutorial01_[4].SetActive(false);
                tutorial01_[5].SetActive(false);

                parentMask_.SetActive(false);
            }
        }
        else
        {
            tutorial01_[0].SetActive(false);
            tutorial01_[1].SetActive(false);
            tutorial01_[2].SetActive(false);
            tutorial01_[3].SetActive(false);
            tutorial01_[4].SetActive(false);
            tutorial01_[5].SetActive(false);
        }
    }

    private void PlayTutorial02()
    {
        if (GameController.playTutorial02_)
        {
            //fade 1 = fade in. fade 2 = fade out
            string _parameter = "fade";
            Animator _animator = mask_.GetComponent<Animator>();

            if (parentMask_.activeInHierarchy == false)
                parentMask_.SetActive(true);

            buttonSkip01_.SetActive(false);
            buttonSkip02_.SetActive(true);
            buttonSkip03_.SetActive(false);
            buttonSkip04_.SetActive(false);

            timeViewTutorial_ += Time.deltaTime;
            if (timeViewTutorial_ < 4f)
            {
                _animator.SetInteger(_parameter, 0);
                tutorial02_[0].SetActive(true);
                tutorial02_[1].SetActive(false);
                tutorial02_[2].SetActive(false);
                tutorial02_[3].SetActive(false);
            }

            if (timeViewTutorial_ > 4f)
            {
                _animator.SetInteger(_parameter, 1);
            }

            if (timeViewTutorial_ > 5.5f)
            {
                _animator.SetInteger(_parameter, 2);
                tutorial02_[0].SetActive(false);
                tutorial02_[1].SetActive(true);
                tutorial02_[2].SetActive(false);
                tutorial02_[3].SetActive(false);
            }

            if (timeViewTutorial_ > 9.5f)
            {
                _animator.SetInteger(_parameter, 1);
            }

            if (timeViewTutorial_ > 11f)
            {
                _animator.SetInteger(_parameter, 2);
                tutorial02_[0].SetActive(false);
                tutorial02_[1].SetActive(false);
                tutorial02_[2].SetActive(true);
                tutorial02_[3].SetActive(false);
            }

            if (timeViewTutorial_ > 15f)
            {
                _animator.SetInteger(_parameter, 1);
            }

            if (timeViewTutorial_ > 16.5f)
            {
                _animator.SetInteger(_parameter, 2);
                tutorial02_[0].SetActive(false);
                tutorial02_[1].SetActive(false);
                tutorial02_[2].SetActive(false);
                tutorial02_[3].SetActive(true);
            }

            if (timeViewTutorial_ > 20.5f)
            {
                _animator.SetInteger(_parameter, 1);
                tutorial02Complet_ = true;
                GameController.playTutorial02_ = false;
                timeViewTutorial_ = 0;

                tutorial02_[0].SetActive(false);
                tutorial02_[1].SetActive(false);
                tutorial02_[2].SetActive(false);
                tutorial02_[3].SetActive(false);

                parentMask_.SetActive(false);
            }
        }
        else
        {
            tutorial02_[0].SetActive(false);
            tutorial02_[1].SetActive(false);
            tutorial02_[2].SetActive(false);
            tutorial02_[3].SetActive(false);
        }
    }

    private void PlayTutorial03()
    {
        if (GameController.playTutorial03_)
        {
            //fade 1 = fade in. fade 2 = fade out
            string _parameter = "fade";
            Animator _animator = mask_.GetComponent<Animator>();

            if (parentMask_.activeInHierarchy == false)
                parentMask_.SetActive(true);

            buttonSkip01_.SetActive(false);
            buttonSkip02_.SetActive(false);
            buttonSkip03_.SetActive(true);
            buttonSkip04_.SetActive(false);

            timeViewTutorial_ += Time.deltaTime;
            if (timeViewTutorial_ < 4f)
            {
                _animator.SetInteger(_parameter, 0);
                tutorial03_[0].SetActive(true);
                tutorial03_[1].SetActive(false);
                tutorial03_[2].SetActive(false);
                tutorial03_[3].SetActive(false);
            }

            if (timeViewTutorial_ > 4f)
            {
                _animator.SetInteger(_parameter, 1);
            }

            if (timeViewTutorial_ > 5.5f)
            {
                _animator.SetInteger(_parameter, 2);
                tutorial03_[0].SetActive(false);
                tutorial03_[1].SetActive(true);
                tutorial03_[2].SetActive(false);
                tutorial03_[3].SetActive(false);
            }

            if (timeViewTutorial_ > 9.5f)
            {
                _animator.SetInteger(_parameter, 1);
            }

            if (timeViewTutorial_ > 11f)
            {
                _animator.SetInteger(_parameter, 2);
                tutorial03_[0].SetActive(false);
                tutorial03_[1].SetActive(false);
                tutorial03_[2].SetActive(true);
                tutorial03_[3].SetActive(false);
            }

            if (timeViewTutorial_ > 15f)
            {
                _animator.SetInteger(_parameter, 1);
            }

            if (timeViewTutorial_ > 16.5f)
            {
                _animator.SetInteger(_parameter, 2);
                tutorial03_[0].SetActive(false);
                tutorial03_[1].SetActive(false);
                tutorial03_[2].SetActive(false);
                tutorial03_[3].SetActive(true);
            }

            if (timeViewTutorial_ > 20.5f)
            {
                _animator.SetInteger(_parameter, 1);
                tutorial03Complet_ = true;
                GameController.playTutorial03_ = false;
                timeViewTutorial_ = 0;

                tutorial03_[0].SetActive(false);
                tutorial03_[1].SetActive(false);
                tutorial03_[2].SetActive(false);
                tutorial03_[3].SetActive(false);

                parentMask_.SetActive(false);
            }
        }
        else
        {
            tutorial03_[0].SetActive(false);
            tutorial03_[1].SetActive(false);
            tutorial03_[2].SetActive(false);
            tutorial03_[3].SetActive(false);
        }
    }

    private void PlayTutorial04()
    {
        if (GameController.playTutorial04_)
        {
            //fade 1 = fade in. fade 2 = fade out
            string _parameter = "fade";
            Animator _animator = mask_.GetComponent<Animator>();

            if (parentMask_.activeInHierarchy == false)
                parentMask_.SetActive(true);

            buttonSkip01_.SetActive(false);
            buttonSkip02_.SetActive(false);
            buttonSkip03_.SetActive(false);
            buttonSkip04_.SetActive(true);

            timeViewTutorial_ += Time.deltaTime;
            if (timeViewTutorial_ < 4f)
            {
                _animator.SetInteger(_parameter, 0);
                tutorial04_[0].SetActive(true);
                tutorial04_[1].SetActive(false);
                if (tutorial04_[2].activeInHierarchy == false)
                    tutorial04_[2].SetActive(false);
            }

            if (timeViewTutorial_ > 4f)
            {
                _animator.SetInteger(_parameter, 1);
            }

            if (timeViewTutorial_ > 5.5f)
            {
                _animator.SetInteger(_parameter, 2);
                tutorial04_[0].SetActive(false);
                tutorial04_[1].SetActive(true);
                if (tutorial04_[2].activeInHierarchy == false)
                    tutorial04_[2].SetActive(false);
            }

            if (timeViewTutorial_ > 9.5f)
            {
                _animator.SetInteger(_parameter, 1);
            }

            if (timeViewTutorial_ > 11f)
            {
                _animator.SetInteger(_parameter, 2);
                tutorial04_[0].SetActive(false);
                tutorial04_[1].SetActive(false);
                if (tutorial04_[2].activeInHierarchy == false)
                    tutorial04_[2].SetActive(true);
            }

            if (timeViewTutorial_ > 15f)
            {
                _animator.SetInteger(_parameter, 1);
                tutorial04Complet_ = true;
                GameController.playTutorial04_ = false;
                timeViewTutorial_ = 0;

                tutorial04_[0].SetActive(false);
                tutorial04_[1].SetActive(false);
                tutorial04_[2].SetActive(false);

                parentMask_.SetActive(false);
            }
        }
        else
        {
            tutorial04_[0].SetActive(false);
            tutorial04_[1].SetActive(false);
            tutorial04_[2].SetActive(false);
        }
    }

    public void SkipTutorial01()
    {
        if (GameController.playTutorial01_)
        {
            string _parameter = "fade";
            Animator _animator = mask_.GetComponent<Animator>();
            _animator.SetInteger(_parameter, 1);
            tutorial01Complet_ = true;
            GameController.playTutorial01_ = false;
            timeViewTutorial_ = 0;

            tutorial01_[0].SetActive(false);
            tutorial01_[1].SetActive(false);
            tutorial01_[2].SetActive(false);
            tutorial01_[3].SetActive(false);
            tutorial01_[4].SetActive(false);
            tutorial01_[5].SetActive(false);

            parentMask_.SetActive(false);
        }
    }

    public void SkipTutorial02()
    {
        if (GameController.playTutorial02_)
        {
            string _parameter = "fade";
            Animator _animator = mask_.GetComponent<Animator>();
            _animator.SetInteger(_parameter, 1);
            tutorial02Complet_ = true;
            GameController.playTutorial02_ = false;
            timeViewTutorial_ = 0;

            tutorial02_[0].SetActive(false);
            tutorial02_[1].SetActive(false);
            tutorial02_[2].SetActive(false);
            tutorial02_[3].SetActive(false);

            parentMask_.SetActive(false);
        }
    }

    public void SkipTutorial03()
    {
        if (GameController.playTutorial03_)
        {
            string _parameter = "fade";
            Animator _animator = mask_.GetComponent<Animator>();
            _animator.SetInteger(_parameter, 1);
            tutorial03Complet_ = true;
            GameController.playTutorial03_ = false;
            timeViewTutorial_ = 0;

            tutorial03_[0].SetActive(false);
            tutorial03_[1].SetActive(false);
            tutorial03_[2].SetActive(false);
            tutorial03_[3].SetActive(false);

            parentMask_.SetActive(false);
        }
    }

    public void SkipTutorial04()
    {
        if (GameController.playTutorial04_)
        {
            string _parameter = "fade";
            Animator _animator = mask_.GetComponent<Animator>();
            _animator.SetInteger(_parameter, 1);
            tutorial04Complet_ = true;
            GameController.playTutorial04_ = false;
            timeViewTutorial_ = 0;

            tutorial04_[0].SetActive(false);
            tutorial04_[1].SetActive(false);
            tutorial04_[2].SetActive(false);

            parentMask_.SetActive(false);
        }
    }

}
