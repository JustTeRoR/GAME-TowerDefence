using UnityEngine;
using UnityEngine.EventSystems;

public class EventsShopButton : MonoBehaviour {
	/*
	BuildManager buildManager;

	void Awake()
	{
		buildManager = BuildManager.instance;
	}
*/
	public void BuildTurret(TurretBlueprint turret)
	{
		// buildManager = BuildManager.instance;
		BuildManager.instance.SelectTurretToBuild(turret);
		// buildManager.SelectTurretToBuild(turret);
	}
}
