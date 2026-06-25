using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
using Unity.VisualScripting;
using System.Collections.Specialized;

public class ScoreSaveLoad : MonoBehaviour
{
    string dataPath;
    public SC_ScoreDataBase playerScoreDataBase;

    [System.Serializable]
    public class PlayerScoreData
    {
        public int[] characterID;
        public float[] playerScore;
    }
    [SerializeField]
    PlayerScoreData playerScoreData;

    private void Awake() 
    {
        dataPath = Application.dataPath + "/UserData/TestJson.json";
    }

    public void SaveScoreToJson()
    {
        StreamWriter writer;

        playerScoreDataBase.playerScore.Sort((a,b) => (int)b.playerScore - (int)a.playerScore);
        for(int i = 0;i < playerScoreDataBase.playerScore.Count; i++)
        {
            playerScoreData.characterID[i] = playerScoreDataBase.playerScore[i].characterID;
            playerScoreData.playerScore[i] = playerScoreDataBase.playerScore[i].playerScore;
        }
        string strJson = JsonUtility.ToJson(playerScoreData);
        writer = new StreamWriter(dataPath, false);
        writer.Write (strJson);
        writer.Flush ();
        writer.Close ();
    }
}
