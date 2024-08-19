using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeDisplay; // Przypisz w inspektorze
    private float elapsedTime = 0f;
    private bool isGameActive = true;

    void Update()
    {
        if (isGameActive)
        {
            elapsedTime += Time.deltaTime; // Zwiêksza czas o czas klatki
            DisplayTime(elapsedTime);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeDisplay.text = string.Format("Time Survived: {0:00}:{1:00}", minutes, seconds); // Formatowanie tekstu na MM:SS
    }

    public void StopTimer()
    {
        isGameActive = false; // Metoda do zatrzymania licznika, np. po œmierci gracza
    }
}
