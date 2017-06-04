using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutSceneScript : MonoBehaviour {

    public GameObject Canvas;
   
    public GameObject Player;
    public GameObject SpeakerName;
    public GameObject TextArea;
    public int cutSceneDialog;
    public int cutIDpass;
    public string[] cutScene1;
    public string[] cutScene2;
    public string[] cutScene3;
    public string[] cutScene4;
    public string[] cutScene5;
    public string[] cutScene6;
    public string[] cutScene7;
    public List<string[]> dialogsList = new List<string[]>();
    public bool CutSceneOn;
    public int cutSceneIDstart;

    public void Start()
    {
        DontDestroyOnLoad(gameObject);
        cutSceneDialog = 0;
        
        //cutscene id = 1
        cutScene1 = new string[2];
        cutScene1[0] = "Help";
        cutScene1[1] = "It came from bathroom, I must go there!";
        
        //cutscene id = 2
        cutScene2 = new string[3];
        cutScene2[0] = "Girl escape thourgh windows, i glad i came in time";
        cutScene2[1] = "Oh.....what is that?....";
        cutScene2[2] = "Keys to radio room? Maybe Osahara is there. I must go there";

        //cutscene id = 3
        cutScene3 = new string[5];
        cutScene3[0] = "Osahara, are you all right?";
        cutScene3[1] = "I almost had it, but thanks for help";
        cutScene3[2] = "Inomi was here too, i dont know where is she. Whole school is filled with those thighs";
        cutScene3[3] = "She went in way of music room, but we have to find Mr Murusaki. I saw him walking freely along those thighs, He must done something bad";
        cutScene3[4] = "I hope that our power are enough to face him";

        //cutscene id = 4
        cutScene4 = new string[2];
        cutScene4[0] = "....Yeeek....how they stinks....but he is not here";
        cutScene4[1] = "Forget about him, We go for Inomi";

        //cutscene id = 5
        cutScene5 = new string[6];
        cutScene5[0] = "Ohhhh, thank you girls you save me hih";
        cutScene5[1] = "Are you alright?";
        cutScene5[2] = "Did you saw Murusaki-san? He knows something about those monsters";
        cutScene5[3] = "I saw him going to Teachers room";
        cutScene5[4] = "Lets go to get some answers";
        cutScene5[5] = "Caution we dont know what he is planning";

        //cutscene id = 6
        cutScene6 = new string[3];
        cutScene6[0] = "What is this?!";
        cutScene6[1] = "I scared....";
        cutScene6[2] = "Its coming towards us, care!";

        //cutscene id = 7
        cutScene7 = new string[7];
        cutScene7[0] = "So what we do now?";
        cutScene7[1] = "We have to check other parts of School";
        cutScene7[2] = "Maybe other teachers know somethings";
        cutScene7[3] = "So we split and search?";
        cutScene7[4] = "We are in this together as group, so we stick for each other.";
        cutScene7[5] = "Yes, we move as group";
        cutScene7[6] = "Okay so we have to check Pool and Gym, hurry";

        cutSceneIDstart = 0;
        CutSceneOn = false;
        Canvas.SetActive(false);
    }

    public void cutSceneTrigger(int cutSceneID)
    {
        Player = GameObject.Find("Player");
        cutSceneIDstart = cutSceneID;
        Canvas.SetActive(true);
        switch (cutSceneID)
        {
            case 1:
                {
                 
                    
                
                    Player.GetComponent<BasicContolScript>().enabled = false;
                    Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                    Player.GetComponent<Animator>().SetTrigger("IDLE RIGHT");
                    
                    if (cutSceneDialog < cutScene1.Length)
                    {
                        TextArea.GetComponent<Text>().text = cutScene1[cutSceneDialog];
                        if(cutSceneDialog == 0)
                        {
                            SpeakerName.GetComponent<Text>().text = "Distant Shouting";
                        }
                        else
                        {
                            SpeakerName.GetComponent<Text>().text = "Miyagi";
                        }
                        CutSceneOn = true;
                    }
                    else
                    {
                       
                        Player.GetComponent<BasicContolScript>().enabled = true;
                        Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                        Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                        CutSceneOn = false;
                        Canvas.SetActive(false);
                    }
                    cutIDpass = cutSceneID;
                }
                break;

            case 2:
                {



                    Player.GetComponent<BasicContolScript>().enabled = false;
                    Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                    Player.GetComponent<Animator>().SetTrigger("IDLE RIGHT");

                    if (cutSceneDialog < cutScene2.Length)
                    {
                        TextArea.GetComponent<Text>().text = cutScene2[cutSceneDialog];
                        SpeakerName.GetComponent<Text>().text = "Miyagi";
                        CutSceneOn = true;
                    }
                    else
                    {

                        Player.GetComponent<BasicContolScript>().enabled = true;
                        Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                        Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                        CutSceneOn = false;
                        Canvas.SetActive(false);
                    }
                    cutIDpass = cutSceneID;
                }
                break;
            case 3:
                {



                    Player.GetComponent<BasicContolScript>().enabled = false;
                    Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                    Player.GetComponent<Animator>().SetTrigger("IDLE RIGHT");

                    if (cutSceneDialog < cutScene3.Length)
                    {
                        TextArea.GetComponent<Text>().text = cutScene3[cutSceneDialog];
                        if (cutSceneDialog == 1 || cutSceneDialog == 3 )
                        {
                            SpeakerName.GetComponent<Text>().text = "Osahara";
                        }
                        else
                        {
                            SpeakerName.GetComponent<Text>().text = "Miyagi";
                        }
                        CutSceneOn = true;
                    }
                    else
                    {

                        Player.GetComponent<BasicContolScript>().enabled = true;
                        Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                        Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                        CutSceneOn = false;
                        Canvas.SetActive(false);
                    }
                    cutIDpass = cutSceneID;
                }
                break;

            case 4:
                {



                    Player.GetComponent<BasicContolScript>().enabled = false;
                    Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                    Player.GetComponent<Animator>().SetTrigger("IDLE RIGHT");

                    if (cutSceneDialog < cutScene4.Length)
                    {
                        TextArea.GetComponent<Text>().text = cutScene4[cutSceneDialog];
                        if (cutSceneDialog == 0)
                        {
                            SpeakerName.GetComponent<Text>().text = "Osahara";
                        }
                        else
                        {
                            SpeakerName.GetComponent<Text>().text = "Miyagi";
                        }
                        CutSceneOn = true;
                    }
                    else
                    {

                        Player.GetComponent<BasicContolScript>().enabled = true;
                        Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                        Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                        CutSceneOn = false;
                        Canvas.SetActive(false);
                    }
                    cutIDpass = cutSceneID;
                }
                break;

            case 5:
                {



                    Player.GetComponent<BasicContolScript>().enabled = false;
                    Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                    Player.GetComponent<Animator>().SetTrigger("IDLE RIGHT");

                    if (cutSceneDialog < cutScene5.Length)
                    {
                        TextArea.GetComponent<Text>().text = cutScene5[cutSceneDialog];
                        if (cutSceneDialog == 0 || cutSceneDialog == 3)
                        {
                            SpeakerName.GetComponent<Text>().text = "Inomi";
                        }
                        else
                        {
                            if (cutSceneDialog == 1 || cutSceneDialog == 5)
                            {
                                SpeakerName.GetComponent<Text>().text = "Miyagi";
                            }
                            else
                            {
                                SpeakerName.GetComponent<Text>().text = "Osahara";
                            }
                        }
                        CutSceneOn = true;
                    }
                    else
                    {

                        Player.GetComponent<BasicContolScript>().enabled = true;
                        Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                        Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                        CutSceneOn = false;
                        Canvas.SetActive(false);
                    }
                    cutIDpass = cutSceneID;
                }
                break;

            case 6:
                {



                    Player.GetComponent<BasicContolScript>().enabled = false;
                    Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                    Player.GetComponent<Animator>().SetTrigger("IDLE RIGHT");

                    if (cutSceneDialog < cutScene6.Length)
                    {
                        TextArea.GetComponent<Text>().text = cutScene6[cutSceneDialog];
                        if (cutSceneDialog == 1)
                        {
                            SpeakerName.GetComponent<Text>().text = "Inomi";
                        }
                        else
                        {
                            if (cutSceneDialog == 2)
                            {
                                SpeakerName.GetComponent<Text>().text = "Miyagi";
                            }
                            else
                            {
                                SpeakerName.GetComponent<Text>().text = "Osahara";
                            }
                        }
                        CutSceneOn = true;
                    }
                    else
                    {

                        Player.GetComponent<BasicContolScript>().enabled = true;
                        Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                        Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                        CutSceneOn = false;
                        Canvas.SetActive(false);
                    }
                    cutIDpass = cutSceneID;
                }
                break;

            case 7:
                {



                    Player.GetComponent<BasicContolScript>().enabled = false;
                    Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                    Player.GetComponent<Animator>().SetTrigger("IDLE RIGHT");

                    if (cutSceneDialog < cutScene7.Length)
                    {
                        TextArea.GetComponent<Text>().text = cutScene7[cutSceneDialog];
                        if (cutSceneDialog == 0 || cutSceneDialog == 2 || cutSceneDialog ==5)
                        {
                            SpeakerName.GetComponent<Text>().text = "Inomi";
                        }
                        else
                        {
                            if (cutSceneDialog == 1 || cutSceneDialog == 4 )
                            {
                                SpeakerName.GetComponent<Text>().text = "Miyagi";
                            }
                            else
                            {
                                SpeakerName.GetComponent<Text>().text = "Osahara";
                            }
                        }
                        CutSceneOn = true;
                    }
                    else
                    {

                        Player.GetComponent<BasicContolScript>().enabled = true;
                        Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                        Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                        CutSceneOn = false;
                        
                        Canvas.SetActive(false);
                    }
                    cutIDpass = cutSceneID;
                }
                break;
        }


    }

    public void Update()
    {
      //  Player = GameObject.Find("Player");
    //        Canvas2 = GameObject.Find("Canvas2");
        


    }





    public void CutSceneButton()
    {
        cutSceneDialog = cutSceneDialog + 1;
        cutSceneTrigger(cutIDpass);
        
    }

}
