using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SetVertexColors : MonoBehaviour
{

    public Color ColorTop;
    public Color ColorSide;
    public Color ColorBottom;
    // Use this for initialization
    void Start()
    {
        SetColors();
    }
    void SetColors()
    {
        var mesh = GetComponent<MeshFilter>().mesh;
        var vertices = new List<Vector3>();
        var normals = new List<Vector3>();

        mesh.GetVertices(vertices);
        mesh.GetNormals(normals);
        var colors = new Color[vertices.Count];

        for (var i = 0; i < vertices.Count; i++)
        {
            if (normals[i] == Vector3.up)
            {
                colors[i] = ColorTop;
            }
            else if (normals[i] == Vector3.down)
            {
                colors[i] = ColorBottom;
            }
            else
            {
                colors[i] = ColorSide;
            }
        }
        mesh.SetColors(colors.ToList());
    }
   
}
