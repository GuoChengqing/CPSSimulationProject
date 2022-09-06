using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISetParentsScript : MonoBehaviour
{
    public GameObject objectUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void setParents()
    {
        transform.SetParent(objectUI.transform);
        
    }
}
