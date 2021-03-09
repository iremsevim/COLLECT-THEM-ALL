using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : SingleBehaviour<Player>
{
   
    public Rigidbody rb;
    public float forwardSpeed;
    public float generalSpeed;
    public float horizontalSpeed;
    public JoyStickControl joyStick;


    public Rotor rotor;
       
    public override void MyAwake()
    {
        base.MyAwake();
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        OpenCloseRotor();
    }
    public void FixedUpdate()
    {
        transform.eulerAngles = Vector3.zero;
        if (!GameManager.instance.runTime.isgameStarted || GameManager.instance.runTime.isgameComplated) return;
        rb.velocity = new Vector3(joyStick.Result*horizontalSpeed*generalSpeed, rb.velocity.y, forwardSpeed*generalSpeed);
    }
    public void Update()
    {
        if (!GameManager.instance.runTime.isgameStarted || GameManager.instance.runTime.isgameComplated) return;

        if (rotor.isrotorEnabled)
        ExacuteRotor();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Blocker")
        {
            rotor.isrotorEnabled = false;
            OpenCloseRotor();
            StartCoroutine(LevelObject.currentLevel.CurrentEvalator.EvalatorControl());
            IsMoving = false;
            Destroy(other.gameObject);

        }
    }
   public bool IsMoving
    {
        get
        {
            return generalSpeed >= 1;
        }
        set
        {
            generalSpeed = value ? 1 : 0;
        }
    }
    private void ExacuteRotor()
    {
        rotor.leftrotorPivot.Rotate(Vector3.up * Time.deltaTime * rotor.rotarSpeed);
        rotor.rightrotorPivot.Rotate(-Vector3.up * Time.deltaTime * rotor.rotarSpeed);
    }

    private void OpenCloseRotor()
    {
        rotor.rightRotor.SetActive(rotor.isrotorEnabled);
        rotor.leftRotor.SetActive(rotor.isrotorEnabled);
    }
    [System.Serializable]
    public struct Rotor
    {
        public bool isrotorEnabled;
        public GameObject rightRotor;
        public GameObject leftRotor;
        public Transform rightrotorPivot;
        public Transform leftrotorPivot;
        public float rotarSpeed;
    }
}
