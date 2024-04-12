using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPrefab : MonoBehaviour
{
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        prefab = Resources.Load("MyPrefab") as GameObject;
        Instantiate(prefab,Vector2.zero,Quaternion.identity);
    }

    
}
