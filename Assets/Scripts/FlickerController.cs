using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerController : MonoBehaviour
{

    Animator anim;

    void Awake()
    {
        anim = GetComponentInParent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        anim.SetBool("Flicker", true);
        // Debug.Log("Activate flicker");
    }

    void OnTriggerExit(Collider other)
    {
        anim.SetBool("Flicker", false);
        // Debug.Log("Deactivate flicker");
    }

}
