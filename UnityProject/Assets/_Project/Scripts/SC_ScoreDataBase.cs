using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/DataBase/PlayerScoreDataBa" , fileName = "playerScoreDataBase")]
public class SC_ScoreDataBase : ScriptableObject
{
    public List<PlayerScore> playerScore; 

    [System.Serializable]
    public class PlayerScore
    {
        public int characterID;
        public float playerScore;

        public PlayerScore(int _characterID,float _playerScore)
        {
            characterID = _characterID;
            playerScore = _playerScore;
        }
    }
}
