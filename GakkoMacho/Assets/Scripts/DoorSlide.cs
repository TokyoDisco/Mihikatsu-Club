using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSlide : MonoBehaviour {

    public GameObject me;
    public Vector3 origPos;
    public GameObject SlideSound;
    private void Start()
    {
        origPos = me.GetComponent<Transform>().position;
    }
    void OnTriggerEnter2D(Collider2D body)
    {
        if (me.tag == "InterDoor")
        {
            if (me.name == "opositeDoors")
            {
                Vector3 slide = new Vector3(1.8f, 0, 0);
                me.GetComponent<Transform>().position = me.GetComponent<Transform>().position + slide;
                SlideSound.GetComponent<AudioSource>().mute = false;
                SlideSound.GetComponent<AudioSource>().Play();
            }
            else
            {
                Vector3 slide = new Vector3(-1.8f, 0, 0);
                me.GetComponent<Transform>().position = me.GetComponent<Transform>().position + slide;
                SlideSound.GetComponent<AudioSource>().mute = false;
                SlideSound.GetComponent<AudioSource>().Play();
            }
        }
      
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        me.GetComponent<Transform>().position = origPos;
        SlideSound.GetComponent<AudioSource>().mute = true;
    }


}
