using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginGame : MonoBehaviour
{
    // Start is called before the first frame update
    void OnMouseDown()
    {
        Animator animator = GetComponent<Animator>();
        animator.SetTrigger("PlayAnimation");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
