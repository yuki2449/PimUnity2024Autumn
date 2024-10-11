using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChangeCont : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject FoxCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("MainCamera");
        FoxCamera = GameObject.Find("FoxCamera");
    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
        }
           
    }
}
