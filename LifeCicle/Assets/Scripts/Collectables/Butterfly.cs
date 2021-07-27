using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butterfly : MonoBehaviour
{
    [Header("Name GameObject the of leaftWater")]
    [SerializeField] private string leaftWater_01_;
    [SerializeField] private string leaftWater_02_;
    [SerializeField] private string leaftWater_03_;
    [SerializeField] private string leaftWater_04_;

    [Header("Name frog player gameobject")]
    [SerializeField] private string FrogPlayerName_;

    [Header("Set velocity move butterfly")]
    public float speed_;

    private List<Transform> leaftWater_ = new List<Transform>();
    private Transform posMove_;

    private Rigidbody2D rigidbody2D_;
    private GameController gameController_;

    public bool clickButterfly_;

    private void Awake()
    {
        SetComponent();
    }

    private void Start()
    {
        SetMoveDestination();
    }

    private void Update()
    {
        MoveButterfly();
        ChangeClick();
        Collectable();
    }

    private void SetComponent()
    {
        if (rigidbody2D_ == null)
            rigidbody2D_ = GetComponent<Rigidbody2D>();

        if (gameController_ == null)
            gameController_ = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        if(leaftWater_.Count <= 4)
        {
            leaftWater_.Add(GameObject.Find(leaftWater_01_).GetComponent<Transform>());
            leaftWater_.Add(GameObject.Find(leaftWater_02_).GetComponent<Transform>());
            leaftWater_.Add(GameObject.Find(leaftWater_03_).GetComponent<Transform>());
            leaftWater_.Add(GameObject.Find(leaftWater_04_).GetComponent<Transform>());
        }
    }

    private void SetMoveDestination()
    {
        posMove_ = leaftWater_[Random.Range(0, leaftWater_.Count)];
    }

    private void MoveButterfly()
    {
        transform.position = Vector2.MoveTowards(transform.position, posMove_.position, speed_ * Time.deltaTime);
    }

    private void OnMouseUp()
    {
        clickButterfly_ = true;
    }

    private void ChangeClick()
    {
        if (!gameController_.range_)
            clickButterfly_ = false;
    }

    private void Collectable()
    {
        if (clickButterfly_ && gameController_.range_ && LeaftWater.stayLeaftWater_)
        {
            gameController_.butterflyInstaciated_.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
