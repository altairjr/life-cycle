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

    private void Update()
    {
        TimeOutJump();
        Posjump();
        Stay();
    }

    private void OnMouseDown()
    {
        howClickLeaftWatter_ = gameObject;
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
}
