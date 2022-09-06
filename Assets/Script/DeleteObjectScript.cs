using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObjectScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Delete(){
        string UIName = gameObject.name;
        string objectName = UIName.Substring(0,UIName.Length-2);
        GameObject connectedObject = GameObject.Find(objectName);
        List<string> connectedLines = new List<string>();
        if(connectedObject.tag.Equals("ActSen"))
        {
            connectedLines = connectedObject.GetComponent<MyActSenAttribute>().connectedLines;
        }
        else if(connectedObject.tag.Equals("Agent"))
        {
            connectedLines = connectedObject.GetComponent<MyAgentAttribute>().connectedLines;
        }
        else if(connectedObject.tag.Equals("Cloud"))
        {
            connectedLines = connectedObject.GetComponent<MyCloudAttribute>().connectedLines;
        }
        else if(connectedObject.tag.Equals("Device"))
        {
            connectedLines = connectedObject.GetComponent<MyDeviceAttribute>().connectedLines;
        }

        //Destroy
        if(gameObject&connectedObject)
        {//delete all line.
            foreach (object o in connectedLines)
            {
                if(GameObject.Find(o.ToString()))
                {
                    Destroy(GameObject.Find(o.ToString()));
                }
            }
            Destroy(connectedObject);
            Destroy(gameObject);
        }
    }
}
