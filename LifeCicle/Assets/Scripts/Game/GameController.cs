using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("System Controll Stages")]
    [SerializeField] private GameObject[] stage_01_;
    [SerializeField] private GameObject[] stage_02_;
    [SerializeField] private GameObject[] stage_03_;

    public string stageActive_;

    public static string stringStage_01 = "stage_01";
    public static string stringStage_02 = "stage_02";
    public static string stringStage_03 = "stage_03";

    [Header("System spawn stage 02")]
    [SerializeField] private Transform[] spawnButterflyPoints_;
    [SerializeField] private Transform[] spawnEaglePoints_;

    [Space]
    [SerializeField] private GameObject butterflyPrefab_;
    [SerializeField] private GameObject eaglePrefab_;

    //Lista de borboletas e gaviões instaciadas
    [Space]
    public List<GameObject> butterflyInstaciated_ = new List<GameObject>();
    public List<GameObject> eagleInstaciated_ = new List<GameObject>();

    //Temporizador para instanciar as borboletas
    private float couldownSpawnTimeButterfly_ = 6f;
    private float spawnTimeButterfly_ = 0f;

    //Temporizador para instanciar os gaviões
    private float couldownSpawnTimeEagle_ = 1f;
    private float spawnTimeEagle_ = 0f;

    [Header("System Spawn Stage 03")]
    [SerializeField] private Transform spawnPointSceneryUP;
    [SerializeField] private Transform spawnPointSceneryDown;

    [Space]
    [SerializeField] private List<GameObject> grounds_ = new List<GameObject>();

    //Lista de quantos intens de chão vou instaciado
    public List<GameObject> groundsInstaciatedUP_ = new List<GameObject>();
    public List<GameObject> groundsInstaciatedDown_ = new List<GameObject>();

    //Temporizador do chão sendo spawnado stage 03
    private float couldownSpawnTimeScenery = 1.5f;
    private float spawnTimeScenery = 0;

    private void Awake()
    {
        
    }

    private void Update()
    {
        CheckStage();
        stage01();
        stage02();
        stage03();
    }

    #region Controll Stages

    private void ChangeStage(GameObject _stage_enviroment, GameObject _stage_player)
    {
        stage_01_[0].SetActive(false);
        stage_01_[1].SetActive(false);

        stage_02_[0].SetActive(false);
        stage_02_[1].SetActive(false);

        stage_03_[0].SetActive(false);
        stage_03_[1].SetActive(false);

        _stage_enviroment.SetActive(true);
        _stage_player.SetActive(true);
    }

    private void CheckStage()
    {
        if (stage_01_[0].activeInHierarchy == true && stage_01_[1].activeInHierarchy == true)
        {
            stageActive_ = stringStage_01;
        }

        if (stage_02_[0].activeInHierarchy == true && stage_02_[1].activeInHierarchy == true)
        {
            stageActive_ = stringStage_02;
        }

        if (stage_03_[0].activeInHierarchy == true && stage_03_[1].activeInHierarchy == true)
        {
            stageActive_ = stringStage_03;
        }
    }

    #endregion

    #region Stage 01

    private void stage01()
    {
        if (stageActive_ == stringStage_01)
        {
            //Stage 01
        }
    }

    #endregion

    #region Stage 02

    private void stage02()
    {
        if (stageActive_ == stringStage_02)
        {
            //Stage 02
            SpawnButterfly();
            SpawnEagle();
        }
    }

    #region Butterfly system controll

    private void SpawnButterfly()
    {
        if(butterflyInstaciated_.Count <= 0)
        {
            spawnTimeButterfly_ += Time.deltaTime;
            if(spawnTimeButterfly_ >= couldownSpawnTimeButterfly_)
            {
                butterflyInstaciated_.Add(Instantiate(butterflyPrefab_, spawnButterflyPoints_[Random.Range(0, spawnButterflyPoints_.Length)].transform));
                spawnTimeButterfly_ = 0;
            }
        }
    }

    #endregion

    #region Eagle system controll

    private void SpawnEagle()
    {
        if (eagleInstaciated_.Count <= 1)
        {
            spawnTimeEagle_ += Time.deltaTime;
            if (spawnTimeEagle_ >= couldownSpawnTimeEagle_)
            {
                eagleInstaciated_.Add(Instantiate(eaglePrefab_, spawnEaglePoints_[Random.Range(0, spawnEaglePoints_.Length)].localPosition, Quaternion.identity, stage_02_[0].transform.GetChild(0).transform.parent));
                eagleInstaciated_.Add(Instantiate(eaglePrefab_, PlayerController.playerTransformStage_02.position, Quaternion.identity, stage_02_[0].transform.GetChild(0).transform.parent));
                spawnTimeEagle_ = 0;
            }
        }
    }

    #endregion

    #endregion

    #region Stage 03

    private void stage03()
    {
        if (stageActive_ == stringStage_03)
        {
            //Stage 03
            SpawnGrounds();
            CheckPositionGround();
        }
    }

    private void SpawnGrounds()
    {
        spawnTimeScenery += Time.deltaTime;
        if(spawnTimeScenery >= couldownSpawnTimeScenery)
        {
            groundsInstaciatedDown_.Add(Instantiate(grounds_[Random.Range(0, grounds_.Count)], spawnPointSceneryDown));
            groundsInstaciatedUP_.Add(Instantiate(grounds_[Random.Range(0, grounds_.Count)], spawnPointSceneryUP));
            spawnTimeScenery = 0;
        }
    }

    private void CheckPositionGround()
    {
        if(groundsInstaciatedUP_.Count > 0)
        {
            for(int i = 0; i <= groundsInstaciatedUP_.Count; i++)
            {
                groundsInstaciatedUP_[i].transform.rotation = Quaternion.Euler(0, 0, 180);
            }
        }
    }

    #endregion
}
