using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMesh : MonoBehaviour
{
    // Start is called before the first frame update
    /// 
    /// How to do this: https://www.youtube.com/watch?v=IYMQ2ErFz0s&ab_channel=AaronHibberd

    public Vector3 vertLeftTopFront = new Vector3(-1, 1, 1);
    public Vector3 vertRightTopFront = new Vector3(1, 1, 1);
    public Vector3 vertRightTopBack = new Vector3(1, 1, -1);
    public Vector3 vertLeftTopBack = new Vector3(-1, 1, -1);
    void Start()
    {
        MeshFilter mf = GetComponent<MeshFilter>();
        Mesh mesh = mf.mesh;

        // Verticies // 
        // front face (back looks the same)
        /*  --------------
         *  |1          0|
         *  |            |
         *  |            |
         *  |            |
         *  |            |
         *  |3          2|
         *  --------------
         */

        Vector3[] vertices = new Vector3[] // how to fill elements in an array!! This is super cool!
        {
            // front face 
            //left top front (-1,1,1) -1 means the left of the cube [when facing the same direction as the cube], 1 for the y because it is on the top and 1 for z because it is forward 
            //right top front (1,1,1)
            //left bottom front (-1,-1,1)
            //right bottom front (1,-1,1)
            vertLeftTopFront, // left top front 0    used to be: new Vector3(-1, 1, 1); this is origin of the cube 
            vertRightTopFront, // right top front 1     used to be: new Vector3(1,1,1); 
            new Vector3(-1,-1,1), // left bottom front 2
            new Vector3(1,-1,1), // right bottom front 3

            //back face 
            vertRightTopBack, // right top back 4     used to be: new Vector3(1,1,-1)
            vertLeftTopBack, // left top back 5    used to be: new Vector3(-1,1,-1)
            new Vector3(1,-1,-1), // right bottom back 6
            new Vector3(-1,-1,-1), // left bottom back 7

            //left face
            vertLeftTopBack, //left top back 8
            vertLeftTopFront, // left top front 9
            new Vector3(-1,-1,-1), // left bottom back 10
            new Vector3(-1,-1,1), // left bottom front 11

            //right face 
            vertRightTopFront,//right top front 12
            vertRightTopBack,//right top back 13
            new Vector3(1,-1,1),//right bottom front 14 
            new Vector3(1,-1,-1),// right bottom back 15

            //top face 
            vertLeftTopBack, // left top back 16 
            vertRightTopBack, // right top back 17
            vertLeftTopFront, // left top front 18
            vertRightTopFront, // right top front 19

            //bottom face
            new Vector3(-1,-1,1), //left bottom front 20 
            new Vector3(1,-1,1), // right bottom front 21
            new Vector3(-1,-1,-1), //left bottom back 22
            new Vector3(1,-1,-1) //right bottom back 23

        };

        //Triangles: 3 points clockwise determines what side is visible 
        int[] triangles = new int[]
        {
            //front face, first triangle, these are the indexes of the verticies we made earlier 
            0,2,3,
            3,1,0,//front face, second triangle 

            // for the rest of these trianges, just add 4:  back face 
            4,6,7,
            7,5,4,

            8,10,11, //left face 
            11,9,8,

            12,14,15, // right face 
            15,13,12,

            16,18,19, // top face 
            19,17,16,

            20,22,23, // bottom face 
            23,21,20

        };

        // UVs // (0,0) bottom left and (1,1) top right
        Vector2[] uvs = new Vector2[] {
            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0),

            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0),

            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0),

            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0),

            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0),

            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0)
        };

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.Optimize();
        mesh.RecalculateNormals(); // this is for lighting (Thank goodness Unity does this)
    }
}
