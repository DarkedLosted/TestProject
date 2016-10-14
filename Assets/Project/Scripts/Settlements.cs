using UnityEngine;
using System.Collections;

public class Fort : MonoBehaviour {



    public class Settlement
    {
        private bool type;
        private Vector3 position;
        private string name;
    }

    class Castle: Settlement
    {
        public bool SetType(bool type)
        {
            return type;
        }
    }

    class City: Settlement
    {

    }

	void Start () {
        Settlement settlement;
        Castle castle = new Castle();
        castle.SetType(true);

      

        
    }
	
	void Update () {
	    
	}
}
