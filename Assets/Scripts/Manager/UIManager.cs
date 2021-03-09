using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : SingleBehaviour<UIManager>
{
    [Header("Start Game")]
    public GameObject startScreen;
    [Header("Playing Game")]
    public GameObject playingScreen;
    public List<Image> checkpointsImages;
    public List<Text> levelnameTexts;
    [Header("Game Over")]
    public GameObject gameoverScreen;
    [Header("Game Complated")]
    public GameObject gameComplatedScreen;

    public void StartToPlayingGame()
    {

        startScreen.SetActive(false);
        playingScreen.SetActive(true);
    }
    public void PlayingGameToGameOverScreen()
    {
        playingScreen.SetActive(false);
        gameoverScreen.SetActive(true);
    }
    public void PlayingGameToComplatedScreen()
    {
        playingScreen.SetActive(false);
        gameComplatedScreen.SetActive(true);
    }

    public void RestartGameUI()
    {
        gameoverScreen.SetActive(false);
        gameComplatedScreen.SetActive(false);
        playingScreen.SetActive(false);
        startScreen.SetActive(true);
        UpdateCheckPointImages();

    }
    public void UpdateLevelNameLabels()
    {
        levelnameTexts[0].text = GameManager.instance.runTime.currentLevel.ToString();
        levelnameTexts[1].text = (GameManager.instance.runTime.currentLevel+1).ToString();
    }
   

    public void UpdateCheckPointImages()
    {
        checkpointsImages.ForEach(x => x.color = Color.white);
        for (int i = 0; i <LevelObject.currentLevel.checkPoint; i++)
        {
            checkpointsImages[i].color = Color.red;
        }
    }

}
