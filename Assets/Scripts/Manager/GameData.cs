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

        public List<GameObject> levelPrefabs;
        public GameObject charackterPrefab;
    }
    
}
