using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyQuitButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void QuitButton()
    {
        gameObject.transform.Find("QuitPanel").gameObject.SetActive(true);
    }
}
