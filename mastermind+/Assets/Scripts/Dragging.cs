using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Dragging : MonoBehaviour
{
    private bool isDragging;
    private Vector2 resetPosition;
    private List<GameObject> correctForms = new List<GameObject>();
    private GameObject correctForm;
    private float startPosX;
    private float startPosY;

    private void Start()
    {
        resetPosition = this.transform.localPosition;
    }
    public void OnMouseDown()
    {
        if(Input.GetMouseButtonDown(0))
        {
            

            Vector2 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            isDragging = true;
        }
    }

    public void OnMouseUp()
    {
        isDragging = false;


        correctForm = GameObject.Find("ActiveRow");
        for (int i = 0; i < correctForm.transform.childCount/2; i++)
        {

            if (Mathf.Abs(this.transform.position.x - correctForm.transform.GetChild(i).gameObject.transform.position.x) <= 1 &&
           Mathf.Abs(this.transform.position.y - correctForm.transform.GetChild(i).gameObject.transform.position.y) <= 1)
            {
                this.transform.position = new Vector2(resetPosition.x, resetPosition.y);
                correctForm.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().color = this.GetComponent<SpriteRenderer>().color;
                break;
            }

        }

        this.transform.position = new Vector2(resetPosition.x, resetPosition.y);

    }

    private void Update()
    {
        if (isDragging)
        {
            Vector2 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.position = new Vector2(mousePos.x - startPosX, mousePos.y - startPosY);
            startPosX = mousePos.x - this.transform.position.x;
            startPosY = mousePos.y - this.transform.position.y;

            isDragging = true;
        }
    }
}
