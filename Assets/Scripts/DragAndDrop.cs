using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DragAndDrop : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject SelectPices;
    int oid = 1;
    Camera m_camera;
    int piecesvalue = 0;
    [SerializeField] private PicesScripts m_Scripts;
    public delegate void Wincallback();
    public static Wincallback Win;
    void Start()
    {
        m_camera = Camera.main;
    }
    private void OnEnable()
    {
        PicesScripts.Piece += SetValue;
    }
    private void OnDisable()
    {
        PicesScripts.Piece -= SetValue;
    }
    void SetValue()
    {
        piecesvalue++;
    }
    // Update is called once per frame
    void Update()
    {
        if(piecesvalue == 36)
        {
            Win.Invoke();
        }
        
        if(Input.GetMouseButtonDown(0)) {
            RaycastHit2D hit = Physics2D.Raycast(m_camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.transform.CompareTag("Puzzle"))
            {
                if (!hit.transform.GetComponent<PicesScripts>().inRightPos)//when it's not right then perform content inside 
                {
                    Debug.Log(hit.transform.GetComponent<PicesScripts>().inRightPos);//false
                    SelectPices = hit.transform.gameObject;//assign GameOject SelectPices to GameOject be raycast protected on
                    SelectPices.GetComponent<PicesScripts>().selected = true;
                    SelectPices.GetComponent<SortingGroup>().sortingOrder = oid;
                    oid++;//when select piece of images behind other piece of images,piece of images selected will rise first piece of images not selected
                }
            }
        }
        if(SelectPices != null)
        {
            Vector3 mous = m_camera.ScreenToWorldPoint(Input.mousePosition);
            SelectPices.transform.position = new Vector3(mous.x,mous.y,0);
        }
        if (Input.GetMouseButtonUp(0))
        {
            if(SelectPices != null)
            {
                SelectPices.GetComponent<PicesScripts>().selected = false;
                SelectPices = null;
            }
            
        }

    }
}
