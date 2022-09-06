using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SendMessage : MonoBehaviour
{
    public GameObject connectedObject;
    private GameObject ProtocolText;
    public string objectName;
    public string objectUIName;
    public string communicationProtocol;
    // Start is called before the first frame update
    void Start()
    {
        GetObjectName();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void GetObjectName()
    {
        objectUIName = gameObject.transform.parent.name;
        objectName = objectUIName.Substring(0,objectUIName.Length-2);
    }
    public void SendProtocol()
    {
        communicationProtocol = gameObject.GetComponent<TMP_InputField>().text;
        connectedObject = GameObject.Find(objectName);
        connectedObject.SendMessage("GetProtocol", communicationProtocol);
    }
}
