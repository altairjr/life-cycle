using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject menuStage01_;
    [SerializeField] private GameObject menuStage02_;
    [SerializeField] private GameObject menuStage03_;

    [SerializeField] private string tagGameController_;

    private GameController gameController_;

    private void Awake()
    {
        SetComponent();
    }

    private void Update()
    {
        CheckStage();
    }

    private void SetComponent()
    {
        if (gameController_ == null)
            gameController_ = GameObject.FindGameObjectWithTag(tagGameController_).GetComponent<GameController>();
    }

    private void CheckStage()
    {
        if(gameController_.stageActive_ == GameController.stringStage_01)
        {
            if (menuStage01_.activeInHierarchy == false)
                ChangeMenu(menuStage01_);
        }

        if (gameController_.stageActive_ == GameController.stringStage_02)
        {
            if (menuStage02_.activeInHierarchy == false)
                ChangeMenu(menuStage02_);
        }

        if (gameController_.stageActive_ == GameController.stringStage_03)
        {
            if (menuStage03_.activeInHierarchy == false)
                ChangeMenu(menuStage03_);
        }
    }

    private void ChangeMenu(GameObject menuActive)
    {
        menuStage01_.SetActive(false);
        menuStage02_.SetActive(false);
        menuStage03_.SetActive(false);

        menuActive.SetActive(true);
    }
}
