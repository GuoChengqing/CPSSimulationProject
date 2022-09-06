using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MySetActive : MonoBehaviour
{
    private GameObject warning;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetActive(){
        if(gameObject.transform.Find("Name").GetComponent<TMP_Text>().text.Equals(""))
        {
            warning = gameObject.transform.Find("Warning").gameObject;
            warning.SetActive(true);
            Invoke("Timer",1);
            return;
        }
        gameObject.SetActive(false);
    }
    
    private void Timer()
    {
        warning.SetActive(false);
    }
}
