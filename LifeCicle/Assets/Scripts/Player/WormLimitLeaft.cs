using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormLimitLeaft : MonoBehaviour
{
    public static bool limitOverLeaft_;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        limitOverLeaft_ = true;
    }
}
