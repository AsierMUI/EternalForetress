using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public turretBlueprint standardTurret;
    public turretBlueprint demonTurret;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret Selected");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectDemonTurret()
    {
        Debug.Log("Demon Turret Selected");
        buildManager.SelectTurretToBuild(demonTurret);
    }

}
