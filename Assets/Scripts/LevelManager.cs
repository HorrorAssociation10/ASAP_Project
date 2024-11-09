using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private TMP_Text ScoreText;
    [SerializeField] private List<PickupObjects> pickupObjectsList;
    [SerializeField] private List<Enemy> enemiesList;
    [SerializeField] private LevelHUD levelHUD;
    [SerializeField] private Spikes spikes;

    private LevelProgress progress;

    private void Awake()
    {
        progress = new LevelProgress();
        pickupObjectsList = FindObjectsOfType<PickupObjects>().ToList();
        enemiesList = FindObjectsOfType<Enemy>().ToList();
        ScoreText.text = $"Health: {progress.LevelScore}";

        foreach (PickupObjects pickupObject in pickupObjectsList)
        {
            pickupObject.SetLevelManager(this);
        }
        foreach (Enemy enemy in enemiesList)
        {
            enemy.SetLevelManager(this);
        }
        spikes.SetLevelManager(this);
    }

    public void UpdateScore(int score)
    {
        progress.LevelScore += score;
        if (progress.LevelScore>8) progress.LevelScore = 8;
        levelHUD.UpdateScore(progress.LevelScore);
        if (progress.LevelScore <= 0)
            levelHUD.GameOver();
    }
}
