using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generowanie_planszy : MonoBehaviour
{
    private SpriteRenderer rend;
    public int rowsNumber; // Number of rows
    public Sprite rowSprite; // Sprite for regular rows
    public Sprite slotSprite; // Sprite for slots
    public Sprite hidingRow; // Sprite for hiding row
    private int reg = 5; // Regularization value for positioning
    public int orderInLayer = 10;  // order in layer so assets appear above bg
    public List<Color32> colors; // List of colors
    List<GameObject> rows = new List<GameObject>(); // List of row game objects

    void Start()
    {
        rowsNumber = (int)OptionsData.rowsNumber; // Get the number of rows from OptionsData
        if (rowsNumber <= 6)
            reg = (rowsNumber - 1) * 5; // Adjust the position of generating the board
        else
            reg = 30;

        for (int i = 0; i < rowsNumber + 1; i++) // Generate the board
        {
            GameObject tempObject;

            if (i == rowsNumber) // Generate the last row containing the code
            {
                // Generate the hiding row panel
                GameObject endObject = new GameObject("HidingRow");
                endObject.transform.localPosition = new Vector2(0, 5 * i - reg);
                endObject.transform.parent = GameObject.Find("CanvasUI").transform;
                var tempSpriteEnd = endObject.AddComponent<SpriteRenderer>();
                var tempColliderEnd = endObject.AddComponent<BoxCollider>();
                tempSpriteEnd.sortingOrder = 3;
                tempSpriteEnd.sprite = hidingRow;

                // Generate the ending row
                tempObject = new GameObject("EndingRow");
                tempObject.transform.localPosition = new Vector2(0, 5 * i - reg);
                tempObject.transform.parent = GameObject.Find("Canvas").transform;
                var tempSprite2 = tempObject.AddComponent<SpriteRenderer>();
                var tempCollider2 = tempObject.AddComponent<BoxCollider>();
                tempSprite2.sprite = rowSprite;

                for (int j = 0; j < 4; j++) // Generate slots in the last row for the code to guess
                {
                    GameObject tempSlot = new GameObject("Slot" + "_" + i + "_" + j);
                    tempSlot.transform.localPosition = new Vector2(-1 + 2 * j, 5 * i - reg);
                    tempSlot.transform.parent = tempObject.transform;
                    var tempSlotSprite = tempSlot.AddComponent<SpriteRenderer>();
                    var tempSlotCollider = tempSlot.AddComponent<BoxCollider>();
                    tempSlotSprite.sortingOrder = 2;
                    tempSlotSprite.sprite = slotSprite;

                    var random = new System.Random(); // Randomly select a color for the slot
                    int index = random.Next(colors.Count);
                    tempSlotSprite.color = colors[index];
                    colors.RemoveAt(index);
                }

                break;
            }

            if (i == 0) // Generate the first row
            {
                tempObject = new GameObject("ActiveRow");

            }
            else // Generate middle rows
            {
                tempObject = new GameObject("Row" + i);
            }

            tempObject.transform.localPosition = new Vector2(0, 5 * i - reg);
            tempObject.transform.parent = GameObject.Find("Canvas").transform;
            var tempSprite = tempObject.AddComponent<SpriteRenderer>();
            var tempCollider = tempObject.AddComponent<BoxCollider>();
            tempSprite.sprite = rowSprite;
            Renderer renderer = GetComponent<Renderer>();
            renderer.sortingOrder = orderInLayer;

            for (int j = 0; j < 4; j++) // Generate slots for entering the code
            {
                GameObject tempSlot = new GameObject("Slot" + "_" + i + "_" + j);
                tempSlot.transform.localPosition = new Vector2(-1 + 2 * j, 5 * i - reg);
                tempSlot.transform.parent = tempObject.transform;
                var tempSlotSprite = tempSlot.AddComponent<SpriteRenderer>();
                var tempSlotCollider = tempSlot.AddComponent<BoxCollider>();
                tempSlotSprite.sortingOrder = 10;
                tempSlotSprite.sprite = slotSprite;
         
                renderer.sortingOrder = orderInLayer;
            }

            for (int j = 0; j < 4; j++) // Generate slots for code hints
            {
                if (j < 2)
                {
                    GameObject tempSlot = new GameObject("Check_Slot" + "_" + i + "_" + j);
                    tempSlot.transform.localPosition = new Vector2(-8 + 2 * j, 1 + 5 * i - reg);
                    tempSlot.transform.parent = tempObject.transform;
                    var tempSlotSprite = tempSlot.AddComponent<SpriteRenderer>();
                    var tempSlotCollider = tempSlot.AddComponent<BoxCollider>();
                    tempSlotSprite.sortingOrder = 10;
                    tempSlotSprite.sprite = slotSprite;
                }
                else
                {
                    GameObject tempSlot = new GameObject("Check_Slot" + "_" + i + "_" + j);
                    tempSlot.transform.localPosition = new Vector2(-8 + 2 * (j - 2), -1 + 5 * i - reg);
                    tempSlot.transform.parent = tempObject.transform;
                    var tempSlotSprite = tempSlot.AddComponent<SpriteRenderer>();
                    var tempSlotCollider = tempSlot.AddComponent<BoxCollider>();
                    tempSlotSprite.sortingOrder = 10;
                    tempSlotSprite.sprite = slotSprite;
                }
            }
        }
    }
}
