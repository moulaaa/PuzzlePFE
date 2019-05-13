using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordGuessingGameManager : MonoBehaviour
{

    public GameObject missingLetterContainer,letterContainer;
    public GameManager man;
    public Transform missingLetterContainerLocation,letterContainerLocation;
    public string selectedWord = "" ;

    char[] arabic_alpha = {'ا', 'ب', 'ت', 'ث', 'ج', 'ح', 'خ', 'د', 'ذ', 'ر', 'ز', 'ص', 'ض', 'ط', 'ظ', 'ع', 'غ', 'ف', 'ق', 'ک', 'ل', 'م', 'ن', 'و', 'ه', 'ي'};
    string[] missingLettersCharacter;

    List<LetterContainer> missingLetterTexts = new List<LetterContainer>();
    int letterIndexToBeChanged = 0;

    const int lettersContainerLength = 12;

    void Start()
    {
        missingLettersCharacter = new string[selectedWord.Length];
        GenerateLetters();
        GenerateMissingLetters();
    }

    void Update()
    {
        
    }


    void GenerateLetters() {
        
        int randomIndex;
        LetterContainer tempLetter;
        List<int> randomWordIndexes = new List<int>();

        for (int i = 0; i < selectedWord.Length; i++){
        randomWordIndexes.Add(0);
        
        do
        {
            randomIndex = Random.Range(0, lettersContainerLength);
        } while (randomWordIndexes.Contains(randomIndex));

        randomWordIndexes[i] = randomIndex;
        }
        

        int count = 0 ;
        string myTempLetterText;
        for (int i = 0; i < lettersContainerLength; i++)
        {
            GameObject tempLetterGameObject = Instantiate
                (letterContainer, Vector2.zero, Quaternion.identity, letterContainerLocation);

            tempLetter = tempLetterGameObject.GetComponent<LetterContainer>();
            
            if (randomWordIndexes.Contains(i))
            {
                tempLetter.myText.text = selectedWord[count].ToString();
                myTempLetterText = selectedWord[count].ToString();
                count++;
            }
            else
            {
                myTempLetterText = arabic_alpha[Random.Range(0, arabic_alpha.Length)].ToString();
                tempLetter.myText.text = myTempLetterText;
            }

            string iDontKnowWhyAmDoingThisButItDosntWorkWithoutThisDeclaration = myTempLetterText;

            tempLetter.GetComponent<Button>().onClick.AddListener(delegate
            {
                putLetter(iDontKnowWhyAmDoingThisButItDosntWorkWithoutThisDeclaration);
            });
        }


    }

    void GenerateMissingLetters()
    {
        for (int i = 0; i < selectedWord.Length; i++)
        {
            missingLetterTexts.Add(null);
        }

        for (int i = selectedWord.Length -1 ; i >= 0; i--)
        {
            int newI = i;
            GameObject tempMissingLetter =
                Instantiate(missingLetterContainer, Vector2.zero, Quaternion.identity, missingLetterContainerLocation);
            tempMissingLetter.GetComponent<Button>().onClick.AddListener(delegate {
                ChangeLetter(tempMissingLetter.GetComponent<LetterContainer>().myText, newI);
            });
            missingLetterTexts[i] = (tempMissingLetter.GetComponent<LetterContainer>());
        }
    }

    void ChangeLetter(Text myText,int letterIndex)
    {
        if (missingLettersCharacter[letterIndex] == "") return;
        missingLettersCharacter[letterIndex] = "";
        myText.text = "";
    }

    void putLetter(string letter)
    {
        for (int i = 0; i < selectedWord.Length; i++)
        {
            if ((missingLettersCharacter[i] == "") 
                || missingLettersCharacter[i] == null)
            {
                Debug.Log("GTA");
                letterIndexToBeChanged = i;
                break;
            }
        }
        missingLettersCharacter[letterIndexToBeChanged] = letter;
        missingLetterTexts[letterIndexToBeChanged].myText.text = letter;
        CheckWordCorrespendance();
    }

    void CheckWordCorrespendance()
    {
        string myWord = "";
        for (int i = 0; i < selectedWord.Length; i++)
        {
            myWord += missingLettersCharacter[i];
        }

        if (myWord == selectedWord) {
            this.gameObject.SetActive(false);
            man.Win();
        }

    }

}
