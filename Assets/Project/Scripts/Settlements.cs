using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Settlement : MonoBehaviour {

        public Text text; 
        private bool type;
        public Vector3 position;
        public string name;
        public int food;
        public int gold;
        public int population;

    

	void Start () {
        Settlement settlement;
       
            


    }
	

	void Update () {
        RaycastHit hit;
        Settlement[] City = new Settlement[10];
        City[0].name = "London";
        City[0].food = 94;
        City[0].gold = 7523;
        City[0].population = 867;
        Camera cam = Camera.main;
        if (!Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit))
            return;

        if (Input.GetMouseButton(0))
        {
            if(hit.transform.name==City[0].name)
            {
                text.text = "34343";
            }
        }

	}
}
