using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour
{
    [Header("Tag Obstacles")]
    [SerializeField] private string tagObstacles_;

    [Header("Tag Collectable")]
    [SerializeField] private string tagCollectable_;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(tagObstacles_))
        {
            PlayerController.eaglePlayerDeath_ = true;

            Rigidbody2D _rigidbody2D = GetComponent<Rigidbody2D>();
            _rigidbody2D.AddForce(new Vector2(0, 300 * Time.deltaTime), ForceMode2D.Impulse);

            _rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagObstacles_))
        {
            PlayerController.eaglePlayerDeath_ = true;

            Rigidbody2D _rigidbody2D = GetComponent<Rigidbody2D>();
            _rigidbody2D.AddForce(new Vector2(0, 300 * Time.deltaTime), ForceMode2D.Impulse);

            _rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX;
        }
    }
}
