using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDeviceAttribute : MonoBehaviour
{

    public GameObject objectUI;
    public string objectName;
    public string objectUIName;    

    public List<string> connectedLines;
    public string newName;

    // Start is called before the first frame update
    void Start()
    {
        connectedLines = new List<string>();
        GetObjectName();
        GetObjectUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GetObjectName()
    {
        objectName = gameObject.name;
        newName = objectName;

    }

    public void GetObjectUI()
    {
        objectUIName = objectName +"UI";
        GameObject root = GameObject.Find("GeneratortUI");
        objectUI = root.transform.Find(objectUIName).gameObject;
    }
    public void GetLineName(string message)
    {
        connectedLines.Add(message);
    }

    public void GetReName(string message)
    {
        newName = message;
    }
}
