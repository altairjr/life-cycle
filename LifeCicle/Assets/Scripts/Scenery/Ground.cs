using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [Header("Tags")]
    [SerializeField] private string tagFindZone_;
    [SerializeField] private string tagGameController_;

    private Rigidbody2D rigidbody2D_;
    private GameController gameController_;

    private void Awake()
    {
        SetComponent();
    }

    private void Update()
    {
        MoveGround();   
    }

    #region SetComponent

    private void SetComponent()
    {
        if (rigidbody2D_ == null)
            rigidbody2D_ = GetComponent<Rigidbody2D>();

        if (gameController_ == null)
            gameController_ = GameObject.FindGameObjectWithTag(tagGameController_).GetComponent<GameController>();
    }

    #endregion

    #region Move Ground System

    private void MoveGround()
    {
        rigidbody2D_.velocity = new Vector2(-5, 0);
    }

    #endregion

    #region System Trigger

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagFindZone_))
        {
            for(int i = 0; i <= 0; i++)
            {
                if(gameObject == gameController_.groundsInstaciatedDown_[i])
                {
                    gameController_.groundsInstaciatedDown_.Remove(gameObject);
                    Destroy(gameObject);
                }

                if (gameObject == gameController_.groundsInstaciatedUP_[i])
                {
                    gameController_.groundsInstaciatedUP_.Remove(gameObject);
                    Destroy(gameObject);
                }
            }
        }
    }

    #endregion
}
