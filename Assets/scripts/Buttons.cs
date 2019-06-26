using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public string sceneName;
    public float finalXPosition;
    private Vector3 finalPosition;
    private float movespeed = 7.0f;
    public enum ButtonType { MainMenuButton, InGameButton , InGameButtonLoadScene , GiveUp , SwapPuzzle };
    public ButtonType type;
    public bool clicked; 
    public bool EnableSlidingEffect = true;
    private Vector3 StartPosition;
    // Start is called before the first frame update
    void Start()
    {

        finalPosition = new Vector3(finalXPosition, transform.position.y, transform.position.z);
        StartPosition = gameObject.transform.position;
        clicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == finalPosition)
        {
            if ((type == ButtonType.MainMenuButton) || (type == ButtonType.InGameButtonLoadScene))
            {
                GameManager.game_Status.Status = GameStatus.GameStat.Start;
                SceneManager.LoadScene(sceneName);
                
            }
        }

    }
    private void OnMouseDown()
    {   if (GameManager.game_Status.Status == GameStatus.GameStat.play && gameObject.tag == "GamePlayTag")
            return;
        if (EnableSlidingEffect)
        {
            finalPosition = new Vector3(finalXPosition, transform.position.y, transform.position.z);
            StartCoroutine(MoveToPosition(finalPosition));
        }
        else
        {
            SceneManager.LoadScene(sceneName);

        }
        /*if (type==ButtonType.InGameButtonLoadScene)
        {
            GameManager.game_Status.Status = GameStatus.GameStat.Start;
        }*/
        if (type == ButtonType.GiveUp)
        {
            Debug.Log("gaha");
            clicked = true;

        }

        if (type == ButtonType.SwapPuzzle){
            Debug.Log("GTA SANANDREAS");

                GameManager.game_Status.Status = GameStatus.GameStat.replace_puzzle;
        }


    }
    IEnumerator MoveToPosition(Vector3 tragetPosition)
    {
        while (transform.position != tragetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, tragetPosition, movespeed * Time.deltaTime);
            yield return 0;
        }
        if (gameObject.name == "exit")
        { Application.Quit(); }
        if (gameObject.name == "Start")
        {
            GameManager.game_Status.Status = GameStatus.GameStat.Start_pressed;
            MainMenuHandler.canPlay = true;
            Destroy(this.transform.parent.gameObject);
            
        }
        if (gameObject.name == "Menu")
        {
            if (transform.position != StartPosition)
            {
                StartCoroutine(MoveToPosition(StartPosition));
            }
            GameManager.game_Status.Status = GameStatus.GameStat.InGameMenu;
        }
        if (gameObject.name == "Resume")

        {
            transform.position = StartPosition;
            GameManager.game_Status.Status = GameStatus.GameStat.resume;
            GameManager.canStartTimer = true;
        }
        if (gameObject.name == "Choosepicture")

        {
            transform.position = StartPosition;
            GameManager.game_Status.Status = GameStatus.GameStat.choosepicture;
        }
        
    }
}



