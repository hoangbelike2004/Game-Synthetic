using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [SerializeField] private Button endBtn;
    public delegate void startcallback();
    public static startcallback endCallback;
    public GameObject endGame;

    private void OnEnable()
    {
        DragAndDrop.Win += ShowPanelEnd;
    }
    private void OnDisable()
    {
        DragAndDrop.Win += ShowPanelEnd;
    }
    void Start()
    {
        endBtn.onClick.AddListener(GameWin);
        
    }
    void ShowPanelEnd()
    {
        endGame.SetActive(true);
    }
    public void GameWin()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
