using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class GameConTroller : MonoBehaviour
{
    [SerializeField] private GameObject StartGame;
    // Start is called before the first frame update
    private void OnEnable()
    {
        UIManager.st += DeActiveStart;
    }
    private void OnDisable()
    {
        UIManager.st -= DeActiveStart;
    }
    void DeActiveStart()
    {
        StartGame.SetActive(false);
    }

}
;