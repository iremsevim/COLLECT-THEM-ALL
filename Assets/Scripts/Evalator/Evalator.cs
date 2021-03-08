using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;


public class Evalator : MonoBehaviour
{
    public Text ballCountLabel;
    public int requiredBall;
    public int collectedBall;
    public List<GameObject> updownBorders;
    public List<GameObject> rightleftBorders;
    public Transform topPivot;
    public bool isRising = false;
    public Transform barrierJoint;
    
    

    public void TouchBall()
    {
        collectedBall++;
        UpdateText();
        if (isRising) return;
        if(FinishControl())
        {

            RiseUp();
            isRising = true;
        }
       else
        {
            Debug.Log("ihtiyaç bitti");

        }
    }
    private void UpdateText()
    {
        ballCountLabel.text = $"{collectedBall} / {requiredBall}";

    }
    private void RiseUp()
    {

        updownBorders.ForEach(x => x.SetActive(false));
        rightleftBorders.ForEach(x => x.GetComponent<Renderer>().material.color = GameData.Instance.generalData.groundborderColor);
        transform.DOMove(topPivot.position, 1f).OnComplete(()=> 
        {
            barrierJoint.DORotate(Vector3.zero, 1f).OnComplete(()=>
            {
               
                transform.GetComponent<Renderer>().material.color = GameData.Instance.generalData.groundColor;
                LevelObject.currentLevel.DetectionCheckPoint();

            });
            
        
        });
    }
    
    private  bool FinishControl()
    {
        return requiredBall <= collectedBall;
    }
}
