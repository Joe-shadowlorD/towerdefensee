using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;

    private GameObject Cannon;

    private Renderer Rend;
    private Color StartColor;

    void Start()
    {
        Rend = GetComponent<Renderer>();
        StartColor = Rend.material.color;
    }

    void OnMouseDown()
    {
        if(Cannon != null)
        {
            //deze bericht moet op het scherm komen
            Debug.Log("Can't build here!");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        Cannon = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }
    void OnMouseEnter()
    {
        Rend.material.color = hoverColor;

    }

    void OnMouseExit()
    {
        Rend.material.color = StartColor;
    }
}
