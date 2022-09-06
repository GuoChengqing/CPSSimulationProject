using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class MyAgentAttribute : MonoBehaviour
{
    public GameObject objectUI;
    public string objectName;
    public string objectUIName;
    public string communicationProtocol;
    public List<string> connectedLines;
    public HashSet<string> hardwaresName;
    public string newName;
    // Start is called before the first frame update
    void Start()
    {
        connectedLines = new List<string>();
        hardwaresName = new HashSet<string>();
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
    public HashSet<string> GetCloudName()
    {//Erhalte ein Hashset mit den Namen der verbundenen Clouds.
        HashSet<string> connectedCloudsName = new HashSet<string>();
        foreach(string item in connectedLines)
        {
            if(GameObject.Find(item))
            {
                GameObject line = GameObject.Find(item);
                GameObject thiscloud = line.GetComponent<MyLineAttribute>().downObject;
                connectedCloudsName.Add(thiscloud.name);
            }
        }
        return connectedCloudsName;
    }
    public void GetHardwareName()
    {
        GameObject cloud;
        GameObject actSen;
        HashSet<string> cloudsName = new HashSet<string>();
        HashSet<string> actSensName = new HashSet<string>();
        HashSet<string> devicesName = new HashSet<string>();
        HashSet<string> actSenOriName = new HashSet<string>();
        TMP_Text tMPtext;
        string text = "";
        // first find clouds
        cloudsName = GetCloudName();
        foreach (string o in cloudsName)
        {
            if(cloud = GameObject.Find(o))
            {
                actSensName.UnionWith(cloud.GetComponent<MyCloudAttribute>().GetActSenName());
                actSenOriName.UnionWith(cloud.GetComponent<MyCloudAttribute>().GetActSenOriName());
                hardwaresName.UnionWith(actSensName);
                foreach(string p in actSenOriName)
                {
                    if(actSen = GameObject.Find(p))
                    {
                        devicesName.UnionWith(actSen.GetComponent<MyActSenAttribute>().GetDeviceName());
                        hardwaresName.UnionWith(devicesName);
                    }
                }
            }
        }
        foreach(string q in hardwaresName)
        {
            text += q + "\n";
        }
        hardwaresName.Clear();
        tMPtext = objectUI.transform.Find("ScrollView/Viewport/Content").GetComponent<TMP_Text>();
        tMPtext.text = text;
    }
    public void GetReName(string message)
    {
        newName = message;
    }
}
