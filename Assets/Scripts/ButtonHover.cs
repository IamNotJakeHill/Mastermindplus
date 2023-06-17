using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonHover : MonoBehaviour
{
    public Sprite normalSprite; // The normal/default sprite
    public Sprite hoverSprite; // The sprite to switch to on mouse hover

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogWarning("SpriteRenderer component not found on the GameObject.");
        }
        else
        {
            spriteRenderer.sprite = normalSprite; // Set the initial sprite to normal/default
        }
    }

    void OnMouseEnter()
    {
        if (spriteRenderer != null && hoverSprite != null)
        {
            spriteRenderer.sprite = hoverSprite; // Switch to hover sprite on mouse enter
        }
    }

    void OnMouseExit()
    {
        if (spriteRenderer != null && normalSprite != null)
        {
            spriteRenderer.sprite = normalSprite; // Switch back to normal/default sprite on mouse exit
        }
    }
}