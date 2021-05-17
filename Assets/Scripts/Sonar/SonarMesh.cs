using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SonarMesh
{
    // Creates sonar mesh
    public SonarMesh(float width, float height, float depth, Transform transform)
    {
        if(width <= 0 || height == 0 || depth <= 0)
        {
            throw new Exception("Could not create SonarSweeper.\nWidth, height or depth is either 0 or lower than 0.");
        }

        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[6];
        int[] triangles = new int[8 * 3];

        // Create vertices
        vertices[0] = new Vector3(0, height / 2, 0);

        vertices[1] = new Vector3(
            0 + depth * Mathf.Sin(0),
            height / 2,
            0 + depth * Mathf.Cos(0));

        vertices[2] = new Vector3(
            0 + depth * Mathf.Sin(width * Mathf.Deg2Rad),
            height / 2,
            0 + depth * Mathf.Cos(width * Mathf.Deg2Rad));

        for (int i = 3; i < vertices.Length; ++i)
        {
            vertices[i] = new Vector3(vertices[i - 3].x, -height / 2, vertices[i - 3].z);
        }

        // Create Triangles
        // Top
        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;
        // Bottom
        triangles[3] = 5;
        triangles[4] = 4;
        triangles[5] = 3;
        // Left upper
        triangles[6] = 0;
        triangles[7] = 3;
        triangles[8] = 1;
        // Right upper
        triangles[9] = 0;
        triangles[10] = 2;
        triangles[11] = 3;
        // Left lower
        triangles[12] = 3;
        triangles[13] = 4;
        triangles[14] = 1;
        // Right lower
        triangles[15] = 5;
        triangles[16] = 3;
        triangles[17] = 2;
        // Back left
        triangles[18] = 4;
        triangles[19] = 2;
        triangles[20] = 1;
        // Back right
        triangles[21] = 4;
        triangles[22] = 5;
        triangles[23] = 2;

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        mesh.RecalculateTangents();

        transform.GetComponent<MeshFilter>().mesh = mesh;
        transform.GetComponent<MeshCollider>().sharedMesh = transform.GetComponent<MeshFilter>().mesh;
    }


}
