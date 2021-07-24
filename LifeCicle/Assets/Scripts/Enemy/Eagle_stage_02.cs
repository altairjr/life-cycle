using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle_stage_02 : MonoBehaviour
{
    private float scaleStart_ = 4.5f;
    private float scaleEnd_ = 1.5f;

    private float multiplier_ = 2f;

    private float x_;
    private float y_;

    private GameController gameController_;

    private void Awake()
    {
        SetComponent();
    }

    private void Start()
    {
        x_ = scaleStart_;
        y_ = scaleStart_;
    }

    private void Update()
    {
        ControllEagle();
        Attack();
    }

    private void SetComponent()
    {
        if (gameController_ == null)
            gameController_ = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void ControllEagle()
    {
        x_ -= Time.deltaTime * multiplier_;
        y_ -= Time.deltaTime * multiplier_;

        transform.localScale = new Vector2(x_,y_);
        if (transform.localScale.x <= scaleEnd_)
            transform.localScale = new Vector2(scaleEnd_, scaleEnd_);
    }

    private void Attack()
    {
        if(transform.localScale.x <= scaleEnd_)
        {
            gameController_.eagleInstaciated_.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
