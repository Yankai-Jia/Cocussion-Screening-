using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class crossHair : MonoBehaviour {
    IDictionary<string, int> dict = new Dictionary<string, int>();
    public Camera CameraFacing;
    [SerializeField] private LayerMask m_ExclusionLayers;
    private GameDataBus gameDatabus;
    [SerializeField] private float m_RayLength = 300f;
    // Use this for initialization
    void Start () {

        dict.Add("Scene1", 1);
        dict.Add("Scene2", 2);
        dict.Add("Scene3", 3);
        dict.Add("Scene4", 4);
	}

    void Awake()
    {
        gameDatabus = GameDataBus.FindObjectsOfType<GameDataBus>()[0];
    }

    // Update is called once per frame
    void Update () {
        transform.position = CameraFacing.transform.position +
                           CameraFacing.transform.rotation * Vector3.forward * 60f;
        transform.LookAt(CameraFacing.transform.position);
        transform.Rotate(0.0f, 180.0f, 0.0f);

        RaycastHit hit;

        if(Physics.Raycast (new Ray ( CameraFacing.transform.position,
                                CameraFacing.transform.rotation * Vector3.forward),
                            out hit, m_RayLength, m_ExclusionLayers)){

            Debug.Log(hit.collider.gameObject.name);
            if(hit.collider.gameObject.tag == "Player")
            {

                string objValue = transform.GetComponent<Renderer>().material.name;
                if (gameDatabus.isContinue() == 1)
                {
                    string objName = hit.collider.gameObject.name;

                    int result = gameDatabus.checkObject(objName);

                    if( result == 1)
                    {
                        transform.GetComponent<Renderer>().material.color = Color.green;
                    }
                    else
                    {
                        transform.GetComponent<Renderer>().material.color = Color.red;
                    }

                    int incorrectCount = gameDatabus.returnWrongViewCount();

                }
                Debug.Log("hit number target");
            }
            else
            {
                transform.GetComponent<Renderer>().material.color = Color.blue;
                Debug.Log("hit not number target");
            }
            string objectName = hit.collider.gameObject.name;
            string[] ObjArray = objectName.Split('a');
            if (ObjArray[0] == "0")
            {
                Scene currentScene = SceneManager.GetActiveScene();
                change_scene(currentScene.name);

                Debug.Log("hit menu");
            }

        }
        else
        {
            transform.GetComponent<Renderer>().material.color = Color.blue;
        }
    }

    void change_scene(string activeScene)
    {
        Debug.Log(dict[activeScene]);
        switch (dict[activeScene])
        {
            case 1:
                SceneManager.LoadScene("Scene2");
                break;
            case 2:
                SceneManager.LoadScene("Scene3");
                break;
            case 3:
                SceneManager.LoadScene("Scene4");
                break;
            case 4:
                SceneManager.LoadScene("Results");
                break;
            default:
                SceneManager.LoadScene("Main");
                break;
        }
    }
    void changeColor(Color color)
    {
        //Fetch the Renderer from the GameObject
        Renderer rend = GetComponent<Renderer>();

        //Set the main Color of the Material to green
        rend.material.color = color;
    }
}
