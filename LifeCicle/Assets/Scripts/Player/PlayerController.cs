using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Game Controller")]
    [SerializeField] private GameController gameController_;

    [Header("Player Prefab in Stage")]
    [SerializeField] private GameObject playerStage_01;
    [SerializeField] private GameObject playerStage_02;
    [SerializeField] private GameObject playerStage_03;

    [Header("UI Stage 01")]
    [SerializeField] private Image barFill_;

    [Header("Stage 01")]
    [SerializeField] private GameObject pivotPlayerStage_01;

    private float eanting_ = 0f;
    private float eantingMax_ = 100f;

    public float timeNoClick = 0f;
    private float MaxTimeNoClick = 2f;

    private bool eat_;
    private bool jump_;
    public bool eatingDown = false;

    [HideInInspector]
    public bool grab_;

    public static bool notClick_;

    [Header("Stage 02")]
    public static Transform playerTransformStage_02;
    public static bool clickForTutorial_;

    [Header("stage 03")]
    public float speed_;

    public static bool eaglePlayerDeath_;

    private void Update()
    {
        Return();
        if (MenuController.pauseGame_)
            return;

        Stage01();
        Stage02();
        Stage03();
    }

    private void Return()
    {
        if (MenuController.returMenu_)
        {
            MenuController.pauseGame_ = false;
            eanting_ = 0;
            grab_ = false;
            pivotPlayerStage_01.SetActive(true);
            playerStage_01.transform.position = pivotPlayerStage_01.transform.position;
            clickForTutorial_ = false;
            clickForTutorial_ = false;
            jump_ = false;
            eaglePlayerDeath_ = false;

            playerStage_02.transform.position = new Vector2(0, -3.12f);
            playerStage_02.transform.rotation = Quaternion.Euler(0, 0, 0);

            playerStage_03.transform.position = new Vector2(-5.45f, 2.18f);
            playerStage_03.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            playerStage_03.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    #region Stage 01

    private void Stage01()
    {
        if (gameController_.stageActive_ == GameController.stringStage_01)
        {
            InputPlayerStage01();
            wind();
            AnimationGrab();
            AnimationEat();
            BarrFillMet();
            WormDeath();
            Met();
            ButterflyDeath();
        }
    }

    #region InputPlayer

    private void InputPlayerStage01()
    {
        //Input Player stage 01

        float _click = Input.GetAxisRaw("Fire1");

        if (_click == 0)
        {
            notClick_ = true;
        }
        else
        {
            notClick_ = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Eat();
        }

        if (Input.GetMouseButtonUp(0))
        {
            eat_ = false;
        }

        if (Input.GetMouseButtonDown(1))
        {
            Grab();
        }

        if (Input.GetMouseButtonUp(1))
        {
            Grab();
        }

        if (Input.GetMouseButtonDown(0) && Input.GetMouseButtonDown(1))
        {
            notClick_ = false;
        }
    }

    #endregion

    #region Controlle Player

    private void Eat()
    {
        if (!grab_ && gameController_.wormDeath_ == false && gameController_.butterflyDeath_ == false)
        {
            eanting_ += 0.4f;
            gameController_.frogAlert_ += 2;
        }
        eat_ = !eat_;
    }

    private void Grab()
    {
        grab_ = !grab_;
    }

    private void BarrFillMet()
    {
        float _eatPercent = eanting_ / eantingMax_;
        barFill_.fillAmount = _eatPercent;


        if (notClick_ == true || grab_ == true)
        {
            timeNoClick += Time.deltaTime;
        }
        else
        {
            timeNoClick = 0;
            eatingDown = false;
        }

        if (timeNoClick >= MaxTimeNoClick)
        {
            timeNoClick = 0;
            eatingDown = true;
        }

        if (eatingDown && gameController_.wormDeath_ == false && gameController_.butterflyDeath_ == false)
        {
            eanting_ -= 0.01f;
        }
    }

    private void WormDeath()
    {
        if (gameController_.wormDeath_ == true)
        {
            pivotPlayerStage_01.SetActive(false);
        }
        else
        {
            pivotPlayerStage_01.SetActive(true);
        }
    }

    private void Met()
    {
        if (eanting_ >= eantingMax_)
        {
            eanting_ = eantingMax_;
            gameController_.butterflyDeath_ = true;
        }
    }

    private void ButterflyDeath()
    {
        if (gameController_.butterflyDeath_ == true)
        {
            pivotPlayerStage_01.SetActive(false);
        }
        else
        {
            pivotPlayerStage_01.SetActive(true);
        }
    }

    private void AnimationEat()
    {
        Animator _animator = playerStage_01.GetComponent<Animator>();
        string _parameter = "eat";

        if (eat_)
            _animator.SetBool(_parameter, true);
        else
            _animator.SetBool(_parameter, false);
    }

    private void AnimationGrab()
    {
        Animator _animator = playerStage_01.GetComponent<Animator>();
        string _parameter = "grab";

        if (grab_)
            _animator.SetBool(_parameter, true);
        else
            _animator.SetBool(_parameter, false);
    }

    #endregion

    #region Move Player

    private void wind()
    {
        if (gameController_.wind_ && !grab_ && !WormLimitLeaft.limitOverLeaft_)
        {
            playerStage_01.transform.Translate(0, gameController_.forceWind_ * Time.deltaTime, 0);
        }
    }

    #endregion

    #region Get Values

    public float GetValue ()
    {
        float getValue = 0;
        getValue = eanting_;
        return (getValue);
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
        clickForTutorial_ = true;
    }

    private void SystemJump()
    {
        if(jump_ && LeaftWater.posJump_ != null)
        {
            string _parameter = "jump";
            Animator _animator = playerStage_02.transform.GetChild(0).gameObject.GetComponent<Animator>();
            playerStage_02.transform.position = Vector2.MoveTowards(playerStage_02.transform.position, LeaftWater.posJump_.transform.position, 10 * Time.deltaTime);

            Rigidbody2D _rigidbody2D = playerStage_02.GetComponent<Rigidbody2D>();

            Vector2 lookDir = playerStage_02.transform.position - LeaftWater.posJump_.transform.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90f;
            _rigidbody2D.rotation = angle;

            _animator.SetBool(_parameter, true);
        }

        if(LeaftWater.posJump_ != null)
        {
            if (playerStage_02.transform.position == LeaftWater.posJump_.transform.position)
            {
                string _parameter = "jump";
                Animator _animator = playerStage_02.transform.GetChild(0).gameObject.GetComponent<Animator>();
                _animator.SetBool(_parameter, false);
            }
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
        PlayerDeath();

        if (eaglePlayerDeath_ == false)
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

            if (Input.GetMouseButtonUp(0))
            {
                string _parameterFly = "fly";
                Animator _animator = playerStage_03.transform.GetChild(0).gameObject.GetComponent<Animator>();
                _animator.SetBool(_parameterFly, false);
            }
        }
    }

    #endregion

    #region Move Player System

    private void MovePlayerStage3()
    {
        Rigidbody2D _rigidbody2D = playerStage_03.GetComponent<Rigidbody2D>();
        _rigidbody2D.velocity = Vector2.zero;
        _rigidbody2D.AddForce(new Vector2(0, speed_));

        string _parameterFly = "fly";
        Animator _animator = playerStage_03.transform.GetChild(0).gameObject.GetComponent<Animator>();
        _animator.SetBool(_parameterFly, true);
    }

    private void PlayerDeath()
    {
        if (eaglePlayerDeath_)
        {
            Rigidbody2D _rigidbody2D = playerStage_03.GetComponent<Rigidbody2D>();

            playerStage_03.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    #endregion

    #endregion
}
