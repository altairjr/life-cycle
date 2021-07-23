using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Game Controller")]
    [SerializeField] private GameController gameController_;

    [Header("Player Prefab in Stage")]
    [SerializeField] private GameObject playerStage_01;
    [SerializeField] private GameObject playerStage_02;
    [SerializeField] private GameObject playerStage_03;

    private void Awake()
    {
        
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        InputPlayerStage01();
        InputPlayerStage02();
        InputPlayerStage03();
    }

    #region Stage 01

    #region InputPlayer

    private void InputPlayerStage01()
    {
        if(gameController_.stageActive_ == GameController.stringStage_01)
        {
            //Input Player stage 01
        }
    }

    #endregion

    #endregion

    #region Stage 02

    #region InputPlayer

    private void InputPlayerStage02()
    {
        if (gameController_.stageActive_ == GameController.stringStage_02)
        {
            //Input Player stage 02
        }
    }

    #endregion

    #endregion

    #region Stage 03

    #region InputPlayer

    private void InputPlayerStage03()
    {
        if (gameController_.stageActive_ == GameController.stringStage_03)
        {
            //Input Player stage 03
            float fire = Input.GetAxisRaw("Fire1");
            if(fire > 0)
            {
                MovePlayer();
            }
        }
    }

    #endregion

    #region Move Player System

    private void MovePlayer()
    {
        Rigidbody2D _rigidbody2D = playerStage_03.GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce(new Vector2(0, 10));
    }

    #endregion

    #endregion
}
