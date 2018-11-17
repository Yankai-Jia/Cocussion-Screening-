using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public Transform eyePosition;
    public GameObject spawnee;
    public Texture[] textures;

    public GameObject lineGerneratorPrefab;

    private static float height = 30.0f;
    private static float width = 70.0f;
    private static float distanceFromEye = 20.0f;

    public int currentScene;
    private double[,] pos;
    private double[,] rot;
    private double[,] dis;
    private double rot_unit = 50 / 0.5;
    private double rot_degree = 0;

    private GameDataBus gameDatabus;

    // positions for the number

    private double[,] scene1 = new double[,] {{0, 0.2,  0.5, 0.67,  1 },
                                           {0, 0.26,  0.45, 0.73, 1},
                                           {0, 0.175, 0.45, 0.7, 1},
                                           {0, 0.2,  0.5, 0.76,  1 },
                                           {0, 0.3, 0.72, 0.8, 1 }};

    //private double[,] scene1_rot = new double[,] {{50, 37, 0, -25, -50 },
                                           //{50, 35, 5, -35, -50},
                                           //{50, 40, 5, -32, -50},
                                           //{50, 40, 0, -35, -50},
                                           //{50, 28, -27, -35, -50}};
    private double[,] scene1_dis = new double[,] {{0, 1, 2, 1, 0 },
                                           {0, 1, 2, 1, 0 },
                                           {0, 1, 2, 1, 0 },
                                           {0, 1, 2, 1, 0 },
                                           {0, 1, 1.5, 1, 0 }};


    private double[,] scene2 = new double[,] {{0, 0.3,  0.56, 0.73,  1 },
                                           {0, 0.15,  0.4, 0.73, 1},
                                           {0, 0.24, 0.57, 0.79, 1},
                                           {0, 0.3,  0.53, 0.69,  1 },
                                           {0, 0.17, 0.45, 0.73, 1 },
                                           {0, 0.3, 0.52, 0.77, 1 },
                                           {0, 0.15, 0.42, 0.68, 1 },
                                           {0, 0.33, 0.61, 0.75, 1 },};

    //private double[,] scene2_rot = new double[,] {{50, 30, -3, -35, -50},
                                           //{50, 45, 7, -35, -50},
                                           //{50, 35, -3, -38, -50},
                                           //{50, 30, 0, -30, -50},
                                           //{50,45, 3, -35, -50},
                                           //{50, 30, 0, -35, -50},
                                           //{50, 45, 5, -30, -50},
                                           //{50, 25, -8, -35, -50}};

    private double[,] scene2_dis = new double[,] {{0, 1, 2, 1, 0 },
                                           {0, 1, 2, 1, 0 },
                                           {0, 1, 2, 1, 0 },
                                           {0, 1, 2, 1, 0 },
                                           {0, 1, 2, 1, 0},
                                           {0, 1, 2, 1, 0 },
                                           {0, 1, 2, 1, 0 },
                                           {0, 1, 2, 1, 0 }};

    private double[,] scene3 = new double[,] {{0, 0.25,  0.45, 0.63,  1 },
                                           {0, 0.23,  0.4, 0.66, 1},
                                           {0, 0.17, 0.45, 0.75, 1},
                                           {0, 0.3,  0.62, 0.76,  1 },
                                           {0, 0.17, 0.45, 0.69, 1 },
                                           {0, 0.32, 0.55, 0.64, 1 },
                                           {0, 0.18, 0.45, 0.69, 1 },
                                           {0, 0.28, 0.55, 0.64, 1 },};

    //private double[,] scene3_rot = new double[,] {{50, 35, 5, -25, -50 },
                                           //{50, 35, 10, -26, -50},
                                           //{50, 43, 5, -35, -50},
                                           //{50, 30, -12, -35, -50},
                                           //{50, 43, 5, -40, -50},
                                           //{50, 28, -5, -43, -50 },
                                           //{50, 43, 5, -40, -50 },
                                           //{50, 33, -5, -44, -50 }};
    private double[,] scene3_dis = new double[,] {{0, 1, 2, 1.5, 0 },
                                           {0, 1, 2, 1, 0 },
                                           {0, 1, 2, 1, 0 },
                                           {0, 1, 1.5, 1, 0 },
                                           {0, 1, 2, 1, 0},
                                           {0, 1, 2, 1, 0 },
                                           {0, 1, 2, 1, 0 },
                                           {0, 1, 2, 1, 0 }};


    private double[,] scene4 = new double[,] {{0, 0.26,  0.43, 0.69,  1 },
                                           {0, 0.18,  0.53, 0.75, 1},
                                           {0, 0.27, 0.63, 0.72, 1},
                                           {0, 0.19,  0.45, 0.75,  1 },
                                           {0, 0.25, 0.53, 0.7, 1 },
                                           {0, 0.32, 0.45, 0.73, 1 },
                                           {0, 0.13, 0.52, 0.78, 1 },
                                           {0, 0.3, 0.53, 0.69, 1 },};

    //private double[,] scene4_rot = new double[,] {{50, 35, 7, -40, -50 },
                                           //{50, 44, -3, -35, -50},
                                           //{50, 35, -13, -32, -50},
                                           //{50, 40, 5, -35, -50},
                                           //{50, 35, -3, -30, -50},  
                                           //{50, 28, 5, -32, -50 },
                                           //{50, 48, -2, -38, -50 }, 
                                           //{50, 30, -3, -29, -50 }};
    private double[,] scene4_dis = new double[,] {{0, 1, 2, 1, 0 },
                                           {0, 1, 2, 1, 0 },
                                           {0, 1, 2, 1, 0 },
                                           {0, 1, 2, 1, 0 },
                                           {0, 1, 2, 1, 0},
                                           {0, 1, 2, 1, 0 },
                                           {0, 1, 2, 1, 0 },
                                           {0, 1.5, 2, 1, 0 }};


    // offset location from the eye position
    private Vector3 offset = new Vector3(-width / 2.0f, height / 2.0f, distanceFromEye);

    // Use this for initialization
    void Start()
    {
        select_scene();

        GameObject newLineGen = Instantiate(lineGerneratorPrefab);
        LineRenderer lRend = newLineGen.GetComponent<LineRenderer>();
        lRend.positionCount = pos.Length;
        int index = 0;
        // for data bus
        List<string> nameList = new List<string>();
        List<int> valueList = new List<int>();

        for (int i = 0; i < pos.GetLength(0); i++)
        {
            GameObject newLineGen_2 = Instantiate(lineGerneratorPrefab);
            LineRenderer lRend_2 = newLineGen_2.GetComponent<LineRenderer>();
            lRend_2.positionCount = pos.GetLength(1);

            for (int j = 0; j < pos.GetLength(1); j++)
            {
                // new number cube location diff from offset
                Vector3 vec = new Vector3(width * (float)pos[i, j], -height * i / pos.GetLength(0), (float)dis[i,j]);
                // final position after add all adjustment.
                Vector3 newPos = eyePosition.position + vec + offset;

                // generate number object
                GameObject projectile = Instantiate(spawnee, newPos, eyePosition.rotation);
                rotation_degree((float)pos[i, j]);
                projectile.transform.rotation = Quaternion.Euler(0, (float)rot_degree, 180);
                //projectile.transform.rotation = Quaternion.Euler(0, (float)rot[i,j], 180);
                //projectile.transform.rotation = Quaternion.Euler(0, 0, 180);

                // apply texture
                int texture_index = Random.Range(0, 10);
                projectile.GetComponent<Renderer>().material.mainTexture = textures[texture_index];

                // add canvas to be number parent
                string name = index.ToString() + 'a' + texture_index.ToString();
                projectile.name = name;

                // store object id and value to Databus
                nameList.Add(name);

                if (currentScene == 1)
                {
                    lRend.SetPosition(index, newPos);
                }
                if(currentScene == 2)
                {
                    lRend_2.SetPosition(index, newPos);
                }

                index++;
            }
        }

        gameDatabus = GameDataBus.FindObjectsOfType<GameDataBus>()[0];
        gameDatabus.InitializedData(nameList, valueList);
    }

    void select_scene()
    {
        switch (currentScene)
        {
            case 1:
                pos = scene1;
                //rot = scene1_rot;
                height = 60.0f;
                dis = scene1_dis;
                break;
            case 2:
                pos = scene2;
                //rot = scene2_rot;
                height = 35.0f;
                dis = scene2_dis;
                break;
            case 3:
                pos = scene3;
                height = 35.0f;
                //rot = scene3_rot;
                dis = scene3_dis;
                break;
            default:
                pos = scene4;
                height = 20.0f;
                //rot = scene4_rot;
                dis = scene4_dis;
                break;
        }
    }

    void rotation_degree(float position)
    {
        if (position == 0)
        {
            rot_degree = -50;
        }
        if (position > 0 && position < 0.5)
        {
            rot_degree = -(50-rot_unit * position);
        }
        if (position == 0.5)
        {
            rot_degree = 0;
        }
        if (position >= 0.5 && position < 1)
        {
            rot_degree = 50-rot_unit * (1 - position);
        }
        if (position == 1)
        {
            rot_degree = 50;
        }

        else
        {
            print(" error ");
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

        }

    }
}
