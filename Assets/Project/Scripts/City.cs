using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class City : MonoBehaviour {

    public Text citynametext;
    public Text foodtext;
    public Text goldtext;
    public Text populationtext;
    private bool type;
    public Vector3 position;
 

    struct internals
    {
        public string cityname;
        public int food;
        public int gold;
        public int population;
    }
    internals[] Cityy = new internals[5];

    // Use this for initialization
    void Start () {
        
        init(Cityy);
    }
	
    void init(internals[] City)
    {
       

        string[] Citynames = { "London", "Leeds", "Manchester", "Liverpool", "Cambridge" };


            for (int i = 0; i < City.Length; i++)
            {

                City[i].food = (int)Random.Range(10f, 100f);
                City[i].gold = (int)Random.Range(1000f, 10000f);
                City[i].population = (int)Random.Range(100f, 1000f);
                City[i].cityname = Citynames[i];
            }
      
    }

	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        
        Camera cam = Camera.main;
        if (!Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit))
            return;
        
        if (Input.GetMouseButton(0))
        {
            for (int i = 0; i < Cityy.Length; i++)
            {
                if (hit.transform.name == Cityy[i].cityname)
                {
                    citynametext.text = "CityName:" + Cityy[i].cityname;
                    foodtext.text = "Food:" + Cityy[i].food.ToString();
                    goldtext.text = "Gold:" + Cityy[i].gold.ToString();
                    populationtext.text = "Population:" + Cityy[i].population.ToString();

                }
            }
        }

    }

    
}
