using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCloudAttribute : MonoBehaviour
{
    public GameObject objectUI;
    public string objectName;
    public string objectUIName;
    public string communicationProtocol;
    public List<string> connectedLines;
    public string newName;
    public List<string> test;
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
    private void GetProtocol(string message)
    {
        communicationProtocol = message;
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
    public HashSet<string> GetActSenName()
    {//find line to find actSen
        HashSet<string> connectedActSensName = new HashSet<string>();;
        foreach(string item in connectedLines)
        {
            if(GameObject.Find(item))
            {
                GameObject line = GameObject.Find(item);
                GameObject ActSen;
                if(line.GetComponent<MyLineAttribute>().downObject.tag == "ActSen")
                {
                    if(line.GetComponent<MyLineAttribute>().protocolFlag)
                    {
                        ActSen = line.GetComponent<MyLineAttribute>().downObject;
                        connectedActSensName.Add(ActSen.GetComponent<MyActSenAttribute>().newName);    
                    }
                }
            }
        }
        return connectedActSensName;
    }
    public HashSet<string> GetActSenOriName()
    {//find line to find actSen
        HashSet<string> connectedActSensOriName = new HashSet<string>();;
        foreach(string item in connectedLines)
        {
            if(GameObject.Find(item))
            {
                GameObject line = GameObject.Find(item);
                GameObject ActSen;
                if(line.GetComponent<MyLineAttribute>().downObject.tag == "ActSen")
                {
                    if(line.GetComponent<MyLineAttribute>().protocolFlag)
                    {
                        ActSen = line.GetComponent<MyLineAttribute>().downObject;
                        connectedActSensOriName.Add(ActSen.name);    
                    }
                }
            }
        }
        return connectedActSensOriName;
    }
    public void GetReName(string message)
    {
        newName = message;
    }
}
