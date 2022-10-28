using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;

    private GameObject _gameMaster;
    private MoneyManager _moneyManager;

    private GameObject Cannon;

    private Renderer Rend;
    private Color StartColor;

    BuildManager buildManager;

    void Start()
    {
        Rend = GetComponent<Renderer>();
        StartColor = Rend.material.color;

        _gameMaster = GameObject.FindWithTag("GameMaster");
        _moneyManager = _gameMaster.GetComponent<MoneyManager>();

        buildManager = BuildManager.instance;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("wrk");
            buildManager.SetTurretToBuild(null);
        }
        //If{ }
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (buildManager.GetTurretToBuild() == null)
        {
            Debug.Log("A");
            return;
        }



        if (Cannon != null)
        {
            //deze bericht moet op het scherm komen
            Debug.Log("Can't build here!");

            return;
        }

        GameObject turretToBuild = buildManager.GetTurretToBuild();
        turret tur = turretToBuild.GetComponent<turret>();
        if (!_moneyManager.MoneyDeplete(tur.Price))
        {
            return;
        }
        Cannon = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (buildManager.GetTurretToBuild() == null)
            return;
        Rend.material.color = hoverColor;

    }

    void OnMouseExit()
    {

        Rend.material.color = StartColor;
    }
    
    //public void Sell ()
    //{
    //target.SellTurret();
    //BuildManager.instance.DeselectNode();
    //}
}



