using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderSystemScript : MonoBehaviour
{

    public GameObject orderTemplate;
    private class ToyOrder
    {
        private string orderName = "";
        private float timeLeft = 0.0f;
        private float timeGiven = 0.0f;
        private GameObject OrderUI;

        private GameObject timeBar;
        private Image render;

        public ToyOrder(string name,float time,GameObject UI)
        {
            orderName = name;
            timeGiven = timeLeft = time;
            OrderUI = UI;

            UI.transform.localPosition = new Vector3(Screen.currentResolution.width / 2, Screen.currentResolution.height / 2);

            UI.transform.GetChild(0).GetComponent<Text>().text = orderName;
            timeBar = UI.transform.GetChild(2).gameObject;
            render = timeBar.GetComponent<Image>();
            UI.SetActive(true);
        }
        public void tick(float delta)
        {
            timeLeft = Mathf.Max(timeLeft - delta, 0.0f);

            float ratio = timeLeft / timeGiven;

            timeBar.transform.localScale = new Vector3(ratio, 1.0f, 1.0f);

            render.color = Color.HSVToRGB((120.0f * ratio % 360.0f) / 360.0f, 1.0f, 1.0f);

        }
        public void moveTo(Vector3 position,float delta)
        {
            Vector3 toward = position - this.OrderUI.transform.localPosition;
            this.OrderUI.transform.localPosition += toward * delta;
        }

        public void delete()
        {
            Destroy(this.OrderUI);
        }
    }

    private List<ToyOrder> orders = new List<ToyOrder>();

    float orderWIDTH = 0.0f;
    float orderHEIGHT = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

        RectTransform rect = orderTemplate.GetComponent<RectTransform>();
        Transform transform = orderTemplate.transform;

        orderWIDTH = (float)rect.rect.width * transform.localScale.x;
        orderHEIGHT = (float)rect.rect.height * transform.localScale.y;

    }

    private string[] toys = new string[3] { "Building Blocks", "Wooden Train", "Teddy Bear" };

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            newOrder(toys[Random.Range(0, toys.Length - 1)], 15.0f);
        }

        if (Input.GetKeyDown(KeyCode.S) && orders.Count > 0)
        {
            orders[0].delete();
            orders.RemoveAt(0);
        }

        

        int WIDTH = Screen.currentResolution.width; //Get the current width of screen, so we can figure out how many orders we can fit in a row.
        int rowCount = Mathf.FloorToInt(WIDTH / orderWIDTH);

        float widthGap = ((float)WIDTH - ((float)rowCount * orderWIDTH)) / ((float)rowCount - 1.0f);

        int HEIGHT = Screen.currentResolution.height; //Get the height too.

        for(int i = Mathf.Min(orders.Count - 1,rowCount - 1); i > -1; i--)
        {

            //Figure out which position this order gotta slide to.
            float x = (float)(WIDTH / -2) + (float)(i % rowCount) * (orderWIDTH + widthGap);
            float y = (float)(HEIGHT / 2) - Mathf.Floor((float)i / (float)rowCount) * orderHEIGHT;

            //Make it move to the appropriate position.
            orders[i].moveTo(new Vector3(x, y, 0.0f), Time.deltaTime * 4.0f);

            //Do its tick logic.
            orders[i].tick(Time.deltaTime);
        }

    }

    public void newOrder(string name, float time)
    {

        ToyOrder order = new ToyOrder(name, time, Instantiate(orderTemplate, orderTemplate.transform.parent));
        orders.Add(order);

    }

    public void deleteOrders()
    {
        for(int i = orders.Count - 1; i > -1; i--)
        {
            orders[i].delete();
            orders.RemoveAt(i);
        }
    }

}
