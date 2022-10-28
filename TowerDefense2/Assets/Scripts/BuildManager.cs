using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("MORE THAN ONE BUILDMANAGER IN THIS SCENE!!!!");
            return;
        }
        instance = this;
    }
    public GameObject CannonPrefab;
    public GameObject MortarPrefab;

   public void SetTurretToBuild(GameObject turret)
    {
        TurretToBuild = turret;
    }
    private GameObject TurretToBuild;
    //public GameObject sellEffect;

    public GameObject GetTurretToBuild()
    {
        return TurretToBuild;
    }
}
