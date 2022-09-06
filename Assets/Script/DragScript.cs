using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragScript : MonoBehaviour
{
    private GameObject target;
    private bool isMouseDrag;
    private Vector3 screenPosition;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        GameObjectDrag();       
    }
    private GameObject ReturnGameObjectDrag(out RaycastHit hit)
    { 
    //Aussenden von Strahlen in die Welt mit der Hauptkamera als Startpunkt.
    //Finde das ausgewählte Objekt
        target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            target = hit.collider.gameObject;
        }
        return target;
    }
    //drag Updata
    private void GameObjectDrag()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            target = ReturnGameObjectDrag(out hitInfo);
            if(target != null)
            {//Aktualisiere die Position des ausgewählten Objekts zu jeder Zeit.
                isMouseDrag = true;
                screenPosition = Camera.main.WorldToScreenPoint(target.transform.position);
                offset = target.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z));
            }  
        }
        if (Input.GetMouseButtonUp(0))
        {
            isMouseDrag = false;
        }
        if (isMouseDrag)
        {// Bildschirm Positionen in Welt Positionen umwandeln
            Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z);
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offset;
            target.transform.localPosition = new Vector3(currentPosition.x, currentPosition.y, currentPosition.z);

        }
    }
}
