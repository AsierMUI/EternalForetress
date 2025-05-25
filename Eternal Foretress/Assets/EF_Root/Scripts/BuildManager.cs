using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            return;
        }
        instance = this;
    }

    public GameObject demonTurretPrefab;
    public GameObject standardTurretPrefab;

    

    private turretBlueprint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }


    public void BuildTurretOn(Node node)
    {
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
    }


    public void SelectTurretToBuild(turretBlueprint turret)
    {
        turretToBuild = turret;
    }

}
