using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class OnHitCameraSwitch : MonoBehaviour
{
    private Rigidbody2D body;
    public GameObject procedural_camera_spawn;
    public GameObject me;
  
    void OnTriggerEnter2D(Collider2D collision)
    {
        me.GetComponent<BoxCollider2D>().enabled = false;

        if (me.name == "CameraTrigger1")
        {
           
                GameObject.Find("Main Camera").GetComponent<Transform>().position = GameObject.Find("CameraSpawn1").GetComponent<Transform>().position;
            GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize = 7;
            StartCoroutine(Exam());
            
        }
        if (me.name == "CameraTriggerOrigin")
        {
              GameObject.Find("Main Camera").GetComponent<Transform>().position = GameObject.Find("CameraSpawn0").GetComponent<Transform>().position ;
             StartCoroutine(Exam());
            GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize = 7;
        }

        if (me.name == "CameraTrigger2")
        {
            GameObject.Find("Main Camera").GetComponent<Transform>().position = GameObject.Find("CameraSpawn2").GetComponent<Transform>().position;
            GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize = 7;
            StartCoroutine(Exam());
        }

        if (me.name == "CameraTrigger3")
        {
            GameObject.Find("Main Camera").GetComponent<Transform>().position = GameObject.Find("CameraSpawn3").GetComponent<Transform>().position;
            StartCoroutine(Exam());
            GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize = 7;
        }

        if (me.name == "CameraTrigger4")
        {
            GameObject.Find("Main Camera").GetComponent<Transform>().position = GameObject.Find("CameraSpawn4").GetComponent<Transform>().position;
            StartCoroutine(Exam());
            GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize = 7;
        }

        if (me.name == "CameraTrigger5")
        {
            GameObject.Find("Main Camera").GetComponent<Transform>().position = GameObject.Find("CameraSpawn5").GetComponent<Transform>().position;
            StartCoroutine(Exam());
            GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize = 7;
        }

        if (me.name == "CameraTrigger6")
        {
            GameObject.Find("Main Camera").GetComponent<Transform>().position = GameObject.Find("CameraSpawn6").GetComponent<Transform>().position;
            GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize = 6;
     //       GameObject.Find("Main Camera").GetComponent<Camera>().rect = new Rect(0, 0, 1f, 2.28f);
            StartCoroutine(Exam());
        }

        if (me.name == "CameraTrigger7")
        {
            GameObject.Find("Main Camera").GetComponent<Transform>().position = GameObject.Find("CameraSpawn7").GetComponent<Transform>().position;
            StartCoroutine(Exam());
        }

        if (me.name == "CameraTrigger8")
        {
            GameObject.Find("Main Camera").GetComponent<Transform>().position = GameObject.Find("CameraSpawn8").GetComponent<Transform>().position;
            GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize = 6;
       //     GameObject.Find("Main Camera").GetComponent<Camera>().rect = new Rect(0, 0, 1f, 2.28f);
            StartCoroutine(Exam());
        }
        
        if (me.name == "CameraTrigger9")
        {
            GameObject.Find("Main Camera").GetComponent<Transform>().position = GameObject.Find("CameraSpawn9").GetComponent<Transform>().position;
            GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize = 4;
         //   GameObject.Find("Main Camera").GetComponent<Camera>().rect = new Rect(0, 0, 1f, 2.28f);
            StartCoroutine(Exam());
        }

        if (me.name == "CameraTrigger10")
        {
            GameObject.Find("Main Camera").GetComponent<Transform>().position = GameObject.Find("CameraSpawn10").GetComponent<Transform>().position;
            GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize = 4;
            //   GameObject.Find("Main Camera").GetComponent<Camera>().rect = new Rect(0, 0, 1f, 2.28f);
            StartCoroutine(Exam());
        }

        if (me.name == "CameraTrigger11")
        {
            GameObject.Find("Main Camera").GetComponent<Transform>().position = GameObject.Find("CameraSpawn11").GetComponent<Transform>().position;
            GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize = 4;
            //   GameObject.Find("Main Camera").GetComponent<Camera>().rect = new Rect(0, 0, 1f, 2.28f);
            StartCoroutine(Exam());
        }

        if (me.name == "CameraTrigger12")
        {
            GameObject.Find("Main Camera").GetComponent<Transform>().position = GameObject.Find("CameraSpawn12").GetComponent<Transform>().position;
            GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize = 5;
          
            StartCoroutine(Exam());
        }

        if(me.name == "CameraSwitcher")
        {
            if (GameObject.Find("Main Camera"))
            {
                GameObject.Find("Main Camera").GetComponent<Transform>().position = procedural_camera_spawn.GetComponent<Transform>().position;
            }

            StartCoroutine(Exam());
        }
    }

    IEnumerator Exam()
    {
        yield return new WaitForSeconds(0.5f);
        me.GetComponent<BoxCollider2D>().enabled = true;
    }



}