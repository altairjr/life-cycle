using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [Header("Tag GameController")]
    [SerializeField] private string tagGameController_;

    [Header("Velocity")]
    public float multiplier_;

    private float speed_ = 1f;
    private GameController gameController_;

    private void Awake()
    {
        SetComponetn();
    }

    private void SetComponetn()
    {
        if (gameController_ == null)
            gameController_ = GameObject.FindGameObjectWithTag(tagGameController_).GetComponent<GameController>();
    }

    private void Update()
    {
        WaterMove();
        Destroy();
    }

    private void WaterMove()
    {
        if (gameController_.stageActive_ == GameController.stringStage_02)
        {
            float _speed = (speed_ * multiplier_) * Time.deltaTime;
            transform.Translate(0, _speed, 0);
        }
    }

    private void Destroy()
    {
        if(transform.position.y <= -38)
        {
            Parallax.waterInstantiate_.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
