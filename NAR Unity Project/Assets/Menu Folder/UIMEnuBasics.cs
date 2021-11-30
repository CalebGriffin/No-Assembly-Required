using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMEnuBasics : MonoBehaviour
{
    public int currentMenu = 1;
    public GameObject[] Menus;
    public int desiredMenu;
    public Transform removedLocation;
    public Transform presentLocation;
    public Transform transferLocation;

    void Start()
    {
        Menus = GameObject.FindGameObjectsWithTag("Menu");
        Invoke("MenuCheck", 0.5f);
    }

    void MenuCheck()
    {
        if (currentMenu != desiredMenu)
        {
            //if(Menus(currentMenu).transform != RemovedLocation || Menus(currentMenu).transform != transferLocation)
            {

            }
            
        }
    }
    
}
