using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxStage_03background : MonoBehaviour
{
    public float multiplaierSpeed_;

    private float speed_ = 1f;

    private MeshRenderer meshRenderer_;

    private void Start()
    {
        SetComponent();
    }

    private void SetComponent()
    {
        if (meshRenderer_ == null)
            meshRenderer_ = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (MenuController.returMenu_)
            return;

        if (MenuController.pauseGame_)
            return;

        if (PlayerController.eaglePlayerDeath_ == false)
            MoveBG();
    }

    private void MoveBG()
    {
        meshRenderer_.material.mainTextureOffset += new Vector2((speed_ * multiplaierSpeed_) * Time.deltaTime, 0);
    }
}

