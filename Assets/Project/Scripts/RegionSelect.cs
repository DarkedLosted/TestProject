using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class RegionSelect : MonoBehaviour {
    public Camera cam;
    public Text text;
    public Text text1;
    public GameObject cube;
 
    Color color;
    string test = "None";
    
    Color testt;
    
    void Start()
    {
        cam = Camera.main;
        RaycastHit hit;

        if (!Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit))
            return;
        Renderer rend = hit.transform.GetComponent<Renderer>();
        Texture2D tex = rend.material.mainTexture as Texture2D;

        Color[] pixels = tex.GetPixels(0, 0, tex.width, tex.height, 0);

       
        int x, y;
        
        for (int i = 0; i < pixels.Length; i++)
        {


            if (Color.blue == pixels[i])
            {

                x = i / tex.height;
                y = i % tex.width;
              
                text1.text = "y:" + y.ToString() + " x: " + x.ToString() + "  i:" + i.ToString();
                GameObject ob = new GameObject();
               // ob = Instantiate(cube, gameObject.transform.localPosition = new Vector3(x/760, 2, y/ 760), transform.rotation) as GameObject;

                
                var p = transform.position=new Vector3(x/ 19.493087557603686635944700460829f, 2, y/ 20.27863777089783281733746130031f);
                GameObject.CreatePrimitive(PrimitiveType.Sphere).transform.position = p;

            }

        }

    }
    void Update()
    {
        if (!Input.GetMouseButton(0))
            return;

        RaycastHit hit;
        if (!Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit))
            return;

        Renderer rend = hit.transform.GetComponent<Renderer>();
        MeshCollider meshCollider = hit.collider as MeshCollider;
        if (rend == null || rend.sharedMaterial == null || rend.sharedMaterial.mainTexture == null || meshCollider == null)
            return;
        
        Texture2D tex = rend.material.mainTexture as Texture2D;
      
        Vector2 pixelUV = hit.textureCoord;
        
        color = tex.GetPixelBilinear(hit.textureCoord2.x, hit.textureCoord2.y);
        text1.text=hit.point.ToString();
        pixelUV.x *= tex.width;
        pixelUV.y *= tex.height;
        //tex.SetPixel((int)pixelUV.x, (int)pixelUV.y, Color.black);
        tex.Apply();

        if (Color.blue == color)
        {
            text.text = "France";
        }
        if (Color.red == color)
        {
            text.text = "England";
        }
        if (Color.green == color)
        {
            text.text = "Restricted area";
        }
        if (Color.black == color)
        {
            text.text = "Sea "+ hit.textureCoord2.x+"TT "+ hit.textureCoord2.y;
        }
       
    }
    void OnGUI()
    {

        if (Color.blue == color)
        {
            test = "blue";
        }
        if (Color.red == color)
        {
            test = "red";
        }
        if (Color.green == color)
        {
            test = "green";
        }
        if (Color.black == color)
        {
            test = "black";
        }
        GUIStyle myStyle = new GUIStyle();
        myStyle.fontStyle = FontStyle.Italic;
        myStyle.normal.textColor = Color.yellow;
        GUI.Label(new Rect(10, 10, 400, 40), "Color: " + test, myStyle);
        

    }
}
