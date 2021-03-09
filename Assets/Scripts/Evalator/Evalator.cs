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
    public List<BallThrower> throwers;
    
    

    public void TouchBall()
    {
        collectedBall++;
        UpdateText();
      
        
    }
    public IEnumerator EvalatorControl()
    {
        if (isRising) yield break;
        isRising = true;
        yield return new WaitForSeconds(2f);
        if (FinishControl())
        {
            RiseUp();
          
        }
        else
        {
            GameManager.instance.GameOver();  
        }

    }
    private void UpdateText()
    {
        ballCountLabel.text = $"{collectedBall} / {requiredBall}";

    }
    private void RiseUp()
    {
        Debug.Log("YÜKSELDİ");
        updownBorders.ForEach(x => x.SetActive(false));
        rightleftBorders.ForEach(x => x.GetComponent<Renderer>().material.color = GameData.Instance.generalData.groundborderColor);
        transform.DOMove(topPivot.position, 1f).OnComplete(()=> 
        {
            barrierJoint.DORotate(Vector3.zero, 1f).OnComplete(()=>
            {
                ParticleManager.Instance.ShowParticle("openlevel", barrierJoint.position);
                AudioManager.Instance.PlayAudio("winafterlevel");
                transform.GetComponent<Renderer>().material.color = GameData.Instance.generalData.groundColor;
                LevelObject.currentLevel.DetectionCheckPoint();
                throwers.ForEach(x => x.Interact());

            });
            
        
        });
    }
    
    private  bool FinishControl()
    {
        return requiredBall <= collectedBall;
    }
}
