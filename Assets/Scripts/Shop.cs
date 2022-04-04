using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurrentBlueprint standardTurret;
    public TurrentBlueprint missileTurret;
    public TurrentBlueprint mageTower;
    public TurrentBlueprint laserTower;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        buildManager.SelectTurretToBuild(standardTurret);
    }
    public void SelectMissileTurret()
    {
        buildManager.SelectTurretToBuild(missileTurret);
    }
    public void SelectMageTower()
    {
        buildManager.SelectTurretToBuild(mageTower);
    }
    public void SelectLaserTower()
    {
        buildManager.SelectTurretToBuild(laserTower);
    }
}
