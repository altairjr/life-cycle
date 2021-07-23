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

    [Header("Stage 01")]
    private int eat_;

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
            if (Input.GetMouseButtonUp(0))
            {
                eat_++;
            }
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
            float fire = Input.GetAxisRaw("Fire1");
            if(fire > 0)
            {
                MovePlayerStage2();
            }
        }
    }

    #endregion

    #region Move Player

    private void MovePlayerStage2()
    {
        if(LeaftWater.howClickLeaftWatter_ != null)
        {
            playerStage_02.transform.position = LeaftWater.howClickLeaftWatter_.transform.localPosition;
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
                MovePlayerStage3();
            }
        }
    }

    #endregion

    #region Move Player System

    private void MovePlayerStage3()
    {
        Rigidbody2D _rigidbody2D = playerStage_03.GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce(new Vector2(0, 10));
    }

    #endregion

    #endregion
}
