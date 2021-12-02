using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMEnuBasics : MonoBehaviour
{
    [SerializeField]
    int currentMenu = 1;
    [SerializeField]
    GameObject[] Menus;
    [SerializeField]
    int desiredMenu = 1;
    public Transform removedLocation;
    public Transform presentLocation;
    public Transform transferLocation;
    float speed = 1f;
    float step;
    bool notInMotion;

    void Start()
    {
        Menus = GameObject.FindGameObjectsWithTag("Menu");
        Invoke("MenuCheck", 0.5f);
        
    }
    void Update()
    {
        step = speed * Time.deltaTime;
    }

    void MenuCheck()
    {
        Debug.Log("MenuCheck Called");
        if (notInMotion == false)
        {
            for (int x = 0; x == Menus.Length; x++)
            {
                Debug.Log("x is equal to" + x);
                if (Menus[x].transform == presentLocation)
                {
                    currentMenu = x + 1;
                }
            }
        }
        Invoke("MenuMove", 0.5f);
        
    }

    void MenuMove()
    {
        StartCoroutine(OffMove());
        if (currentMenu == desiredMenu)
        {
            notInMotion = true;
        }
        
    }
    
    public void ChangeToMenu1()
    {
        desiredMenu = 1;
    }
    public void ChangeToMenu2()
    {
        desiredMenu = 2;
    }
    public void ChangeToMenu3()
    {
        desiredMenu = 3;
    }

    IEnumerator OffMove()
    {
        while (Menus[currentMenu].transform != removedLocation)
        {
            notInMotion = false;
            if (Menus[currentMenu].transform == presentLocation)
            {
                Menus[currentMenu].transform.position = Vector3.MoveTowards(presentLocation.position, transferLocation.position, speed);
            }
            else if (Menus[currentMenu].transform == transferLocation)
            {
                Menus[currentMenu].transform.position = Vector3.MoveTowards(transferLocation.position, removedLocation.position, speed);
            }

            yield return new WaitForSeconds(0.1f);
        }
        StartCoroutine(MoveOn());
        yield return new WaitForSeconds(0.1f);
        Invoke("MenuCheck", 0.5f);
    }
    IEnumerator MoveOn()
    {
        notInMotion = false;
        while (Menus[desiredMenu].transform != presentLocation)
        {
            if (Menus[currentMenu].transform != presentLocation || Menus[currentMenu] != transferLocation)
            {
                Menus[currentMenu].transform.position = Vector3.MoveTowards(removedLocation.position, transferLocation.position, speed);
            }
            else if (Menus[currentMenu].transform == transferLocation)
            {
                Menus[currentMenu].transform.position = Vector3.MoveTowards(transferLocation.position, presentLocation.position, speed);
            }
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(0.1f);
        Invoke("MenuCheck", 0.5f);
    }
}
