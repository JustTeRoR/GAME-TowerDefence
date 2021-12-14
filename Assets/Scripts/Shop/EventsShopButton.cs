using UnityEngine;
using UnityEngine.EventSystems;

public class EventsShopButton : MonoBehaviour {
	public void BuildTurret(TurretBlueprint turret)
	{
		BuildManager.instance.SelectTurretToBuild(turret);
	}
}
