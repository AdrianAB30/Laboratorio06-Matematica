using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Mathematics.Week6;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text lifeText;
    [SerializeField] private Shake cameraShake;
    [SerializeField] private Animator gameOverAnimator;
    [SerializeField] private Animator optionsAnimator;
    [SerializeField] private Slider sliderMaster;
    [SerializeField] private Slider sliderMusic;
    [SerializeField] private Slider sliderSfx;

    [Header("Data")]
    private int score;
    private int life = 3;
    private float timeToIncreaseScore = 1f;
    private float scoreTimer;
    public bool isGameActive = true;

    [Header("References")]
    [SerializeField] private ConstantRotation3D planetRotation;
    [SerializeField] private PlaneController plane;
    [SerializeField] private Rotate_Sybox skybox;
    [SerializeField] private Spawner_Trash spawnTrash;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private SfxManager sfxManager;

    // Eventos
    public event Action<int> OnScoreUpdate;
    public event Action OnLifeLost;
    public event Action OnGameOver;

    private void OnEnable()
    {
        OnLifeLost += HandleLifeLost;
        OnGameOver += HandleGameOver;
        OnScoreUpdate += UpdateScore;
    }
    private void Start()
    {
        UpdateLife(life);
        UpdateScore();
        UpdateAudio();
    }
    private void Update()
    {
        if (isGameActive)
        {
            UpdateScore();
        }
    }
    private void UpdateAudio()
    {
        if (audioManager != null && sfxManager != null)
        {
            if (sliderMaster != null)
            {
                sliderMaster.value = audioManager.audioData.audioVolume;
                sliderMaster.onValueChanged.AddListener(audioManager.SetMasterVolume);
            }
            if (sliderMusic != null)
            {
                sliderMusic.value = audioManager.audioData.audioVolume;
                sliderMusic.onValueChanged.AddListener(audioManager.SetMusicVolume);
            }
            if (sliderSfx != null)
            {
                sliderSfx.value = sfxManager.sfxData.sfxVolume;
                sliderSfx.onValueChanged.AddListener(sfxManager.SetSfxVolume);
            }
        }
    }
    private void UpdateScore()
    {
        scoreTimer += Time.deltaTime;

        if (scoreTimer >= timeToIncreaseScore)
        {
            score++;
            OnScoreUpdate?.Invoke(score);
            scoreTimer = 0f;
        }
    }
    public void LoseLife()
    {
        OnLifeLost?.Invoke();
        if (plane != null && plane.life <= 0)
        {
            OnGameOver?.Invoke();
        }
    }
    private void UpdateScore(int newScore)
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + newScore;
        }
    }
    public void UpdateLife(int currentLife)
    {
        if (lifeText != null)
        {
            lifeText.text = "Vidas: " + currentLife.ToString();
        }
    }
    private void HandleLifeLost()
    {
        if (cameraShake != null)
        {
            cameraShake.ShakeCamera();
        }
        if (sfxManager != null)
        {
            sfxManager.PlaySfx(0);
        }
    }
    private void HandleGameOver()
    {
        if (gameOverAnimator != null)
        {
            gameOverAnimator.SetTrigger("Cartel");
        }
        if (sfxManager != null)
        {
            sfxManager.PlaySfx(1);
        }
        if (audioManager != null)
        {
            audioManager.StopAudio();
        }

        isGameActive = false;

        if (planetRotation != null)
        {
            planetRotation.enabled = false;
        }
        if (plane != null)
        {
            plane.gameObject.SetActive(false);
        }
        if (skybox != null)
        {
            skybox.enabled = false;
        }
        if (spawnTrash != null)
        {
            spawnTrash.enabled = false;
        }
    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void Options()
    {
        if(optionsAnimator != null)
        {
            optionsAnimator.SetBool("IsOptions",true);
        }
    }
    public void CloseOptions()
    {
        if(optionsAnimator != null)
        {
            optionsAnimator.SetBool("IsOptions", false);
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
    public void PauseGame()
    {
        isGameActive = false;
        if (plane != null)
        {
            plane.enabled = false;
            plane.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        if (spawnTrash != null)
        {
            spawnTrash.enabled = false;
        }
        if (planetRotation != null)
        {
            planetRotation.enabled = false;
        }
    }
    public void ResumeGame()
    {
        isGameActive = true;
        if (plane != null)
        {
            plane.enabled = true;
        }
        if (spawnTrash != null)
        {
            spawnTrash.enabled = true;
        }
        if (planetRotation != null)
        {
            planetRotation.enabled = true;
        }
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Saliendo");
    }
    private void OnDisable()
    {
        OnLifeLost -= HandleLifeLost;
        OnGameOver -= HandleGameOver;
        OnScoreUpdate -= UpdateScore;
    }
}
