using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public int speed;
    private Vector3 _scale_reduction = new Vector3(0.1f, 0, 0.1f);

    // Start is called before the first frame update
    void Start()
    {

        speed = 3;

        MeshFilter filter = GetComponent(typeof(MeshFilter)) as MeshFilter;
        if (filter != null)
        {
            Mesh mesh = filter.mesh;

            Vector3[] normals = mesh.normals;
            for (int i = 0; i < normals.Length; i++)
                normals[i] = -normals[i];
            mesh.normals = normals;

            for (int m = 0; m < mesh.subMeshCount; m++)
            {
                int[] triangles = mesh.GetTriangles(m);
                for (int i = 0; i < triangles.Length; i += 3)
                {
                    int temp = triangles[i + 0];
                    triangles[i + 0] = triangles[i + 1];
                    triangles[i + 1] = temp;
                }
                mesh.SetTriangles(triangles, m);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Shrink");
        //float step = speed * Time.deltaTime;

        //Vector3 temp_bubble_visual = transform.localScale - _scale_reduction;
        //transform.localScale = new Vector3(temp_bubble_visual.x,
        //                                                 temp_bubble_visual.y,
        //                                                 temp_bubble_visual.z);
        //transform.localScale = Vector3.MoveTowards(transform.position, new Vector3(0, 0, 0), step);
    }
}
