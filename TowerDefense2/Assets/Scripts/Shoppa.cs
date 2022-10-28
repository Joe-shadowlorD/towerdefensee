using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoppa : MonoBehaviour
{
    BuildManager BuildManager;

    private void Start()
    {
        BuildManager = BuildManager.instance;
    }
    public void SelectCannon()
    {
        Debug.Log("Cannon Selected");
        BuildManager.SetTurretToBuild(BuildManager.CannonPrefab);
    }
    public void SelectMortar()
    {
        Debug.Log("Mortar Selected");
        BuildManager.SetTurretToBuild(BuildManager.MortarPrefab);
    }
}
