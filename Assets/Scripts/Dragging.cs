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
    public Vector2 Scale = new Vector2(2f, 2f);
    public Vector2 StartScale = new Vector2(9f, 9f);
    private void Start()
    {

        resetPosition = this.transform.position; 

    }
    private void ScaleObject(Vector2 scale)
    {
        transform.localScale = scale;
    }

    private void ResetScale()
    {
        transform.localScale = StartScale;
    }
    public void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {


            Vector2 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            this.transform.position = mousePos; // Center position on mouse point

            isDragging = true;
            ScaleObject(Scale); // Scale the object when mouse is pressed down
        }
    }

    public void OnMouseUp()
    {
        isDragging = false;

        ResetScale();

        correctForm = GameObject.Find("ActiveRow");
        for (int i = 0; i < correctForm.transform.childCount / 2; i++)
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




/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragging : MonoBehaviour
{
    private bool isDragging;
    private Vector2 resetPosition;
    private GameObject cloneObject;
    private SpriteRenderer spriteRenderer;
    public Vector2 Scale = new Vector2(2f,1f);
    public void Start()
    {
        resetPosition = transform.localPosition;
        spriteRenderer = GetComponent<SpriteRenderer>();
        RectTransform rectTransform = GetComponent<RectTransform>();
    }

    public void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isDragging = true;

            cloneObject = new GameObject("CloneObject");
            cloneObject.transform.position = mousePos;
            cloneObject.transform.localScale = transform.localScale;
            SpriteRenderer cloneSpriteRenderer = cloneObject.AddComponent<SpriteRenderer>();
            RectTransform cloneRecttranform = cloneObject.AddComponent<RectTransform>();
            cloneSpriteRenderer.sprite = spriteRenderer.sprite;
            cloneSpriteRenderer.color = spriteRenderer.color;
            cloneObject.GetComponent<SpriteRenderer>().sortingOrder = 11;
            cloneObject.GetComponent<RectTransform>().localScale =Scale;
            ScriptName script = cloneObject.AddComponent<Dragging>();


        }
    }

    public void OnMouseUp()
    {
        if (isDragging)
        {
            isDragging = false;
            Destroy(cloneObject);

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D[] hitColliders = Physics2D.OverlapPointAll(mousePos);

            foreach (Collider2D collider in hitColliders)
            {
                if (collider.CompareTag("Target"))
                {
                    collider.GetComponent<SpriteRenderer>().color = spriteRenderer.color;
                    break;
                }
            }

            transform.localPosition = resetPosition;
        }
    }

    private void Update()
    {
        if (isDragging)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cloneObject.transform.position = mousePos;
        }
    }
}*/
