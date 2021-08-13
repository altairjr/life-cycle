using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    [Header("text points")]
    [SerializeField] private Text pointsText_;

    [Header("text hightScore")]
    [SerializeField] private Text higtScore_;

    [Header("Tag GameController")]
    [SerializeField] private string tagGameController_;
    private GameController gameController_;

    [Header("Points")]
    public float points_;
    private int pointsInt_;

    private void Awake()
    {
        SetComponent();
    }

    private void Update()
    {
        hightScore();
        Return();
        if (MenuController.returMenu_)
            return;

        if (MenuController.pauseGame_)
            return;

        stage01();
        stage02();
        stage03();
    }

    private void SetComponent()
    {
        if (gameController_ == null)
            gameController_ = GameObject.FindGameObjectWithTag(tagGameController_).GetComponent<GameController>();
    }

    private void Return()
    {
        if (MenuController.returMenu_)
        {
            points_ = 0;
        }
    }

    private void stage01()
    {
        if(gameController_.stageActive_ == GameController.stringStage_01)
        {
            PlayerController _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
            if(gameController_.wormDeath_ == false || gameController_.butterflyDeath_ == false)
            {
                if (Input.GetMouseButtonDown(0) && _playerController.grab_ == false)
                {
                    points_ ++;
                }
            }
            pointsInt_ = (int)points_;
            pointsText_.text = pointsInt_.ToString();
        }
    }

    private void stage02()
    {
        if (gameController_.stageActive_ == GameController.stringStage_02 && PlayerController.clickForTutorial_ == true)
        {
            if (Input.GetMouseButtonUp(0) && LeaftWater.posJump_ != null)
            {
                points_ ++;
            }

            pointsInt_ = (int)points_;
            pointsText_.text = pointsInt_.ToString();
        }
    }

    private void stage03()
    {
        if (gameController_.stageActive_ == GameController.stringStage_03 && PlayerController.eaglePlayerDeath_ == false)
        {
            if (Input.GetMouseButtonUp(0))
            {
                points_ ++;
            }

            pointsInt_ = (int)points_;
            pointsText_.text = pointsInt_.ToString();
        }
    }

    private void hightScore()
    {
        if(gameController_.stageActive_ == GameController.stringStageMainMenu)
        {
            int _higt = (int)PlayerPrefs.GetFloat("points");
            higtScore_.text = _higt.ToString();
        }
    }
}
