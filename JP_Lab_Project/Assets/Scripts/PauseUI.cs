using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] Button unpauseButton;

    void Awake()
    {
        unpauseButton.onClick.AddListener(OnUnpause);
    }
    
    void Update()
    {
        // Because the menu only shows when the game is paused, we can condense
        // 8 lines of if statements into 1 line.
        if (Time.timeScale == 0)
        {
            pauseMenu.transform.gameObject.SetActive(true);
        }
        else
        {
            pauseMenu.transform.gameObject.SetActive(false);
        }
    }

    void OnUnpause()
    {
        player.Unpause();
    }
}
