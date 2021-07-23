using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaftWater : MonoBehaviour
{
    public static GameObject howClickLeaftWatter_;

    private void OnMouseDown()
    {
        howClickLeaftWatter_ = gameObject;
    }
}
