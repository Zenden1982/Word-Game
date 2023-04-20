using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordList : MonoBehaviour
{
    private static WordList S;

    [Header("Set in Inspector")]
    public TextAsset wordListText;
    public int numToParseBeforeYield = 10000;
    public int wordLenghtMin = 3;
    public int wordLenghtMax = 7;
    [Header("Setin Dynamically")]
    public int currLine = 0;
    public int totalLines;
    public int longWordCount;
    public int wordCount;

    private string[] lines;
    private List<string> longWords;
    private List<string> words;

    private void Awake()
    {
        S= this;
    }

    private void Init()
    {
        lines = wordListText.text.Split('\n');
        totalLines = lines.Length;
        
        StartCoroutine(ParceLines());
    }

    static public void INIT()
    {
        S.Init();
    }

    public IEnumerator ParceLines()
    {
        string word;

        longWords = new List<string>();
        words = new List<string>();

        for (currLine = 0; currLine < totalLines; currLine++)
        {
            word = lines[currLine];

            if(word.Length == wordLenghtMax)
            {
                longWords.Add(word);
            }

            if (word.Length >= wordLenghtMin && word.Length <= wordLenghtMax)
            {
                words.Add(word);
            }

            if (currLine % numToParseBeforeYield == 0)
            {
                longWordCount = longWords.Count;
                wordCount = words.Count;
                yield return null;
            }
            

            
        }
        longWordCount = longWords.Count;
        wordCount = words.Count;
        gameObject.SendMessage("WordListParseComplete");
    }

    static public List<string> GET_WORDS()
    {
        return (S.words);
    }
    static public string GET_WORD(int ndx)
    {
        return (S.words[ndx]);
    }

    static public List<string> GET_LONG_WORDS()
    {
        return (S.longWords);
    }

    static public string GET_LONG_WORD(int ndx)
    {
        return S.longWords[ndx];
    }
    static public int WORD_COUNT
    {
        get { return S.wordCount;}
    }

    static public int LONG_WORD_COUNT
    {
        get { return S.longWordCount;}
    }

    static public int NUM_TO_PARSE_BEFORE_YIELD
    {
        get { return S.numToParseBeforeYield; }
    }

    static public int WORD_LENGTH_MIN
    {
        get { return S.wordLenghtMin; }
    }

    static public int WORD_LENGTH_MAX
    {
        get { return S.wordLenghtMax;}
    }

}
