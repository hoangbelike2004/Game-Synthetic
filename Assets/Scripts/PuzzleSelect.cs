using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleSelect : MonoBehaviour
{
    [SerializeField] private GameObject StartPanel;
    public void SetPuzzlesPhoto(Image Photo)
    {
        for (int i = 0; i <36; i++)
        {
            GameObject.Find("Pieces_"+i).transform.Find("Wibu").GetComponent<SpriteRenderer>().sprite = Photo.sprite;

        }
        
        StartPanel.SetActive(false);
    }
}
