using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    
    [SerializeField] private Button startBtn;
    public delegate void startcallback();
    public static startcallback st;
    public GameObject startGame;

    void Start()
    {
        startBtn.onClick.AddListener(StartGame);
        startGame.SetActive(true);
    }

    public void StartGame()
    {
        
        st.Invoke();

    }

}
