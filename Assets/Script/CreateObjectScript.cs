using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CreateObjectScript : MonoBehaviour
{
    public GameObject generateObject;
    public GameObject generateUI;
    public Transform parentUI;
    public int objectNumber = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateObject(){
        objectNumber++;
        // instantiate the object
        GameObject cloneGameObject = GameObject.Instantiate(generateObject);
        // instantiate the UI
        GameObject ObjectUI = Instantiate(generateUI);  
        ObjectUI.transform.SetParent(parentUI,false);
        cloneGameObject.name = generateObject.name + objectNumber;
        ObjectUI.name = cloneGameObject.name + "UI";
        ObjectUI.SetActive(false);
        ObjectUI.transform.Find("Name").GetComponent<TMP_Text>().text = cloneGameObject.name;
    }
}
