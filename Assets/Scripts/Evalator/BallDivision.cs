using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDivision : BallThrower
{
    private Rigidbody rb;
    public GameObject createdsmallBall;
    public int ballcount;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public override void Interact()
    {
        Fall();
    }

    public void Fall()
    {
        rb.useGravity = true;
    }
    public void OnCollisionEnter(Collision collision)
    {
       
        for (int i = 0; i < ballcount; i++)
        {
            GameObject create = Instantiate(createdsmallBall, transform.position, Quaternion.identity);
        }
        gameObject.SetActive(false);

    }
    }



