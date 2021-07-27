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

    private bool jump_;

    [HideInInspector]
    public bool grab_;

    public static bool notClick_;

    [Header("Stage 02")]
    public static Transform playerTransformStage_02;

    [Header("stage 03")]
    public float speed_;

    private void Update()
    {
        Stage01();
        Stage02();
        Stage03();
    }

    #region Stage 01

    private void Stage01()
    {
        InputPlayerStage01();
        wind();
    }

    #region InputPlayer

    private void InputPlayerStage01()
    {
        if(gameController_.stageActive_ == GameController.stringStage_01)
        {
            //Input Player stage 01
            float click = Input.GetAxisRaw("Fire1");
            if(click == 0)
            {
                notClick_ = true;
            }
            else
            {
                notClick_ = false;
            }

            if (Input.GetMouseButtonUp(0))
            {
                Eat();
            }

            if (Input.GetMouseButtonDown(1))
            {
                Grab();
            }

            if (Input.GetMouseButtonUp(1))
            {
                Grab();
            }
        }
    }

    #endregion

    #region Controlle Player

    private void Eat()
    {
        if (!grab_)
        {
            eat_++;
            gameController_.frogAlert_ += 2;
        }
    }

    private void Grab()
    {
        grab_ = !grab_;
    }

    #endregion

    #region Move Player

    private void wind()
    {
        if (gameController_.wind_ && !grab_)
        {
            playerStage_01.transform.Translate(0, gameController_.forceWind_ * Time.deltaTime,0);
        }
    }

    #endregion

    #endregion

    #region Stage 02

    private void Stage02()
    {
        InputPlayerStage02();
        GetPosition();
        SystemJump();
    }

    #region InputPlayer

    private void InputPlayerStage02()
    {
        if (gameController_.stageActive_ == GameController.stringStage_02)
        {
            //Input Player stage 02
            float fire = Input.GetAxisRaw("Fire1");
            if(Input.GetMouseButtonUp(0))
            {
                MovePlayerStage2();
            }
        }
    }

    #endregion

    #region Move Player

    private void MovePlayerStage2()
    {
        jump_ = true;
    }

    private void SystemJump()
    {
        if(jump_ && LeaftWater.posJump_ != null)
        {
            playerStage_02.transform.position = Vector2.MoveTowards(playerStage_02.transform.position, LeaftWater.posJump_.transform.position, 10 * Time.deltaTime);
        }
    }

    #endregion

    #region GetValues

    private void GetPosition()
    {
        playerTransformStage_02 = playerStage_02.transform;
    }

    #endregion

    #endregion

    #region Stage 03

    private void Stage03()
    {
        InputPlayerStage03();
    }

    #region InputPlayer

    private void InputPlayerStage03()
    {
        if (gameController_.stageActive_ == GameController.stringStage_03)
        {
            //Input Player stage 03
            float fire = Input.GetAxisRaw("Fire1");
            if(Input.GetMouseButtonDown(0))
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
        _rigidbody2D.velocity = (Vector2.up * speed_) * Time.deltaTime;
    }

    #endregion

    #endregion
}
