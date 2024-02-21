using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseManager : MonoBehaviour
{
    // to know what object are clicable
    public LayerMask clickableLayer;

    // cursor swap per object
    public Texture2D pointer;
    public Texture2D target;
    public Texture2D doorWay;
    public Texture2D combat;
    Vector2 cursorSize = new Vector2(16, 16);
    //public UnityAction<Vector3> OnClickEnvironment;
    public UnityEvent<Vector3> OnClickEnvironment;
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit,50, clickableLayer))
        {
            bool door = false;
            bool item = false;

            if (hit.collider.gameObject.tag == "DoorWay")
            {
                door = true;
                Cursor.SetCursor(doorWay, cursorSize, CursorMode.Auto);
            }else if (hit.collider.gameObject.tag == "Item")
            {
                item = true;
                Cursor.SetCursor(combat, cursorSize, CursorMode.Auto);
            }
            else
            {
                Cursor.SetCursor(target, cursorSize, CursorMode.Auto);
            }



            if (Input.GetMouseButtonDown(0))
            {
                if (door)
                {
                    OnClickEnvironment.Invoke(hit.collider.gameObject.transform.position);
                    print("door");

                }else if (item)
                {
                    OnClickEnvironment.Invoke(hit.transform.position);
                    print("item");

                }
                else
                {
                    OnClickEnvironment.Invoke(hit.point);
                }
            }
        }
        else
        {
            Cursor.SetCursor(pointer, cursorSize, CursorMode.Auto);
        }
    }
}
