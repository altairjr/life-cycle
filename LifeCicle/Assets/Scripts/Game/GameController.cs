using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("System Controll Stages")]
    [SerializeField] private GameObject[] mainMenu_;
    [SerializeField] private GameObject[] stage_01_;
    [SerializeField] private GameObject[] stage_02_;
    [SerializeField] private GameObject[] stage_03_;

    public string stageActive_;

    private float timeChangeStage_ = 0f;
    private float maxTimeChangeStage_ = 2f;

    public static string stringStageMainMenu = "mainMenu";
    public static string stringStageTutorial = "tutorial";
    public static string stringStage_01 = "stage_01";
    public static string stringStage_02 = "stage_02";
    public static string stringStage_03 = "stage_03";

    public static bool playTutorial01_;
    public static bool playTutorial02_;
    public static bool playTutorial03_;
    public static bool playTutorial04_;

    [Header("System Stage 01")]
    [SerializeField] private GameObject frog_;
    [SerializeField] private Transform[] frogAlertPositions_;
    [SerializeField] private GameObject UIAlertWind_;
    [SerializeField] private GameObject frogEatWorm_;
    [SerializeField] private GameObject frogEatButterfly_;
    [SerializeField] private GameObject plant_;
    [SerializeField] private GameObject light_;
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
    private float spawnTimeEagle_01_ = 0f;
    private float spawnTimeEagle_02_ = 0f;

    //Range Frog
    [Header("Sysmte range frog")]
    [SerializeField] GameObject playerFrogStage_02;
    public bool range_;

    [Header("Distance")]
    public float distance_;
    public float maxDistance_ = 2.2f;

    [Header("System Spawn Stage 03")]
    [SerializeField] private Transform spawnPointSceneryUP;
    [SerializeField] private Transform spawnPointSceneryDown;

    [Space]
    [SerializeField] private List<GameObject> grounds_ = new List<GameObject>();
    [SerializeField] private List<GameObject> galhos_ = new List<GameObject>();

    //Lista de quantos intens de chão vou instaciado
    public List<GameObject> groundsInstaciatedUP_ = new List<GameObject>();
    public List<GameObject> groundsInstaciatedDown_ = new List<GameObject>();

    //Temporizador do chão sendo spawnado stage 03
    private float couldownSpawnTimeScenery = 1.5f;
    private float spawnTimeScenery = 0;

    private void Update()
    {
        CheckStage();
        ChangeMainMenu();
        Return();

        if (MenuController.pauseGame_)
            return;

        StartGameAfterTutorial();
        AffterTutorial02();
        AffterTutorial03();
        AffterTutorial04();
        GameOver();

        stage01();
        stage02();
        stage03();
    }

    #region Controll Stages

    private void ChangeStage(GameObject _stage_enviroment, GameObject _stage_player)
    {
        mainMenu_[0].SetActive(false);

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
        if (MenuController.returMenu_)
        {
            stageActive_ = stringStageMainMenu;
        }

        if(mainMenu_[0].activeInHierarchy == true)
        {
            stageActive_ = stringStageMainMenu;
        }

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

    private void Return()
    {
        if (MenuController.returMenu_)
        {
            stageActive_ = stringStageMainMenu;
            ChangeStage(mainMenu_[0], mainMenu_[0]);
            wormDeath_ = false;
            butterflyDeath_ = false;

            frogEatWorm_.SetActive(false);
            frog_.SetActive(true);
            plant_.SetActive(true);
            frogEatButterfly_.SetActive(false);
            light_.SetActive(true);
            frogAlert_ = 0;
            wind_ = false;
            timeWind_ = 0;
            durationWind_ = 0;
            spawnTimeScenery = 0;
            Tutorial.tutorView_ = 0;
            Eagle_stage_02.grabFrog_ = false;
            playerFrogStage_02.SetActive(true);
            timeChangeStage_ = 0;
            playTutorial01_ = false;
            playTutorial02_ = false;
            playTutorial03_ = false;
            playTutorial04_ = false;

            LeaftWater.posJump_ = null;
            LeaftWater.howClickLeaftWatter_ = null;
            LeaftWater.stayLeaftWater_ = false;
            LeaftWater.canJump_ = true;

            Tutorial.tutorial01Complet_ = false;
            Tutorial.tutorial02Complet_ = false;
            Tutorial.tutorial03Complet_ = false;
            Tutorial.tutorial04Complet_ = false;

            spawnTimeEagle_01_ = 0;
            spawnTimeEagle_02_ = 0;
            spawnTimeButterfly_ = 0;

            if (eagleInstaciated_.Count > 0)
            {
                Destroy(eagleInstaciated_[0]);
                eagleInstaciated_.Clear();
            }

            if (butterflyInstaciated_.Count > 0)
            {
                Destroy(butterflyInstaciated_[0]);
                butterflyInstaciated_.Clear();
            }

            if (groundsInstaciatedDown_.Count > 0)
            {
                for(int i = 0; i < groundsInstaciatedDown_.Count; i++)
                {
                    Destroy(groundsInstaciatedDown_[i]);
                }
                groundsInstaciatedDown_.Clear();
            }

            if (groundsInstaciatedUP_.Count > 0)
            {
                for (int i = 0; i < groundsInstaciatedUP_.Count; i++)
                {
                    Destroy(groundsInstaciatedUP_[i]);
                }
                groundsInstaciatedUP_.Clear();
            }

            frog_.transform.localPosition = frogAlertPositions_[0].transform.localPosition;
            MenuController.returMenu_ = false;
            MenuController.pauseGame_ = false;
        }
    }

    private void ChangeMainMenu()
    {
        if(stageActive_ == stringStageMainMenu)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (MenuController.returMenu_ == true)
                    MenuController.returMenu_ = false;

                stageActive_ = stringStageTutorial;
                mainMenu_[0].SetActive(false);
                playTutorial01_ = true;
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }

    private void StartGameAfterTutorial()
    {
        if (Tutorial.tutorial01Complet_)
        {
            if (stage_01_[0].activeInHierarchy == false && stage_01_[1].activeInHierarchy == false)
            {
                Tutorial.tutorial01Complet_ = false;
                ChangeStage(stage_01_[0], stage_01_[1]);
            }
        }
    }

    private void AffterTutorial02()
    {
        if (Tutorial.tutorial02Complet_)
        {
            if (stage_02_[0].activeInHierarchy == false && stage_02_[1].activeInHierarchy == false)
            {
                Tutorial.tutorial02Complet_ = false;
                ChangeStage(stage_02_[0], stage_02_[1]);
            }
        }
    }

    private void AffterTutorial03()
    {
        if (Tutorial.tutorial03Complet_)
        {
            if (stage_03_[0].activeInHierarchy == false && stage_03_[1].activeInHierarchy == false)
            {
                Tutorial.tutorial03Complet_ = false;
                ChangeStage(stage_03_[0], stage_03_[1]);
            }
        }
    }

    private void AffterTutorial04()
    {
        if (Tutorial.tutorial04Complet_)
        {
            Tutorial.tutorial04Complet_ = false;
            stageActive_ = stringStageMainMenu;
            ChangeStage(mainMenu_[0], mainMenu_[0]);
            MenuController.returMenu_ = true;
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
                stageActive_ = stringStageTutorial;
                playTutorial02_ = true;
                stage_01_[0].SetActive(false);
                stage_01_[1].SetActive(false);
            }
        }

        if (butterflyDeath_ == true)
        {
            if (timeChangeStage_ >= (maxTimeChangeStage_ + 3.5f))
            {
                timeChangeStage_ = 0;
                stageActive_ = stringStageTutorial;
                playTutorial02_ = true;
                stage_01_[0].SetActive(false);
                stage_01_[1].SetActive(false);
            }
        }
    }

    private void GameOver()
    {
        if(PlayerController.eaglePlayerDeath_ == true)
        {
            timeChangeStage_ += Time.deltaTime;
            Points _points = GetComponent<Points>();

            if(_points.points_ > PlayerPrefs.GetFloat("points", 0))
            {
                PlayerPrefs.SetFloat("points", _points.points_);
                PlayerPrefs.Save();
            }

            if (timeChangeStage_ >= (maxTimeChangeStage_ + 2f))
            {
                PlayerController.eaglePlayerDeath_ = false;
                timeChangeStage_ = 0;
                stageActive_ = stringStageTutorial;
                playTutorial04_ = true;
                stage_03_[0].SetActive(false);
                stage_03_[1].SetActive(false);
            }
        }
    }

    private void LevelUPStage02()
    {
        if (Eagle_stage_02.grabFrog_ == true)
        {
            timeChangeStage_ += Time.deltaTime;
            playerFrogStage_02.SetActive(false);
        }

        if (timeChangeStage_ >= (maxTimeChangeStage_ - 1f))
        {
            timeChangeStage_ = 0;
            stageActive_ = stringStageTutorial;
            playTutorial03_ = true;
            stage_02_[0].SetActive(false);
            stage_02_[1].SetActive(false);
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
            light_.SetActive(false);
            plant_.SetActive(false);
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
                UIAlertWind_.SetActive(false);
                timeWind_ += Time.deltaTime;
            }
            else
            {
                durationWind_ += Time.deltaTime;
            }

            if (timeWind_ >= (couldownTimeWind_ - 1))
            {
                UIAlertWind_.SetActive(true);
                Tutorial.WindTutor_ = true;
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
                Tutorial.WindTutor_ = false;
                Tutorial.tutorView_ = 1;
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
            LevelUPStage02();
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
            if (spawnTimeEagle_01_ >= couldownSpawnTimeEagle_01_)
            {
                couldownSpawnTimeEagle_01_ = Random.Range(0.5f, 1.5f);
                eagleInstaciated_.Add(Instantiate(eaglePrefab_, spawnEaglePoints_[Random.Range(0, spawnEaglePoints_.Length)].localPosition, Quaternion.identity, stage_02_[0].transform.GetChild(0).transform.parent));
                spawnTimeEagle_01_ = 0;
            }

            if (spawnTimeEagle_02_ >= couldownSpawnTimeEagle_02_)
            {
                couldownSpawnTimeEagle_02_ = Random.Range(0.8f, 2.5f);
                eagleInstaciated_.Add(Instantiate(eaglePrefab_, spawnEaglePoints_[Random.Range(0, spawnEaglePoints_.Length)].localPosition, Quaternion.identity, stage_02_[0].transform.GetChild(0).transform.parent));
                spawnTimeEagle_02_ = 0;
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
        }
    }

    private void SpawnGrounds()
    {
        spawnTimeScenery += Time.deltaTime;
        if(spawnTimeScenery >= couldownSpawnTimeScenery)
        {
            groundsInstaciatedDown_.Add(Instantiate(grounds_[Random.Range(0, grounds_.Count)], spawnPointSceneryDown));
            groundsInstaciatedUP_.Add(Instantiate(galhos_[Random.Range(0, galhos_.Count)], spawnPointSceneryUP));
            spawnTimeScenery = 0;
        }
    }

    #endregion
}
