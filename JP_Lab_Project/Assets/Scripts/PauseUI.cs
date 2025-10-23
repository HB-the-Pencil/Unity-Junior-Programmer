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
        pauseMenu.transform.gameObject.SetActive(Time.timeScale == 0);
    }

    void OnUnpause()
    {
        player.Unpause();
    }
}
