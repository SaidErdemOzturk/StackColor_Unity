using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerManager : Singleton<PlayerManager>
{
    [SerializeField] private float horizontalSpeed;
    //[SerializeField] private ParticleSystem particleSpeed;
    //[SerializeField] private Camera getAxisCamera;
    private AnimationManager animationManager;
    private GameManager gameManager;
    private float speed;
    private Rigidbody rigidbody;
    private bool horizontalController;
    private float horizontal;
    private float positionX;
    private Animator anim;
    //public Animator anim;
    private void Awake()
    {
        anim = transform.GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        animationManager = AnimationManager.GetInstance();
        gameManager = GameManager.GetInstance();
        rigidbody = GetComponent<Rigidbody>();
    }

    public Animator GetAnim()
    {
        return anim;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            horizontalController = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            horizontalController = false;
        }
    }

    private void FixedUpdate()
    {
        if (gameManager.GetPlayType() != PlayType.Finish)
        {
            SetForwardMovmentPlayer();
            SetHorizontalMovmentPlayer(horizontalController);
        }
    }

    private void SetForwardMovmentPlayer()
    {
        rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, speed);
    }

    private void SetHorizontalMovmentPlayer(bool horizontalController)
    {

        horizontal = Input.GetAxis("Mouse X");
        if (horizontalController)
        {

            if (horizontal != 0)
            {
                positionX = horizontal * horizontalSpeed;
            }
            rigidbody.velocity = new Vector3(positionX,rigidbody.velocity.y,rigidbody.velocity.z);
            float tempX = Mathf.Clamp(transform.position.x, -2, 2);
            transform.position = new Vector3(tempX,transform.position.y,transform.position.z);
        }
        else
        {
            positionX = 0;
            rigidbody.velocity = new Vector3(positionX,rigidbody.velocity.y,rigidbody.velocity.z);
        }
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
        animationManager.SetSpeedAnim(speed/5);
    }

    public float GetSpeed()
    {
        return speed;
    }
}
