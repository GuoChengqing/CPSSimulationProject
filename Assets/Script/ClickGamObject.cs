using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickGamObject : MonoBehaviour
{
    private Ray ray;//Physikalische Strahlen
    public RaycastHit hit;//Physikalische Strahlen
    private bool firstClick = true;//Neue Runde Flag
    private bool clickFlag = true;//Flag für Klick oder Doppelklick (Standardklick)
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        monitor();
    }
    //Einfacher und doppelter Mausklick Hören
    private void monitor()
    {
        //Klick mit der linken Maustaste auslösen
        if (!Input.GetMouseButtonDown(0)) return;
        //Das vom Strahl erfasste Objekt ist das aktuelle Objekt
        if (Camera.main != null) ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out hit) || hit.collider.gameObject != gameObject) return;
        clickFlag = !clickFlag;
        //Feststellen, ob die vorherige Runde beendet ist
        if (!firstClick) return;
        firstClick = false; 
        //Initialisierung des Timers und Ausführung der geplanten Methode nach 300 Millisekunden
        Invoke("Timer", 0.3f);
    }

    private void Timer()
    {
        if (clickFlag)
        {
            OnDoubleclick();
        }
        else
        {
            OnClick();
        }
        firstClick = true;
        clickFlag = true;
    }
    private void OnClick()
    {
    }
    private void OnDoubleclick()
    {
        string objectUIName = gameObject.name + "UI" ;
        //Verwenden Sie den Wurzelknoten, um die entsprechende UI zu finden
        GameObject root = GameObject.Find("GeneratortUI");
        GameObject objectUI = root.transform.Find(objectUIName).gameObject;
        objectUI.SetActive(true);
        //Aktualisieren Sie die Liste der Hardware im Agenten
        if(gameObject.tag == "Agent")
        {
          gameObject.transform.GetComponent<MyAgentAttribute>().GetHardwareName();
        }
    }
}

