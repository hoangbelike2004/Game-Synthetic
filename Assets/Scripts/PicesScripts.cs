using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PicesScripts : MonoBehaviour
{
    Vector3 RightPos;
    public bool inRightPos;
    public bool selected;
    [SerializeField] SortingGroup Stgr;
   
    public delegate void startcallback();
    public static startcallback Piece;
    // Start is called before the first frame update
    void Start()
    {
        RightPos = transform.position;//RightPos used to save value of piece of images

        transform.position = new Vector3(Random.Range(6.7f, 15f), Random.Range(-5f, 5f));
        //Random appearance of image pieces
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position,RightPos)< 0.5f)
        {
            if (!selected)
            {
                if (inRightPos == false)
                {
                    Piece.Invoke();
                    transform.position = RightPos;// piece of images == RightPos just now save
                    inRightPos = true;
                    Stgr.sortingOrder = 0;
                   
                }
                
            }
            
        }
    }
}
