using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawMyLine : MonoBehaviour
{
    public GameObject downObject;
    public GameObject upObject;
    public bool upflag = false;
    public bool downflag = false;
    public GameObject generateObject;
    //LineRenderer
    private LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        //Wenn die Namen von zwei Objekten akzeptiert werden
        if(downflag&&upflag)
        {
            monitor();
            upflag = false;
            downflag = false;
        }
    }
    public void GetUpObjectName(string message)
    {
        upObject = GameObject.Find(message);
        upflag = true;
    }
    public void GetDownObjectName(string message)
    {
        downObject = GameObject.Find(message);
        downflag = true;
    }
    private void monitor(){
        if(upObject&&downObject&&!upObject.Equals(downObject)){
            //Auswählen von Funktionen nach Tag
            if((upObject.tag == "ActSen")&&(downObject.tag == "Cloud")||(upObject.tag == "Cloud")&&(downObject.tag == "ActSen"))
            {
                DrawActCloudLine(downObject,upObject);
            }
            else if ((upObject.tag == "ActSen")&&(downObject.tag == "Device")||(upObject.tag == "Device")&&(downObject.tag == "ActSen")
                    ||(upObject.tag == "Device")&&(downObject.tag == "Device"))
            {
                DrawActDeviceLine(downObject,upObject);
            }
            else if ((upObject.tag == "Agent")&&(downObject.tag == "Cloud")||(upObject.tag == "Cloud")&&(downObject.tag == "Agent"))
            {
                DrawCloudAgentLine(downObject,upObject);
            }
        }
    }

    private void DrawActCloudLine(GameObject startP, GameObject finalP)
    {
        string downObjectProtocols;
        string upObjectProtocols;
        //Es kann nur eine Linie zwischen zwei Objekten geben.
        if(GameObject.Find(downObject.name + upObject.name)||GameObject.Find(upObject.name + downObject.name)) return;
        //instanziieren
        GameObject myLine = GameObject.Instantiate(generateObject);
        //UpObject als Cloud fixiert 
        if(downObject.tag == "Cloud"  && upObject.tag == "ActSen")
        {
            GameObject objectTemp = downObject;
            downObject = upObject;
            upObject = objectTemp;
        }
        string myLineName = downObject.name + upObject.name;
        myLine.name = myLineName;
        //GetProtocol
        downObjectProtocols = downObject.GetComponent<MyActSenAttribute>().communicationProtocol;
        upObjectProtocols = upObject.GetComponent<MyCloudAttribute>().communicationProtocol;
        //CreateLine,Setze die grundlegenden Eigenschaften der Linie
        LineRenderer lineRenderer = myLine.GetComponent<LineRenderer>();
        lineRenderer.startWidth = lineRenderer.endWidth = 0.05f;
        lineRenderer.SetPosition(0,downObject.transform.position + new Vector3(0, 0, 1));
        lineRenderer.SetPosition(1,upObject.transform.position + new Vector3(0, 0, 1));
        //Bestimme, ob zwei Kommunikationsprotokolle gleich sind
        if(downObjectProtocols.Length==0||upObjectProtocols.Length==0)
        { 
            lineRenderer.startColor = lineRenderer.endColor = Color.gray;
        }
        else if (!downObjectProtocols.Equals(upObjectProtocols))
        {
            lineRenderer.startColor = lineRenderer.endColor = Color.red;
        }
        else
        {
            lineRenderer.startColor = lineRenderer.endColor = Color.green;
        }
        //send Nachricht an Linie und zwei verbundene Objekte attribute
        if(GameObject.Find(myLineName)){
            myLine.SendMessage("GetDownObjectName", downObject.name);
            myLine.SendMessage("GetUpObjectName", upObject.name);
            upObject.SendMessage("GetLineName", myLineName);
            downObject.SendMessage("GetLineName", myLineName);
        }    
    }


    private void DrawActDeviceLine(GameObject startP, GameObject finalP)
    {
        if(GameObject.Find(downObject.name + upObject.name)||GameObject.Find(upObject.name + downObject.name)) return;
        GameObject myLine = GameObject.Instantiate(generateObject);
        //DownObject als Gerät fixiert 
        if(downObject.tag == "ActSen")
        {
            GameObject objectTemp = downObject;
            downObject = upObject;
            upObject = objectTemp;
        }
        string myLineName = downObject.name + upObject.name;
        myLine.name = myLineName;
        LineRenderer lineRenderer = myLine.GetComponent<LineRenderer>();
        lineRenderer.startWidth = lineRenderer.endWidth = 0.05f;
        lineRenderer.SetPosition(0,downObject.transform.position + new Vector3(0, 0, 1));
        lineRenderer.SetPosition(1,upObject.transform.position + new Vector3(0, 0, 1));
        lineRenderer.startColor = lineRenderer.endColor = Color.black;
        if(GameObject.Find(myLineName)){
            myLine.SendMessage("GetDownObjectName", downObject.name);
            myLine.SendMessage("GetUpObjectName", upObject.name);
            upObject.SendMessage("GetLineName", myLineName);
            downObject.SendMessage("GetLineName", myLineName);
        }    
    }

    private void DrawCloudAgentLine(GameObject startP, GameObject finalP)
    {
        if(GameObject.Find(downObject.name + upObject.name)||GameObject.Find(upObject.name + downObject.name)) return;
        GameObject myLine = GameObject.Instantiate(generateObject);
        //UpObject als Agent fixiert 
        if(upObject.tag == "Cloud"&& downObject.tag == "Agent")
        {
            GameObject objectTemp = downObject;
            downObject = upObject;
            upObject = objectTemp;
        }
        string myLineName = downObject.name + upObject.name;
        myLine.name = myLineName;
        LineRenderer lineRenderer = myLine.GetComponent<LineRenderer>();
        lineRenderer.startWidth = lineRenderer.endWidth = 0.05f;
        //Die Setup Line besteht aus 4 Knotenverbindungen
        lineRenderer.positionCount = 4;
        lineRenderer.SetPosition(0, downObject.transform.position + new Vector3(0, 0, 1));
        lineRenderer.SetPosition(1, new Vector3(0, 4, 1));
        lineRenderer.SetPosition(2, new Vector3(upObject.transform.position.x, 4, 1));
        lineRenderer.SetPosition(3, upObject.transform.position + new Vector3(0, 0, 1));
        lineRenderer.startColor = lineRenderer.endColor = Color.yellow;
        if(GameObject.Find(myLineName)){
            myLine.SendMessage("GetDownObjectName", downObject.name);
            myLine.SendMessage("GetUpObjectName", upObject.name);
            upObject.SendMessage("GetLineName", myLineName);
            downObject.SendMessage("GetLineName", myLineName);
        }    
    }
}
