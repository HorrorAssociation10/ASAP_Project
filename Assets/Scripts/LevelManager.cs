using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private TMP_Text ScoreText;
    [SerializeField] private List<PickupObjects> pickupObjectsList;

    private LevelProgress progress;

    private void Awake()
    {
        progress = new LevelProgress();
        pickupObjectsList = FindObjectsOfType<PickupObjects>().ToList();

        foreach (PickupObjects pickupObjects in pickupObjectsList)
        {
            pickupObjects.SetLevelManager(this);
        }
    }

    public void UpdateScore(int score)
    {
        progress.LevelScore += score;
        ScoreText.text = score.ToString();
    }
}
