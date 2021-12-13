using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ShopPanel : MonoBehaviour
{
    [SerializeField] private TurretBlueprint[] towerPrefabs;

    private GameObject _panel;
    private EventsShopButton eventsShopButton = new EventsShopButton();
    // private Turret[] _towers;
    private BuildManager buildManager;
    public static ShopPanel Instance { get; private set; }

    public GameObject Panel => _panel;

    private void Awake()
    {
        _panel = gameObject;
        Instance = this;
        buildManager = BuildManager.instance;
        // _towers = new Turret[towerPrefabs.Length];
        // gameObject.AddComponent<BuilderController>();
    }

    private void Start()
    {
        for (int i = 0; i < towerPrefabs.Length; i++)
        {
           // _towers[i] = towerPrefabs[i].GetComponent<Turret>();
           CreateShopElement(towerPrefabs[i]);
        }
    }

    private void CreateShopElement(TurretBlueprint turret)
    {
        GameObject newButton =
            new GameObject("Turret", typeof(Image), typeof(Button), typeof(LayoutElement));
        newButton.transform.SetParent(_panel.transform);
        newButton.AddComponent<TurretPrefab>();
        // newButton.GetComponent<TurretPrefab>().Turret = turret;
        newButton.GetComponent<Image>().sprite = turret.spriteTurret;
        RectTransform rc = newButton.GetComponent<RectTransform>();
       
        rc.sizeDelta = new Vector2(5, 50);
        rc.localPosition = new Vector3(rc.localPosition.x, rc.localPosition.y, 2.2f);
        rc.localRotation = Quaternion.Euler(-3.5f, 0f, 0f);
        rc.localScale = new Vector3(25f, 3f, 3.5f);


        GameObject newText = new GameObject("Cost ", typeof(Text));
        newText.transform.SetParent(newButton.transform);
        rc = newText.GetComponent<RectTransform>();
        rc.localPosition = new Vector3(0f, -19f, -1.5f);
        rc.sizeDelta = new Vector2(11, 8.6f);
        rc.localRotation = Quaternion.Euler(0f, 0f, 0f);
        rc.localScale = new Vector3(0.25f, 1, 1.1f);

		// newText.AddComponent<Image>().image = (Sprite) Resources.Load("Sprites/coin");
         newText.GetComponent<Text>().text = turret.cost.ToString();
        newText.GetComponent<Text>().font = (Font) Resources.Load("Fonts/Roboto-Bold");
        newText.GetComponent<Text>().color = Color.yellow;
        newText.GetComponent<Text>().fontSize = 6;
        newText.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        
        
        newButton.GetComponent<Button>().onClick.AddListener(delegate { eventsShopButton.BuildTurret(turret); });
		// TODO: adapt shop class for this
        // newButton.AddComponent<EventsShopButton>();
    }
}