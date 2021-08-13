using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle_stage_02 : MonoBehaviour
{
    private GameController gameController_;

    [Header("Time duration attack")]
    public float maxTimeAttack_;

    private float timeAttack_ = 0;

    private bool timeToAttack_;
    private bool attack_;

    public static bool grabFrog_;

    private void Awake()
    {
        SetComponent();
    }

    private void Update()
    {
        Attack();
        FinalAttack();
    }

    private void SetComponent()
    {
        if (gameController_ == null)
            gameController_ = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void Attack()
    {
        string _parameter = "attack";
        Animator _animator = transform.GetChild(0).gameObject.GetComponent<Animator>();

        _animator.SetBool(_parameter, true);
        timeToAttack_ = true;
    }

    private void FinalAttack()
    {
        if (timeToAttack_)
        {
            timeAttack_ += Time.deltaTime;
        }

        if(timeAttack_ >= (maxTimeAttack_ - 0.5f))
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }

        if (timeAttack_ >= (maxTimeAttack_ - 0.3f))
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }

        if (timeAttack_ >= maxTimeAttack_)
        {
            gameController_.eagleInstaciated_.Remove(gameObject);
            Destroy(gameObject);
        }

        if (attack_)
        {
            grabFrog_ = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("FrogPlayer"))
        {
            attack_ = true;
        }
    }
}
