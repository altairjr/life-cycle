using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaftWater : MonoBehaviour
{
    [Header("Set tag player stage 02")]
    [SerializeField] private GameObject frogPlayerStage_02;

    private float distance_ = 0;

    public static bool canJump_;
    public static bool stayLeaftWater_;
    public static GameObject posJump_;
    public static GameObject howClickLeaftWatter_;

    private float timeOutForjump_ = 0.5f;
    private float timeForJump_ = 0f;

    public bool playerJump_;

    private float timeEffectWatter_ = 0f;
    private float timeMaxEffect_ = 0.5f;

    private void Update()
    {
        Return();
        if (MenuController.returMenu_)
            return;

        if (MenuController.pauseGame_)
            return;

        TimeOutJump();
        Posjump();
        Stay();
        EffectWater();
    }

    private void OnMouseDown()
    {
        if (MenuController.returMenu_)
            return;

        if (MenuController.pauseGame_)
            return;

        howClickLeaftWatter_ = gameObject;
    }
    private void Return()
    {
        if (MenuController.returMenu_)
        {
            MenuController.pauseGame_ = false;
            playerJump_ = false;
            timeEffectWatter_ = 0;
            timeForJump_ = 0;
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    private void Posjump()
    {
        if (canJump_)
        {
            posJump_ = howClickLeaftWatter_;
        }
    }

    private void TimeOutJump()
    {
        if (stayLeaftWater_)
        {
            timeForJump_ += Time.deltaTime;
        }
        else
        {
            timeForJump_ = 0;
            canJump_ = false;
        }

        if(timeForJump_ >= timeOutForjump_)
        {
            timeForJump_ = 0;
            canJump_ = true;
        }
    }

    private void Stay()
    {
        if (posJump_ != null)
            distance_ = Vector2.Distance(frogPlayerStage_02.transform.position, posJump_.transform.position);

        if (distance_ == 0)
        {
            stayLeaftWater_ = true;
        }
        else
        {
            stayLeaftWater_ = false;
        }
    }

    private void EffectWater()
    {
        if (playerJump_)
        {
            timeEffectWatter_ += Time.deltaTime;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }

        if(timeEffectWatter_ >= timeMaxEffect_)
        {
            playerJump_ = false;
            timeEffectWatter_ = 0;
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("FrogPlayer"))
        {

            playerJump_ = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name.Equals("FrogPlayer"))
        {
            playerJump_ = false;
            timeEffectWatter_ = 0;
        }
    }
}
