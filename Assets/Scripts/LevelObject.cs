using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObject : MonoBehaviour
{
    public static LevelObject currentLevel;
    public Transform nextlevelPoint;

    public Transform playerPoint;
    public int checkPoint;

    private void Awake()
    {
        currentLevel = this;
    }

    public void DetectionCheckPoint()
    {
        checkPoint++;
        UIManager.Instance.UpdateCheckPointImages();
        Player.Instance.IsMoving = true;
        if (checkPoint>=3)
        {
            Debug.Log("Level Complated");
            GameManager.instance.LevelComplate();
        }

    }
    
    

}
