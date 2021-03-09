using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Helicopter : BallThrower
{
    private Vector3 firstPos;
    public float multiper;
    public float fallingTime;
    public float fallingRate;
    public bool isFalling;
    public float Delta;

    public GameObject fallingballPrefab;

    public void Start()
    {
    }
    public override void Interact()
    {

        firstPos = transform.position;
        DOTween.To(() => multiper, x => multiper = x, 10, 1f).OnComplete(()=> 
        {
            isFalling =false;
        }).SetEase(Ease.Linear);
        isFalling = true;
    }

    private void PathDestination()
    {
        float cos = Mathf.Cos(Mathf.PI * multiper);
        transform.position = firstPos + new Vector3(cos*Delta,0,multiper);
    }

    public void Update()
    {
        
        if(isFalling)
        {
            fallingTime -= Time.deltaTime;
            if (fallingTime <= 0)
            {
                CreateFallingBall();
                fallingTime = fallingRate;
            }
            PathDestination();
        }
       
      
    }
    public void CreateFallingBall()
    {
        GameObject createdball = Instantiate(fallingballPrefab, transform.position, Quaternion.identity);
       
    }

}
