using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject menuStage01_;
    [SerializeField] private GameObject menuStage02_;
    [SerializeField] private GameObject menuStage03_;
    [SerializeField] private GameObject mainMenu_;
    [SerializeField] private GameObject pauseMenu_;
    [SerializeField] private GameObject pointsMenu_;

    [SerializeField] private string tagGameController_;

    private GameController gameController_;

    public static bool pauseGame_ = false;
    public static bool returMenu_ = false;

    private void Awake()
    {
        SetComponent();
    }

    private void Update()
    {
        CheckStage();
        PauseGame();
    }

    private void SetComponent()
    {
        if (gameController_ == null)
            gameController_ = GameObject.FindGameObjectWithTag(tagGameController_).GetComponent<GameController>();
    }

    private void CheckStage()
    {
        if (gameController_.stageActive_ == GameController.stringStageTutorial)
        {
            menuStage01_.SetActive(false);
            menuStage02_.SetActive(false);
            menuStage03_.SetActive(false);
            mainMenu_.SetActive(false);
            pauseMenu_.SetActive(false);
            pointsMenu_.SetActive(false);
        }

        if (gameController_.stageActive_ == GameController.stringStageMainMenu)
        {
            if(mainMenu_.activeInHierarchy == false)
            {
                ChangeMenu(mainMenu_);
            }
        }

        if(gameController_.stageActive_ == GameController.stringStage_01)
        {
            if (menuStage01_.activeInHierarchy == false)
            {
                ChangeMenu(menuStage01_);
                if (pointsMenu_.activeInHierarchy == false)
                    pointsMenu_.SetActive(true);
            }
        }

        if (gameController_.stageActive_ == GameController.stringStage_02)
        {
            if (menuStage02_.activeInHierarchy == false)
            {
                ChangeMenu(menuStage02_);
                if (pointsMenu_.activeInHierarchy == false)
                    pointsMenu_.SetActive(true);
            }
        }

        if (gameController_.stageActive_ == GameController.stringStage_03)
        {
            if (menuStage03_.activeInHierarchy == false)
            {
                ChangeMenu(menuStage03_);
                if (pointsMenu_.activeInHierarchy == false)
                    pointsMenu_.SetActive(true);
            }
        }
    }

    private void ChangeMenu(GameObject menuActive)
    {
        menuStage01_.SetActive(false);
        menuStage02_.SetActive(false);
        menuStage03_.SetActive(false);
        mainMenu_.SetActive(false);
        pauseMenu_.SetActive(false);
        pointsMenu_.SetActive(false);

        menuActive.SetActive(true);
    }

    private void PauseGame()
    {
        if(gameController_.stageActive_ != GameController.stringStageMainMenu)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pauseGame_ = !pauseGame_;
            }
        }

        if (pauseGame_)
        {
            Time.timeScale = 0;
            ChangeMenu(pauseMenu_);
        }
        else
        {
            Time.timeScale = 1;
            pauseMenu_.SetActive(false);
        }
    }

    public void ReturnMenu()
    {
        returMenu_ = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
