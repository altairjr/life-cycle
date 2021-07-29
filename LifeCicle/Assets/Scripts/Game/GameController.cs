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

    private float timeChangeStage_ = 0f;
    private float maxTimeChangeStage_ = 2f;

    public static string stringStage_01 = "stage_01";
    public static string stringStage_02 = "stage_02";
    public static string stringStage_03 = "stage_03";

    [Header("System Stage 01")]
    [SerializeField] private GameObject frog_;
    [SerializeField] private Transform[] frogAlertPositions_;
    [SerializeField] private GameObject UIAlertWind_;
    [SerializeField] private GameObject frogEatWorm_;
    [SerializeField] private GameObject frogEatButterfly_;
    [SerializeField] private GameObject plant_;
    public float forceWind_;

    private float couldownTimeWind_ = 5f;
    private float timeWind_ = 0f;
    private float durationTimeWind_ = 2f;
    private float durationWind_ = 0f;

    private float couldownTimeClear_ = 2f;
    private float timeClear_ = 0f;

    [HideInInspector]
    public bool wind_;

    [HideInInspector]
    public bool playSoundwind_;

    [HideInInspector]
    public int frogAlert_;

    [HideInInspector]
    public bool wormDeath_;

    [HideInInspector]
    public bool butterflyDeath_;

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
    private float couldownSpawnTimeEagle_01_ = 1f;
    private float couldownSpawnTimeEagle_02_ = 1f;
    private float couldownSpawnTimeEagle_03_ = 1f;
    private float spawnTimeEagle_01_ = 0f;
    private float spawnTimeEagle_02_ = 0f;
    private float spawnTimeEagle_03_ = 0f;

    //Range Frog
    [Header("Sysmte range frog")]
    [SerializeField] GameObject playerFrogStage_02;
    public bool range_;

    private float distance_;
    private float maxDistance_ = 2.2f;

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

    private void LevelUPStage01()
    {
        if(wormDeath_ == true || butterflyDeath_ == true)
        {
            timeChangeStage_ += Time.deltaTime;
        }

        if (wormDeath_ == true)
        {
            if (timeChangeStage_ >= maxTimeChangeStage_)
            {
                timeChangeStage_ = 0;
                ChangeStage(stage_02_[0], stage_02_[1]);
            }
        }

        if (butterflyDeath_ == true)
        {
            if (timeChangeStage_ >= (maxTimeChangeStage_ + 3.5f))
            {
                timeChangeStage_ = 0;
                ChangeStage(stage_02_[0], stage_02_[1]);
            }
        }
    }

    #endregion

    #region Stage 01

    private void stage01()
    {
        if (stageActive_ == stringStage_01)
        {
            //Stage 01
            Frog();
            Wind();
            ButterlfyDeath();
            LevelUPStage01();
        }
    }

    #region Controller Frog

    private void Frog()
    {
        if (PlayerController.notClick_)
        {
            timeClear_ += Time.deltaTime;
        }
        else
        {
            timeClear_ = 0;
        }

        if(timeClear_ >= couldownTimeClear_)
        {
            timeClear_ = 0;
            frogAlert_ = 0;
        }

        if(frogAlert_ < 25)
        {
            //pos start
            frog_.transform.localPosition = Vector2.MoveTowards(frog_.transform.localPosition, frogAlertPositions_[0].transform.localPosition, 1 * Time.deltaTime);
            frog_.transform.GetChild(0).gameObject.SetActive(true);
        }

        if(frogAlert_ >= 25 && frogAlert_ < 50)
        {
            //Eye
            frog_.transform.GetChild(0).gameObject.SetActive(false);
        }
        
        if(frogAlert_ >= 50 && frogAlert_ < 75)
        {
            //pos1
            frog_.transform.localPosition = Vector2.MoveTowards(frog_.transform.localPosition, frogAlertPositions_[1].transform.localPosition, 1 * Time.deltaTime);
        }

        if (frogAlert_ >= 75 && frogAlert_ < 100)
        {
            //pos2
            frog_.transform.localPosition = Vector2.MoveTowards(frog_.transform.localPosition, frogAlertPositions_[2].transform.localPosition, 1 * Time.deltaTime);
        }

        if (frogAlert_ >= 100)
        {
            //pos final
            frogEatWorm_.SetActive(true);
            frog_.SetActive(false);
            plant_.SetActive(false);
            wormDeath_ = true;
        }

        if (WormLimitLeaft.limitOverLeaft_)
        {
            frogEatWorm_.SetActive(true);
            frog_.SetActive(false);
            plant_.SetActive(false);
            wormDeath_ = true;
        }
    }

    private void ButterlfyDeath()
    {
        if(butterflyDeath_ == true)
        {
            frog_.SetActive(false);
            frogEatButterfly_.SetActive(true);
        }
    }

    #endregion

    #region Controller Wind

    private void Wind()
    {
        if(wormDeath_ == false || butterflyDeath_ == false)
        {
            if (!wind_)
            {
                timeWind_ += Time.deltaTime;
            }
            else
            {
                durationWind_ += Time.deltaTime;
            }

            if (timeWind_ >= (couldownTimeWind_ - 1))
            {
                UIAlertWind_.SetActive(true);
                playSoundwind_ = true;
            }

            if (timeWind_ >= couldownTimeWind_)
            {
                couldownTimeWind_ = Random.Range(5, 10);
                timeWind_ = 0;
                wind_ = true;
            }

            if (durationWind_ >= durationTimeWind_)
            {
                durationTimeWind_ = Random.Range(3, 6);
                UIAlertWind_.SetActive(false);
                durationWind_ = 0;
                wind_ = false;
            }

            if (wind_)
            {
                string _parameterPlant = "wind";
                Animator _anmiatorPlant = plant_.GetComponent<Animator>();

                _anmiatorPlant.SetBool(_parameterPlant, true);
            }
            else
            {
                string _parameter = "wind";
                Animator _anmiator = plant_.GetComponent<Animator>();

                _anmiator.SetBool(_parameter, false);
                playSoundwind_ = false;
            }
        }
    }

    #endregion

    #endregion

    #region Stage 02

    private void stage02()
    {
        if (stageActive_ == stringStage_02)
        {
            //Stage 02
            SpawnButterfly();
            SpawnEagle();
            CheckRangeFrogPlayerAndButterfly();
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

    private void CheckRangeFrogPlayerAndButterfly()
    {

        if(butterflyInstaciated_.Count > 0)
        {
            distance_ = Vector2.Distance(playerFrogStage_02.transform.position, butterflyInstaciated_[0].transform.position);
            if(distance_ != 0)
            {
                if(distance_ <= maxDistance_)
                {
                    range_ = true;
                }

                if(distance_ > maxDistance_)
                {
                    range_ = false;
                }
            }
        }
    }

    #endregion

    #region Eagle system controll

    private void SpawnEagle()
    {
        if (eagleInstaciated_.Count <= 1)
        {
            spawnTimeEagle_01_ += Time.deltaTime;
            spawnTimeEagle_02_ += Time.deltaTime;
            spawnTimeEagle_03_ += Time.deltaTime;
            if (spawnTimeEagle_01_ >= couldownSpawnTimeEagle_01_)
            {
                couldownSpawnTimeEagle_01_ = Random.Range(0.5f, 1.5f);
                eagleInstaciated_.Add(Instantiate(eaglePrefab_, spawnEaglePoints_[Random.Range(0, spawnEaglePoints_.Length)].localPosition, Quaternion.identity, stage_02_[0].transform.GetChild(0).transform.parent));
                spawnTimeEagle_01_ = 0;
            }

            if (spawnTimeEagle_02_ >= couldownSpawnTimeEagle_02_)
            {
                couldownSpawnTimeEagle_02_ = Random.Range(0.5f, 1.5f);
                eagleInstaciated_.Add(Instantiate(eaglePrefab_, spawnEaglePoints_[Random.Range(0, spawnEaglePoints_.Length)].localPosition, Quaternion.identity, stage_02_[0].transform.GetChild(0).transform.parent));
                spawnTimeEagle_02_ = 0;
            }

            if (spawnTimeEagle_03_ >= couldownSpawnTimeEagle_03_)
            {
                couldownSpawnTimeEagle_03_ = Random.Range(0.5f, 1.5f);
                eagleInstaciated_.Add(Instantiate(eaglePrefab_, spawnEaglePoints_[Random.Range(0, spawnEaglePoints_.Length)].localPosition, Quaternion.identity, stage_02_[0].transform.GetChild(0).transform.parent));
                spawnTimeEagle_03_ = 0;
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
