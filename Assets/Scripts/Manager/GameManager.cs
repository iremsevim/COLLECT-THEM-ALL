using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public RunTime runTime;
    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            runTime.currentLevel = PlayerPrefs.GetInt("lastlevel",1);

        }
        else
        {
            if(instance!=this)
            {
                Destroy(gameObject);
            }
        }
    }
    public void Start()
    {
        CreateLevel(Vector3.zero);
    }

    public void NextLevel()
    {
        runTime.currentLevel++;
        GameObject x = LevelObject.currentLevel.gameObject;
        CreateLevel(LevelObject.currentLevel.nextlevelPoint.position);
     
        UIManager.Instance.RestartGameUI();
        UIManager.Instance.UpdateLevelNameLabels();
        Player.Instance.transform.DOMove(LevelObject.currentLevel.playerPoint.position, 1f).OnComplete(() => 
        {

            
            runTime.isgameStarted = false;
            runTime.isgameover = false;
            runTime.isgameComplated = false;
             Destroy(x);
        });

    }

    public void CreateLevel(Vector3 pos)
    {
        GameObject tempPrefab = null;
        int mod = runTime.currentLevel % 9;
        if (mod<=3)
        {
            //easy
        tempPrefab =GameData.Instance.generalData.levelPrefabs.Find(x => x.levelDifficulity == GameData.LevelDifficulity.basic).Getlevel;
        }
        else if (mod<=6)
        {
            //mid
            tempPrefab = GameData.Instance.generalData.levelPrefabs.Find(x => x.levelDifficulity == GameData.LevelDifficulity.Medium).Getlevel;
        }
        else if (mod<=9)
        {
            //hard
            tempPrefab = GameData.Instance.generalData.levelPrefabs.Find(x => x.levelDifficulity == GameData.LevelDifficulity.Hard).Getlevel;
        }

        GameObject createdlevel = Instantiate(tempPrefab, pos, Quaternion.identity);
       LevelObject levelObject=createdlevel.GetComponent<LevelObject>();
        if(pos==Vector3.zero)
        {
            GameObject charackter = Instantiate(GameData.Instance.generalData.charackterPrefab, levelObject.playerPoint.position, Quaternion.identity);
            CameraController.Instance.target = charackter.transform;
        }



    }

    public void StartGame()
    {
        if (runTime.isgameStarted) return;
        Debug.Log("carptı");
        runTime.isgameStarted = true;
        UIManager.Instance.StartToPlayingGame();
        UIManager.Instance.UpdateLevelNameLabels();
    }
    public void GameOver()
    {
        runTime.isgameover = true;
        UIManager.Instance.PlayingGameToGameOverScreen();
    }
    public void LevelComplate()
    {
        runTime.isgameComplated = true;
       
        UIManager.Instance.PlayingGameToComplatedScreen();
    }
    public void ReStartLevel()
    {
        runTime.isgameStarted = false;
        runTime.isgameover = false;
        runTime.isgameComplated = false;
        Destroy(Player.Instance.gameObject);
        Destroy(LevelObject.currentLevel.gameObject);
        CreateLevel(Vector3.zero);
        CameraController.Instance.FastFocus();

        UIManager.Instance.RestartGameUI();

    }


    

    [System.Serializable]
    public class RunTime
    {
        public bool isgameStarted;
        public bool isgameComplated;
        public bool isgameover;
        public int currentLevel;

    }
}
