using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyLineAttribute : MonoBehaviour
{
    public GameObject downObject;
    public GameObject upObject;
    public string downObjectProtocols;
    public string upObjectProtocols;
    private LineRenderer lineRenderer;
    public bool protocolFlag = false;
    // Start is called before the first frame update   

    void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();  
    }
    // Update is called once per frame
    void Update()
    {
        SetPosition();
        if((downObject.tag == "Cloud"  && upObject.tag == "ActSen")||(downObject.tag == "ActSen"  && upObject.tag == "Cloud"))
        {
            GetProtocol();
            ChangeColor();
        }
    }
    public void GetUpObjectName(string message)
    {
        upObject = GameObject.Find(message);
    }
    public void GetDownObjectName(string message)
    {
        downObject = GameObject.Find(message);
    }
    public void GetProtocol()
    {//Erhalte die Variable communicationProtocol in der Komponente namens "MyActSenAttribute/MyCloudAttribute" für beide Objekte
        if (downObject.tag == "Cloud"  && upObject.tag == "ActSen")
        {
            downObjectProtocols = downObject.GetComponent<MyCloudAttribute>().communicationProtocol;
            upObjectProtocols = upObject.GetComponent<MyActSenAttribute>().communicationProtocol;
        }
        else// if (downObject.tag == "ActSen"  && upObject.tag == "Cloud")
        {
            downObjectProtocols = downObject.GetComponent<MyActSenAttribute>().communicationProtocol;
            upObjectProtocols = upObject.GetComponent<MyCloudAttribute>().communicationProtocol;  
        }
    }
    private void ChangeColor(){
        if(downObjectProtocols.Length==0||upObjectProtocols.Length==0)
        {
            lineRenderer.startColor = lineRenderer.endColor = Color.gray;
            protocolFlag = false;

        }
        else if (!downObjectProtocols.Equals(upObjectProtocols))
        {
            lineRenderer.startColor = lineRenderer.endColor = Color.red;
            protocolFlag = false;

        }
        else
        {
            lineRenderer.startColor = lineRenderer.endColor = Color.green;
            protocolFlag = true;
        }
    }
    private void SetPosition()
    {
        if((downObject.tag == "Agent")&&(upObject.tag == "Cloud")||(downObject.tag == "Cloud")&&(upObject.tag == "Agent"))
        {   //Es ist das Line, das den Agent mit der Cloud verbindet.
            lineRenderer.SetPosition(0, downObject.transform.position + new Vector3(0, 0, 1));
            lineRenderer.SetPosition(1, new Vector3(0, 4, 1));
            lineRenderer.SetPosition(2, new Vector3(upObject.transform.position.x, 4, 1));
            lineRenderer.SetPosition(3, upObject.transform.position + new Vector3(0, 0, 1));
        }
        else
        {
            lineRenderer.SetPosition(0,downObject.transform.position + new Vector3(0, 0, 1));
            lineRenderer.SetPosition(1,upObject.transform.position + new Vector3(0, 0, 1));
        }
    }
}
