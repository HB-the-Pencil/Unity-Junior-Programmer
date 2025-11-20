using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public RectTransform titlePanel;
    public ParticleSystem mouseParticles;
    public bool isGameOver;

    private float _spawnRate = 1;
    private int _score;

    private IEnumerator SpawnTarget()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(_spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        mouseParticles.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);
        if (!isGameOver && Input.GetMouseButton(0))
        {
            mouseParticles.gameObject.SetActive(true);
        }
        else
        {
            mouseParticles.gameObject.SetActive(false);
        }
    }

    public void StartGame(int difficulty)
    {
        _spawnRate /= difficulty;
        titlePanel.gameObject.SetActive(false);
        StartCoroutine(SpawnTarget());
        _score = 0;
        UpdateScore(0);
        isGameOver = false;
    }

    public void UpdateScore(int scoreChange)
    {
        _score += scoreChange;
        scoreText.text = "Score: " + _score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameOver = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
