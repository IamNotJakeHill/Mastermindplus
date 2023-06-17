using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clonner : MonoBehaviour
{
    private GameObject cloneObject;
    private SpriteRenderer spriteRenderer;
    public Vector2 Scale = new Vector2(2f, 1f);

    // Start is called before the first frame update

    public void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            cloneObject = new GameObject("CloneObject");
            cloneObject.transform.position = mousePos;
            cloneObject.transform.localScale = transform.localScale;
            SpriteRenderer cloneSpriteRenderer = cloneObject.AddComponent<SpriteRenderer>();
            RectTransform cloneRecttranform = cloneObject.AddComponent<RectTransform>();
            cloneSpriteRenderer.sprite = spriteRenderer.sprite;
            cloneSpriteRenderer.color = spriteRenderer.color;
            cloneObject.GetComponent<SpriteRenderer>().sortingOrder = 11;
            cloneObject.GetComponent<RectTransform>().localScale = Scale;
            Dragging script = cloneObject.AddComponent<Dragging>();
            // Update is called once per frame
        }
    }
}