using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Returntomainmenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        // ����DontDestroyOnLoad���������밴ť����
        Object.DontDestroyOnLoad(this);
    }

    
}
