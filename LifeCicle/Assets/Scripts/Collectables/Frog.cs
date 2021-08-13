using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    [Header("Name player stage 03")]
    [SerializeField] private string namePlayer_;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals(namePlayer_))
        {
            Points _points = GameObject.FindGameObjectWithTag("GameController").GetComponent<Points>();
            _points.points_ += 200;

            Destroy(gameObject);
        }
    }
}
