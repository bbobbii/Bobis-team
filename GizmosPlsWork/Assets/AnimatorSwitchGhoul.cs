using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorSwitchGhoul : MonoBehaviour
{
    public Animator animator;
    [SerializeField] float horizontalMove;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
    }
}
