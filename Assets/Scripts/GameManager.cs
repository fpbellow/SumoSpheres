using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject titleScreen;
    public TextMeshProUGUI gameOverText;
    public Button startButton;
    public Button restartButton;
    public AudioClip deathSound;

    private AudioSource gameAudio;
    private SpawnManager spawnManager;
    public bool isGameActive = false;
    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        gameAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive)
        {
            spawnManager.WaveEndCheck();
        }
    }

    public void playAudioClip(AudioClip soundEffect, float soundVolume)
    {
        gameAudio.PlayOneShot(soundEffect, soundVolume);
    }

    public void StartGame()
    {
        titleScreen.gameObject.SetActive(false);
        isGameActive = true;
        spawnManager.WaveEndCheck();
    }

    public void GameOver()
    {
        playAudioClip(deathSound, 0.3f);
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        StartGame();
    }
}
