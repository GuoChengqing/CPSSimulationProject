using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ReName : MonoBehaviour
{
    private string newName;
    private string originalName;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void SendNewName()
    {
        string UIName = gameObject.name;
        string objectName = UIName.Substring(0,UIName.Length-2);
        GameObject connectedObject = GameObject.Find(objectName);
        originalName = connectedObject.name;
        newName = gameObject.transform.Find("Name").GetComponent<TMP_Text>().text;
        if(newName.Length == 0)
        {
            newName= originalName;
        }
        //Senden Nachricht an das Objekte，dem die UI entspricht.
        connectedObject.SendMessage("GetReName",newName);
    }
}
