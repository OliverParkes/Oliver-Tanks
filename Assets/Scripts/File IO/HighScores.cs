using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class HighScores : MonoBehaviour
{
    public int[] scores = new int[10];
    string CurrentDirectory;
    public string scoreFileName = "highScores.txt";
    private void Start()
    {
        CurrentDirectory = Application.dataPath;
        Debug.Log("Our current directory is " + CurrentDirectory);

        loadScoresFromFile();
    }

    public void loadScoresFromFile()
    {
        bool fileExists = File.Exists(CurrentDirectory + "\\" + scoreFileName);
        if (fileExists == true)
        {
            Debug.Log("Found high score" + scoreFileName);
        }
        else
        {
            Debug.Log("The file " + scoreFileName + "does not exist. No scores will be loaded", this);
            return;
        }

        scores = new int[scores.Length];
        StreamReader fileReader = new StreamReader(CurrentDirectory + "\\" + scoreFileName);
        int scoreCount = 0;

        while (fileReader.Peek() != 0 && scoreCount < scores.Length)
        {
            string fileLine = fileReader.ReadLine();
            int readScore = -1;

            bool didParse = int.TryParse(fileLine, out readScore);
            if (didParse)
            {
                scores[scoreCount] = 0;
            }

            scoreCount++;
        }

        fileReader.Close();
        Debug.Log("High scores read from " + scoreFileName);

    }

    public void SaveScoresToFile()
    {
        StreamWriter fileWriter = new StreamWriter(CurrentDirectory + "\\" + scoreFileName);

        for (int i = 0; i < scores.Length; i++)
        {
            fileWriter.WriteLine(scores[i]);
        }

        fileWriter.Close();

        Debug.Log("High scores written to " + scoreFileName);

    }

    public void AddScore (int newScore)
    {
        int desiredindex = -1;
        for (int i = 0; i < scores.Length; i++)
        {
            if (scores [i] > newScore || scores[i] == 0)
            {
                desiredindex = i;
                break;
            }
        }

        if (desiredindex < 0)
        {
            Debug.Log("score of " + newScore + "not high enough for high scores list", this);
            return;
        }

        for (int i = scores.Length - 1; i > desiredindex; i--)
        {
            scores[i] = scores[i - 1];
        }

        scores[desiredindex] = newScore;
        Debug.Log("score of " + newScore + "added to high scores list at position " + desiredindex);
    }
}
