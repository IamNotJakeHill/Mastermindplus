using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextButton : MonoBehaviour
{
    public void GetnextRow()
    {
        PopUpSystem pop = GameObject.Find("GameManager").GetComponent<PopUpSystem>();
        GameObject correctForm = GameObject.Find("ActiveRow");
        bool rowFull = true;
        for (int i = 0; i < correctForm.transform.childCount/2; i++)
        {
            if (correctForm.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().color == new Color(1, 1, 1))
            {
                rowFull = false;
                break;
            }
        }
        if (rowFull)
        {
            GameObject parentObject = GameObject.Find("Canvas");
            //parentObject.transform.get
            for(int i = 0; i <parentObject.transform.childCount-1;i++)
            {
                if (parentObject.transform.GetChild(i).gameObject.name == "ActiveRow")
                {
                    if(parentObject.transform.GetChild(i+1).gameObject.name == "EndingRow")
                    {
                        if (checkCode(correctForm))
                        {
                            Debug.Log("You won!");
                            pop.popUp("You won!");
                            break;
                        }
                        else
                        {
                            Debug.Log("You Loose!");
                            pop.popUp("You loose!");
                            break;
                        }
                    }
                    else
                    {
                        if (checkCode(correctForm))
                        {
                            
                            Debug.Log("You won!");
                            pop.popUp("You won!");
                            break;
                        }
                        else
                        {
                            correctForm.transform.name = "Row" + i;
                            parentObject.transform.GetChild(i + 1).gameObject.name = "ActiveRow";

                            Debug.Log("Try again");
                            break;
                        }
                        
                    }
                    
                }
            }

        }
    }

    public bool checkCode(GameObject row)
    {
        int goodColorAndPosition = 0;
        int noColor = 0;
        List<Color32> checkColors = new List<Color32>();

        GameObject codeRow = GameObject.Find("EndingRow");
        for(int i =0;i< codeRow.transform.childCount; i++)
        {

            if (ColorEquals(row.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().color, codeRow.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().color)) 
            {
                checkColors.Add(new Color(0, 0, 0));
                goodColorAndPosition++;
                continue;
            }

            for(int j = 0; j < codeRow.transform.childCount; j++)
            {
                if(ColorEquals(row.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().color, codeRow.transform.GetChild(j).gameObject.GetComponent<SpriteRenderer>().color))
                {
                    checkColors.Add(new Color(0.1f, 0.90f, 0.13f));
                    break;
                }
            }
        }


        noColor = codeRow.transform.childCount - checkColors.Count;
        for(int j = 0; j < noColor; j++)
        {
            checkColors.Add(new Color(1, 1, 1));
        }

        
        for(int i = row.transform.childCount / 2; i < row.transform.childCount; i++)
        {
            var random = new System.Random();
            int index = random.Next(checkColors.Count);
            row.transform.GetChild(i).gameObject.transform.GetComponent<SpriteRenderer>().color = checkColors[index];
            checkColors.RemoveAt(index);
        }

        if (goodColorAndPosition == row.transform.childCount / 2) return true;
        else return false;
        
    }

    public static bool ColorEquals(Color a, Color b, float tolerance = 0.04f) //ukradzione z https://forum.unity.com/threads/colors-not-exactly-matching.381914/
    {
        if (a.r > b.r + tolerance) return false;
        if (a.g > b.g + tolerance) return false;
        if (a.b > b.b + tolerance) return false;
        if (a.r < b.r - tolerance) return false;
        if (a.g < b.g - tolerance) return false;
        if (a.b < b.b - tolerance) return false;

        return true;
    }

}
