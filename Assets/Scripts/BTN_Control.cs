using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BTN_Control : MonoBehaviour
{
    public GameObject itemsGo;
    public GameObject listGo;
    public ScrollRect rollBar;

    private void Start()
    {
        for(int i = 0;i < 10; i++)
        {
            GameObject item = (GameObject)Instantiate( itemsGo,listGo.transform);
            item.transform.localScale = new Vector3(1, 1, 1);
        }
        rollBar.verticalNormalizedPosition = 1;
    }
    private void Update()
    {
        
    }
    public void Click_Start()
    {

    }
    public void Click_About()
    {

    }
    public void Click_Quit()
    {

    }
}
