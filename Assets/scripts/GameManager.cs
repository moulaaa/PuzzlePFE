using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public puzzle puzzleprefab;
    public GameObject InGameMenu;
    public GameObject StartButton;
    public GameObject WinGameMenu;
    public GameObject SwapButton;
    public Buttons GiveUpButton;
    public bool DeveloperMode;
    private List<puzzle> puzzlelist = new List<puzzle>();
    private List<int> randomNumbers = new List<int>();
    private List<Vector3> puzzlePositions = new List<Vector3>();
    public Transform puzzlePos;

    private Vector2 startPosition = new Vector2(-3.55f, 1.77f);
    //Vector2 myVect = transform.localScale;
    private Vector2 offset = new Vector2(2.03f, 1.52f);

    public static string foldername;
    public GameObject fullpicture;

    [HideInInspector]
    public static GameStatus game_Status = new GameStatus();
    [HideInInspector]
    public enum RemplaceElement
    {
        first,
        second,
        finished
    }
    public static Vector3 pos1, pos2;
    public static string element1_name, element2_name;
    public static RemplaceElement replace_element;
    bool isGenerated = false;
    void Start()
    {
        SwapButton.SetActive(true);
        replace_element = RemplaceElement.first;
        element1_name = null;
        element2_name = null;
        Setstarposition();
        ApllyMatriel();


    }

    // Update is called once per frame
    void Update()
    {
        switch (game_Status.Status)
        {
            case GameStatus.GameStat.Start_pressed:
                if (isGenerated) return;
                isGenerated = true;
                Spawnpuzzle(14);
                Setstarposition();
                ApllyMatriel();
                MixPuzzles();
                game_Status.Status = GameStatus.GameStat.play;
                if (StartButton)
                    StartButton.SetActive(false);
                break;
            case GameStatus.GameStat.play:
                {
                    Debug.Log("play case");
                    if (HasWeWon() == true)
                    {
                        game_Status.Status = GameStatus.GameStat.win;
                        // InGameMenu.SetActive(false);

                        //game_Status.Status = GameStatus.GameStat.play;
                    }
                    {
                        Spawnpuzzle(14);
                        Setstarposition();
                        ApllyMatriel();
                        MixPuzzles();
                    }

                    if (GiveUpButton.clicked)
                    {
                        Debug.Log("GTA");
                        for (int i = 0; i < puzzlelist.Count; i++)
                        {
                            puzzlelist[i].transform.position = puzzlePositions[i];
                        }
                    }
                }
                break;
            case GameStatus.GameStat.InGameMenu:
                {
                    InGameMenu.SetActive(true);
                    // StartButton.SetActive(false);
                }
                break;
            case GameStatus.GameStat.resume:
                {
                    InGameMenu.SetActive
                        (false);
                    game_Status.Status = GameStatus.GameStat.play;
                }
                break;
            case GameStatus.GameStat.win:
                {
                    if (DeveloperMode)
                        SetPuzzleOneTheStartPosition(false);
                    else
                        SetPuzzleOneTheStartPosition(GiveUpButton.clicked);
                }
                break;
            case GameStatus.GameStat.replace_puzzle:
                {
                    Debug.Log("Element1" + element1_name);
                    Debug.Log("Element1" + element2_name);
                    Debug.Log("Element1 pos" + element1_name);
                    Debug.Log("Element2 pos" + element2_name);
                    if (element1_name != null && element2_name != null)
                    {
                        StartCoroutine(SwapPuzzle(1.0f));
                        SwapButton.SetActive(false);
                    }
                }
                break;

        }
    }
        IEnumerator SwapPuzzle(float delay)
        {
            yield return StartCoroutine(Wait(delay));
            foreach (puzzle p in puzzlelist)
            {
                if (p.GetComponent<Renderer>().name == element2_name)
                {
                    StartCoroutine(MoveSwapPuzzle(pos2 ,p));
                p.GetComponent<Renderer>().material.color = Color.white;

            
                }
            if (p.GetComponent<Renderer>().name == element1_name)
            {
                StartCoroutine(MoveSwapPuzzle(pos1, p));
                p.GetComponent<Renderer>().material.color = Color.white;


            }
        }
        game_Status.Status = GameStatus.GameStat.play;
            //MovePuzzle();
        }
    IEnumerator Wait(float duration)
    {
        for (float timer = 0; timer < duration; timer += Time.deltaTime)
        {
            yield return 0;
        }
    }
    IEnumerator MoveSwapPuzzle(Vector3 traget, puzzle p)
    {
        float accuracy = 0.00001f;
        while (Vector3.Distance(p.transform.position, traget) > accuracy)
        {
            p.transform.position = Vector3.MoveTowards(p.transform.position, traget, 6.0f + Time.deltaTime);
            yield return 0;
        }
    }
    private void Spawnpuzzle(int number)
        {
            for (int i = 0; i <= number; i++)
            { puzzlelist.Add(Instantiate(puzzleprefab, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity, puzzlePos) as puzzle); }
        }
        
        void Setstarposition()
        {   //first line 
            puzzlelist[0].transform.position = new Vector3(startPosition.x, startPosition.y, 0.0f);
            puzzlelist[1].transform.position = new Vector3(startPosition.x + offset.x, startPosition.y, 0.0f);
            puzzlelist[2].transform.position = new Vector3(startPosition.x + (2 * offset.x), startPosition.y, 0.0f);
            //second line
            puzzlelist[3].transform.position = new Vector3(startPosition.x, startPosition.y - offset.y, 0.0f);
            puzzlelist[4].transform.position = new Vector3(startPosition.x + offset.x, startPosition.y - offset.y, 0.0f);
            puzzlelist[5].transform.position = new Vector3(startPosition.x + (2 * offset.x), startPosition.y - offset.y, 0.0f);
            puzzlelist[6].transform.position = new Vector3(startPosition.x + (3 * offset.x), startPosition.y - offset.y, 0.0f);
            //third line 
            puzzlelist[7].transform.position = new Vector3(startPosition.x, startPosition.y - (2 * offset.y), 0.0f);
            puzzlelist[8].transform.position = new Vector3(startPosition.x + offset.x, startPosition.y - (2 * offset.y), 0.0f);
            puzzlelist[9].transform.position = new Vector3(startPosition.x + (2 * offset.x), startPosition.y - (2 * offset.y), 0.0f);
            puzzlelist[10].transform.position = new Vector3(startPosition.x + (3 * offset.x), startPosition.y - (2 * offset.y), 0.0f);
            //fourd line 
            puzzlelist[11].transform.position = new Vector3(startPosition.x, startPosition.y - (3 * offset.y), 0.0f);
            puzzlelist[12].transform.position = new Vector3(startPosition.x + offset.x, startPosition.y - (3 * offset.y), 0.0f);
            puzzlelist[13].transform.position = new Vector3(startPosition.x + (2 * offset.x), startPosition.y - (3 * offset.y), 0.0f);
            puzzlelist[14].transform.position = new Vector3(startPosition.x + (3 * offset.x), startPosition.y - (3 * offset.y), 0.0f);
        }
        private void ApllyMatriel()
        {
            string filepath;
            for (int i = 1; i <= puzzlelist.Count; i++)
            { if (i < 3)
                    filepath = "puzzles/" + foldername + "/cube" + (i + 1);
                else
                    filepath = "puzzles/" + foldername + "/cube" + i;
                Texture2D mat = Resources.Load(filepath, typeof(Texture2D)) as Texture2D;
                puzzlelist[i - 1].GetComponent<Renderer>().material.mainTexture = mat;
            }
            filepath = "puzzles/" + foldername + "/pic";
            Texture2D mat1 = Resources.Load(filepath, typeof(Texture2D)) as Texture2D;
            fullpicture.GetComponent<Renderer>().material.mainTexture = mat1;
        }
        void MixPuzzles()
        {
            int number;

            foreach (puzzle p in puzzlelist)
            {
                puzzlePositions.Add(p.transform.position);
            }
            foreach (puzzle p in puzzlelist)
            {
                number = Random.Range(0, puzzlelist.Count);
                while (randomNumbers.Contains(number))
                {
                    number = Random.Range(0, puzzlelist.Count);
                }

                randomNumbers.Add(number);
                p.transform.position = puzzlePositions[number];
            }
        }
        bool HasWeWon()
        {
            foreach (puzzle p in puzzlelist)
                if (p.transform.position != p.winPosition)
                {
                    return false;
                }
            return true;
        }

        void SetPuzzleOneTheStartPosition(bool giveup)
        {
            StartCoroutine(MoveToPosition(0.2f, giveup));
            GiveUpButton.clicked = false;
            game_Status.Status = GameStatus.GameStat.Start;
        }
        IEnumerator MoveToPosition(float delayTime, bool giveup)
        {
            for (int i = 0; i < puzzlelist.Count; i++)
            {
                for (float timer = 0; timer < delayTime; timer += delayTime)
                {
                    puzzlelist[i].transform.localScale = new Vector3(puzzlelist[i].Scale_backup.x + puzzlelist[i].scale_x, puzzlelist[i].Scale_backup.y + puzzlelist[i].scale_y, puzzlelist[i].transform.localScale.z);
                    yield return 0;
                }
            }
            // WinGameMenu.SetActive(true);
            if (!giveup)
            {

            }
        }
    
}

    
















