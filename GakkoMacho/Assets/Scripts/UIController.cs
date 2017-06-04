using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    
    public void Eneme1 (Text name1)
    {
        name1.enabled = true;
    }

    public void Eneme2UI(Text name1, Text name2)
    {
        name1.enabled = true;
        name2.enabled = true;
    }
    
    
}


