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
  
       
    public override void MyAwake()
    {
        base.MyAwake();
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void FixedUpdate()
    {
        if (!GameManager.instance.runTime.isgameStarted || GameManager.instance.runTime.isgameComplated) return;
        rb.velocity = new Vector3(joyStick.Result*horizontalSpeed*generalSpeed, rb.velocity.y, forwardSpeed*generalSpeed);
    }
  
     public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Blocker")
        {

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
}
