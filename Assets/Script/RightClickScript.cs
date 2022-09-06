using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightClickScript : MonoBehaviour
{
    private Ray ray;
    public RaycastHit hit;
    public GameObject downObject;
    public GameObject upObject;
    public string downObjectName;
    public string upObjectName;
    private GameObject hitObject;
    private GameObject lineDraw;
    // Start is called before the first frame update
    void Start()
    {
        lineDraw = GameObject.Find("LineDraw");//Finde das Objekt namens "LineDraw" in der Szene
    }
    // Update is called once per frame
    void Update()
    {
        monitor();
    }
    private void monitor()
    {
        //Rechte Maustaste drücken auslösen
        if (Input.GetMouseButtonDown(1)){
            //Das vom Strahl erkannte Objekt ist das aktuelle Objekt
            if (Camera.main != null) ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out hit) || hit.collider.gameObject != gameObject) return;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.collider.gameObject;    //Erhalte das ausgewählte Objekt
                downObjectName = hitObject.name;    //Erhalte den Namen des ausgewählten Objekts
            }
            //Sendet das beim Drücken der rechten Maustaste ausgewählte Objekt 
            //an die Funktion namens "GetDUpObjectName" im Skript des lineDraw-Objekts.
            lineDraw.SendMessage("GetDownObjectName",downObjectName);
        }
        
        //Rechte Maustaste heben auslösen
        if (Input.GetMouseButtonUp(1)){
            //Das vom Strahl erkannte Objekt ist das aktuelle Objekt
            if (Camera.main != null) ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out hit) || hit.collider.gameObject != gameObject) return;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.collider.gameObject;    //Erhalte das ausgewählte Objekt
                upObjectName = hitObject.name;    //Erhalte den Namen des ausgewählten Objekts
            }
            //Sendet das beim Anheben der rechten Maustaste ausgewählte Objekt
            //an eine Funktion namens "GetDUpObjectName" im Skript des lineDraw Objekts.
            lineDraw.SendMessage("GetUpObjectName",upObjectName);
        }
    }
}