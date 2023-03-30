using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject mainPlayer;
    private MoveDirection playerMoveDirection;
    private Movement mainPlayerMovement;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject levelCompleteMenu;
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] GameObject startGameMenu;
    
    
    private void Start()
    {
        playerMoveDirection = mainPlayer.GetComponent<MoveDirection>();
        mainPlayerMovement = mainPlayer.GetComponent<Movement>();
    }
   
    public void StartGame()  
    {       
        playerMoveDirection.StartMoveDirection();
        CloseAllMenus();
        startGameMenu.SetActive(false);
        
           
    }
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Win()
    {
        CloseAllMenus();
        playerMoveDirection.StopMoveDirection();
        mainPlayerMovement.StopMovement();
        levelCompleteMenu.SetActive(true);
    }
    public void Lose()
    {
        CloseAllMenus();
        playerMoveDirection.StopMoveDirection();
        mainPlayerMovement.StopMovement();
        gameOverMenu.SetActive(true);
    }
    void CloseAllMenus()
    {
        foreach (Transform child in mainMenu.transform)
        {
            child.gameObject.SetActive(false);
        }
    }
}
