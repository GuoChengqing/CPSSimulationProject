using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MyActSenAttribute : MonoBehaviour
{
    public GameObject objectUI;
    public string objectName;
    public string objectUIName;
    public string communicationProtocol;
    public string newName;
    public List<string> connectedLines;
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
    public HashSet<string> GetDeviceName()
    {//find line to find Device
        HashSet<string> connectedDevices = new HashSet<string>();
        foreach(string item in connectedLines)
        {
            if(GameObject.Find(item))
            {
                GameObject line = GameObject.Find(item);
                GameObject device;
                if(line.GetComponent<MyLineAttribute>().upObject.tag == "ActSen")
                {
                    device = line.GetComponent<MyLineAttribute>().downObject;
                    connectedDevices.Add(device.GetComponent<MyDeviceAttribute>().newName);
                }
            }
        }
        return connectedDevices;
    }
    public void GetReName(string message)
    {
        newName = message;
    }
}
