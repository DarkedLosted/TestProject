using UnityEngine;
using System.Collections;

public class RegionSelect : MonoBehaviour {
    public Camera cam;
    Color color;
    string test = "None";
    void Start()
    {
        cam = Camera.main;
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

        pixelUV.x *= tex.width;
        pixelUV.y *= tex.height;
        //tex.SetPixel((int)pixelUV.x, (int)pixelUV.y, Color.black);
        tex.Apply();
       
       
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
