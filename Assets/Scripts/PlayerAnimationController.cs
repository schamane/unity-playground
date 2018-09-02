using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class PlayerAnimationController : MonoBehaviour
{

    private Animator anim;
    private Rigidbody rigidbody;
    private Vector3 prevPos;
    float prevSpeed;

    void Awake()
    {
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        prevPos = transform.position;
    }

    void Update()
    {
        var time = Time.deltaTime;
        var dist = transform.position - prevPos;
        var speed = new Vector3(dist.x, 0, dist.z).normalized.magnitude / time;

        if (prevSpeed == 0 && speed == 0)
        {
            anim.SetFloat("Speed", 0);
            // Debug.Log("stands");
        }
        else if (speed == 0)
        {
            anim.SetFloat("Speed", prevSpeed);
            // Debug.Log("run in");
        }
        else
        {
            anim.SetFloat("Speed", speed);
            // Debug.Log("run");
        }

        prevPos = transform.position;
        prevSpeed = speed;
        // Debug.Log(speed);
    }

    /*
	void OnGUI()
    {
        //Create a Label in Game view for the Slider
        GUI.Label(new Rect(0, 25, 40, 60), "Speed");
        //Create a horizontal Slider to control the speed of the Animator. Drag the slider to 1 for normal speed.

        sliderValue = GUI.HorizontalSlider(new Rect(45, 25, 200, 60), sliderValue, 0.0F, 1.0F);
        //Make the speed of the Animator match the Slider value
        anim.speed = sliderValue;
    }
	*/
}
