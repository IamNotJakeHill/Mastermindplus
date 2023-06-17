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
    public Sprite hidingRow;

<<<<<<< Updated upstream
    public List<Color32> colors; //= new List<Color32>(new Color32[] { new Color32(), new Color32(), new Color, 4, 5, 6 });
=======
    public int sortingOrder = 10;
    private int reg = 5;

    public List<Color32> colors;
>>>>>>> Stashed changes
    List<GameObject> rows = new List<GameObject>();
    void Start()
    {
        rowsNumber = (int)OptionsData.rowsNumber;
        if (rowsNumber <= 6) reg = (rowsNumber - 1) * 5; //regulacja pozycji rozpoczêcia generowania planszy
        else reg = 30;
        for (int i = 0; i < rowsNumber+1; i++) //generowanie planszy
        {
            GameObject tempObject;
            
            if (i == rowsNumber) //generowanie ostatniego wiersza zawieraj¹cego kod
            {
                GameObject endObject = new GameObject("HidingRow"); //generowanie panelu zakrywaj¹cego kod
                endObject.transform.localPosition = new Vector2(0, 5 * i - reg);
                endObject.transform.parent = GameObject.Find("CanvasUI").transform;
                var tempSpriteEnd = endObject.AddComponent<SpriteRenderer>();
                var tempColliderEnd = endObject.AddComponent<BoxCollider>();
                tempSpriteEnd.sortingOrder = 3;
                tempSpriteEnd.sprite = hidingRow;


                tempObject = new GameObject("EndingRow");
                tempObject.transform.localPosition = new Vector2(0,5 * i- reg);
                tempObject.transform.parent = GameObject.Find("Canvas").transform;
                var tempSprite2 = tempObject.AddComponent<SpriteRenderer>();
                var tempCollider2 = tempObject.AddComponent<BoxCollider>();
                tempSprite2.sprite = rowSprite;

<<<<<<< Updated upstream
                for (int j = 0; j < 4; j++)
=======
               

                for (int j = 0; j < 4; j++) //generowanie slotów ostatniego wiersza zawieraj¹cych kod do zgadniêcia
>>>>>>> Stashed changes
                {
                    GameObject tempSlot = new GameObject("Slot" + "_" + i + "_" + j);
                    tempSlot.transform.localPosition = new Vector2(-1 + 2 * j,5 * i-reg);
                    tempSlot.transform.parent = tempObject.transform;
                    var tempSlotSprite = tempSlot.AddComponent<SpriteRenderer>();
                    var tempSlotCollider = tempSlot.AddComponent<BoxCollider>();
                    tempSlotSprite.sortingOrder = 2;
                    tempSlotSprite.sprite = slotSprite;

                    var random = new System.Random(); //losowanie kodu
                    int index = random.Next(colors.Count);
                    tempSlotSprite.color = colors[index];
                    colors.RemoveAt(index);
                }

                break;
            }

            if (i == 0) //generowanie pierwszego wiersza
            {
                tempObject = new GameObject("ActiveRow");
            }

            else //generowanie œrodkowych wierszy
            {
                tempObject = new GameObject("Row" + i);
            }

            tempObject.transform.localPosition = new Vector2(0,5 * i - reg);
            tempObject.transform.parent = GameObject.Find("Canvas").transform;
            var tempSprite = tempObject.AddComponent<SpriteRenderer>();
            var tempCollider = tempObject.AddComponent<BoxCollider>();
            tempSprite.sprite = rowSprite;

            for(int j = 0; j < 4; j++) //generowanie slotów do wprowadzania kodu
            {
                GameObject tempSlot = new GameObject("Slot" +"_"+ i+"_"+j);
                tempSlot.transform.localPosition = new Vector2(-1+2*j,5 *i- reg);
                tempSlot.transform.parent = tempObject.transform;
                var tempSlotSprite = tempSlot.AddComponent<SpriteRenderer>();
                var tempSlotCollider = tempSlot.AddComponent<BoxCollider>();
                tempSlotSprite.sortingOrder = 2;
                tempSlotSprite.sprite = slotSprite;

            }
            for (int j = 0; j < 4; j++) //generowanie slotów do podpowiedzi kodu
            {
                if (j < 2)
                {
                    GameObject tempSlot = new GameObject("Check_Slot" + "_" + i + "_" + j);
                    tempSlot.transform.localPosition = new Vector2(-8 + 2 * j,1+5*i- reg);
                    tempSlot.transform.parent = tempObject.transform;
                    var tempSlotSprite = tempSlot.AddComponent<SpriteRenderer>();
                    var tempSlotCollider = tempSlot.AddComponent<BoxCollider>();
                    tempSlotSprite.sortingOrder = 2;
                    tempSlotSprite.sprite = slotSprite;
                }
                else
                {
                    GameObject tempSlot = new GameObject("Check_Slot" + "_" + i + "_" + j);
                    tempSlot.transform.localPosition = new Vector2(-8 + 2 * (j-2),-1+5*i- reg);
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
