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
        if (MenuController.returMenu_)
            return;

        if (MenuController.pauseGame_)
            return;

        CheckPlayerDeath();
        if (PlayerController.eaglePlayerDeath_)
            return;

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

    private void CheckPlayerDeath()
    {
        if (PlayerController.eaglePlayerDeath_)
        {
            rigidbody2D_.velocity = new Vector2(0, 0);
        }
    }

    #endregion

    #region System Trigger

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagFindZone_))
        {
            Destroy(gameObject);
        }
    }

    #endregion
}
