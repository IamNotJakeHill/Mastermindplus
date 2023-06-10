using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generowanie_planszy : MonoBehaviour
{
    private SpriteRenderer rend;
    public int rowsNumber;
    public Sprite rowSprite;
    public Sprite slotSprite;

    public int sortingOrder = 10;

    public List<Color32> colors; //= new List<Color32>(new Color32[] { new Color32(), new Color32(), new Color, 4, 5, 6 });
    List<GameObject> rows = new List<GameObject>();
    void Start()
    {
        //rowSprite = Resources.Load<Sprite>("StartingRow");
        //slotSprite = Resources.Load<Sprite>("SlotBig");
        for (int i = 0; i < rowsNumber+1; i++)
        {
            GameObject tempObject;
            
            if (i == rowsNumber)
            {
                tempObject = new GameObject("EndingRow");

                tempObject.transform.position = new Vector2(0, 5 * i);
                tempObject.transform.parent = GameObject.Find("Canvas").transform;
                var tempSprite2 = tempObject.AddComponent<SpriteRenderer>();
                var tempCollider2 = tempObject.AddComponent<BoxCollider>();
                tempSprite2.sprite = rowSprite;

               

                for (int j = 0; j < 4; j++)
                {
                    GameObject tempSlot = new GameObject("Slot" + "_" + i + "_" + j);
                    tempSlot.transform.position = new Vector2(-1 + 2 * j, 5 * i);
                    tempSlot.transform.parent = tempObject.transform;
                    var tempSlotSprite = tempSlot.AddComponent<SpriteRenderer>();
                    var tempSlotCollider = tempSlot.AddComponent<BoxCollider>();
                    tempSlotSprite.sortingOrder = 2;
                    tempSlotSprite.sprite = slotSprite;

                    var random = new System.Random();
                    int index = random.Next(colors.Count);
                    tempSlotSprite.color = colors[index];
                    colors.RemoveAt(index);
                }

                break;
            }

            if (i == 0)
            {
                tempObject = new GameObject("ActiveRow");
            }

            else
            {
                tempObject = new GameObject("Row" + i);
            }

            tempObject.transform.position = new Vector2(0, 5 * i);
            tempObject.transform.parent = GameObject.Find("Canvas").transform;
            var tempSprite = tempObject.AddComponent<SpriteRenderer>();
            var tempCollider = tempObject.AddComponent<BoxCollider>();
            tempSprite.sprite = rowSprite;

            for(int j = 0; j < 4; j++)
            {
                GameObject tempSlot = new GameObject("Slot" +"_"+ i+"_"+j);
                tempSlot.transform.position = new Vector2(-1+2*j,5*i);
                tempSlot.transform.parent = tempObject.transform;
                var tempSlotSprite = tempSlot.AddComponent<SpriteRenderer>();
                var tempSlotCollider = tempSlot.AddComponent<BoxCollider>();
                tempSlotSprite.sortingOrder = 2;
                tempSlotSprite.sprite = slotSprite;

            }
            for (int j = 0; j < 4; j++)
            {
                if (j < 2)
                {
                    GameObject tempSlot = new GameObject("Check_Slot" + "_" + i + "_" + j);
                    tempSlot.transform.position = new Vector2(-8 + 2 * j, 1+5*i);
                    tempSlot.transform.parent = tempObject.transform;
                    var tempSlotSprite = tempSlot.AddComponent<SpriteRenderer>();
                    var tempSlotCollider = tempSlot.AddComponent<BoxCollider>();
                    tempSlotSprite.sortingOrder = 2;
                    tempSlotSprite.sprite = slotSprite;
                }
                else
                {
                    GameObject tempSlot = new GameObject("Check_Slot" + "_" + i + "_" + j);
                    tempSlot.transform.position = new Vector2(-8 + 2 * (j-2), -1+5*i);
                    tempSlot.transform.parent = tempObject.transform;
                    var tempSlotSprite = tempSlot.AddComponent<SpriteRenderer>();
                    var tempSlotCollider = tempSlot.AddComponent<BoxCollider>();
                    tempSlotSprite.sortingOrder = 2;
                    tempSlotSprite.sprite = slotSprite;
                }
                
            }
        }
    }
}
