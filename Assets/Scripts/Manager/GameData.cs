using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : SingleBehaviour<GameData>
{

    public GeneralData generalData;
  
    [System.Serializable]
    public class  GeneralData
    {
        public Color32 groundColor;
        public Color32 groundborderColor;

        public List<LevelData> levelPrefabs;
        public GameObject charackterPrefab;
    }
    [System.Serializable]
    public struct LevelData
    {
        public LevelDifficulity levelDifficulity;
        public List<GameObject> levelPrefab; 

        public GameObject Getlevel
        {
            get
            {
                return levelPrefab[Random.Range(0,levelPrefab.Count)];
            }
        }
    }
    public enum LevelDifficulity
    {
        basic=0,
        Medium=1,
        Hard=2
    }
       
    
}
