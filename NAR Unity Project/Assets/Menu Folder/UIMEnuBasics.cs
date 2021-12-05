using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMEnuBasics : MonoBehaviour
{
    
    public int currentMenu = 2;
    [SerializeField]
    GameObject[] Menus;
   
    public int desiredMenu = 2;
    public Transform removedLocation;
    public Transform presentLocation;
    public Transform transferLocation;
    [SerializeField]
    float speed = 7f;
    
    bool notInMotion;

    bool halfWay;
    

    void Start()
    {
        Menus = GameObject.FindGameObjectsWithTag("Menu");

        notInMotion = true;
    }
    public void ChangeToMenu1()
    {
        desiredMenu = 0;
        if (notInMotion == true)
        {
            StartCoroutine(OffMove());
        }
    }
    public void ChangeToMenu2()
    {
        desiredMenu = 1;
        if (notInMotion == true)
        {
            StartCoroutine(OffMove());
        }
    }
    public void ChangeToMenu3()
    {
        desiredMenu = 2;
        if (notInMotion == true)
        {
            StartCoroutine(OffMove());
        }
    }

    IEnumerator OffMove()
    {
        if (desiredMenu != currentMenu)
        {
            if (Menus[currentMenu].transform.position != removedLocation.position)
            {
                if (Menus[currentMenu].transform.position != removedLocation.position && halfWay == true)
                {
                    
                    Menus[currentMenu].transform.position = Vector3.MoveTowards(Menus[currentMenu].transform.position, removedLocation.position, speed);
                    yield return new WaitForSeconds(0.05f);
                    StartCoroutine(OffMove());
                }
                else if (Menus[currentMenu].transform.position == transferLocation.position)
                {
                    halfWay = true;
                    StartCoroutine(OffMove());
                }
                else if (Menus[currentMenu].transform.position != removedLocation.position && halfWay == false)
                {
                    
                    notInMotion = false;
                    Menus[currentMenu].transform.position = Vector3.MoveTowards(Menus[currentMenu].transform.position, transferLocation.position, speed);
                    yield return new WaitForSeconds(0.05f);
                    StartCoroutine(OffMove());
                }
                yield return new WaitForSeconds(0.05f);
            }
            else if (Menus[currentMenu].transform.position == removedLocation.position)
            {
                halfWay = false;
                StartCoroutine(MoveOn());
            }
        }
        yield return new WaitForSeconds(0.1f);
        
    }
    IEnumerator MoveOn()
    {
        
        if (Menus[desiredMenu].transform.position != presentLocation.position)
        {
            
            if (Menus[desiredMenu].transform.position != presentLocation.position && halfWay == true)
            {
                
                Menus[desiredMenu].transform.position = Vector3.MoveTowards(Menus[desiredMenu].transform.position, presentLocation.position, speed);
                yield return new WaitForSeconds(0.05f);
                StartCoroutine(MoveOn());

            }
            else if (Menus[desiredMenu].transform.position == transferLocation.position)
            {
                halfWay = true;
                StartCoroutine(MoveOn());
            }
            else if (Menus[desiredMenu].transform.position != presentLocation.position && halfWay == false)
            {
                notInMotion = false;
                Menus[desiredMenu].transform.position = Vector3.MoveTowards(Menus[desiredMenu].transform.position, transferLocation.position, speed);
                yield return new WaitForSeconds(0.05f);
                StartCoroutine(MoveOn());
            }
            
            yield return new WaitForSeconds(0.05f);
        }
        else if(Menus[desiredMenu].transform.position == presentLocation.position)
        {
            notInMotion = true;
            halfWay = false;
            currentMenu = desiredMenu;
        }
        yield return new WaitForSeconds(0.05f);
        
    }
}
