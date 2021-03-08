using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        CreateLevel(LevelObject.currentLevel.nextlevelPoint.position);
    }

    public void CreateLevel(Vector3 pos)
    {
       GameObject prefabs=GameData.Instance.generalData.levelPrefabs[Random.Range(0, GameData.Instance.generalData.levelPrefabs.Count)];
        GameObject createdlevel = Instantiate(prefabs, pos, Quaternion.identity);
       LevelObject levelObject=createdlevel.GetComponent<LevelObject>();
        if(pos==Vector3.zero)
        {
            GameObject charackter = Instantiate(GameData.Instance.generalData.charackterPrefab, levelObject.playerPoint.position, Quaternion.identity);
            CameraController.Instance.target = charackter.transform;
        }



    }

    public void StartGame()
    { Debug.Log("carptı");
        runTime.isgameStarted = true;
        UIManager.Instance.StartToPlayingGame();
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
