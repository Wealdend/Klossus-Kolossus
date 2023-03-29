using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score;
    public int linesCleared;
    public int level;
    public int comboMultiplier;
    public float softDropPoints = 1f;
    public float hardDropPoints = 2f;

    private float comboTimeLimit = 10f;
    private float lastLineClearTime;

    private void Start()
    {
        score = 0;
        linesCleared = 0;
        level = 1;
        comboMultiplier = 1;
        lastLineClearTime = Time.time;
    }

    public void LineClear(int lines)
    {
        switch (lines)
        {
            case 1:
                score += 100 * comboMultiplier;
                break;
            case 2:
                score += 300 * comboMultiplier;
                break;
            case 3:
                score += 500 * comboMultiplier;
                break;
            case 4:
                score += 800 * comboMultiplier;
                break;
        }

        linesCleared += lines;
        lastLineClearTime = Time.time;

        if (Time.time - lastLineClearTime < comboTimeLimit)
        {
            comboMultiplier++;
        }
        else
        {
            comboMultiplier = 1;
        }

        if (linesCleared >= level * 10)
        {
            level++;
        }
    }

    public void SoftDrop(int rows)
    {
        score += Mathf.RoundToInt(rows * softDropPoints);
    }

    public void HardDrop(int rows)
    {
        score += Mathf.RoundToInt(rows * hardDropPoints);
    }
}
