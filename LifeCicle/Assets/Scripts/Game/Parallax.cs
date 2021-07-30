using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [Header("Prefab Water")]
    [SerializeField] private GameObject prefabWater_;

    [Header("Pivot Water")]
    [SerializeField] private Transform pivotWater_;

    [Header("Tag GameController")]
    [SerializeField] private string tagGameController_;

    [Header("Water Instantiate")]
    public static List<GameObject> waterInstantiate_ = new List<GameObject>();

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
        if (gameController_.stageActive_ == GameController.stringStage_02)
        {
            UpdateList();
            SystemParallax();
        }
    }

    private void UpdateList()
    {
        if (waterInstantiate_.Count == 0)
        {
            waterInstantiate_.Add(GameObject.Find("Water"));
        }
    }

    private void SystemParallax()
    {
        if(waterInstantiate_.Count <= 1)
        {
            if(waterInstantiate_[0].transform.position.y <= -26)
            {
                waterInstantiate_.Add(Instantiate(prefabWater_, pivotWater_.position, Quaternion.identity, pivotWater_.transform.parent));
            }
        }
    }
}
