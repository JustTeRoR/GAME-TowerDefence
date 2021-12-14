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
   
    private BuildManager buildManager;
    public static ShopPanel Instance { get; private set; }

    public GameObject Panel => _panel;

    private void Awake()
    {
        _panel = gameObject;
        Instance = this;
        buildManager = BuildManager.instance;
    }

    private void Start()
    {
        for (int i = 0; i < towerPrefabs.Length; i++)
        {
            CreateShopElement(towerPrefabs[i]);
        }
    }

    private void CreateShopElement(TurretBlueprint turret)
    {
        GameObject newButton =
            new GameObject("Turret", typeof(Image), typeof(Button), typeof(LayoutElement));
        newButton.transform.SetParent(_panel.transform);
        newButton.AddComponent<TurretPrefab>();
        newButton.GetComponent<Image>().sprite = turret.spriteTurret;
        RectTransform rc = newButton.GetComponent<RectTransform>();
       
        rc.sizeDelta = new Vector2(3, 30);
        rc.localPosition = new Vector3(rc.localPosition.x, rc.localPosition.y, 2.2f);
        rc.localRotation = Quaternion.Euler(-3.5f, 0f, 0f);
        rc.localScale = new Vector3(25f, 3f, 3.5f);


        GameObject newText = new GameObject("Cost ", typeof(Text));
        newText.transform.SetParent(newButton.transform);
        rc = newText.GetComponent<RectTransform>();
        rc.localPosition = new Vector3(0.5f, -19f, -1.5f);
        rc.sizeDelta = new Vector2(40, 20);
        rc.localRotation = Quaternion.Euler(0f, 0f, 0f);
        rc.localScale = new Vector3(0.05f, 1, 1.1f);

		// newText.AddComponent<Image>().image = (Sprite) Resources.Load("Sprites/coin");
         newText.GetComponent<Text>().text = turret.cost.ToString();
        newText.GetComponent<Text>().font = (Font) Resources.Load("Fonts/Roboto-Bold");
        newText.GetComponent<Text>().color = Color.yellow;
        newText.GetComponent<Text>().fontSize = 15;
        newText.GetComponent<Text>().alignment = TextAnchor.MiddleLeft;
        
        
        newButton.GetComponent<Button>().onClick.AddListener(delegate { eventsShopButton.BuildTurret(turret); });
    }
}