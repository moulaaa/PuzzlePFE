using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
   public enum GameStat
    {
        Start,
        Start_pressed,
        play,
        InGameMenu,
        resume,
        choosepicture,
        win,
        replace_puzzle,
    }
    public GameStat Status;
    public GameStatus()
    {
        Status = GameStat.Start;
    }
}
