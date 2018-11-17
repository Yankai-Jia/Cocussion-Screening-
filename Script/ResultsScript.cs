using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class ResultsScript : MonoBehaviour{

    public Text DemoTime;
    public Text Test1Time;
    public Text Test2Time;
    public Text Test3Time;
    public Text OverallTime;

    public Text DemoNCount;
    public Text Test1NCount;
    public Text Test2NCount;
    public Text Test3NCount;
    public Text OverallNCount;

    void Start(){
        Results.Init();
      //  Results.SetScore("scene2", "time", "190");
       
        DemoTime.text = Results.GetScore("scene1", "time");
        Test1Time.text = Results.GetScore("scene2", "time");
        Test2Time.text = Results.GetScore("scene2", "time");
        Test3Time.text = Results.GetScore("scene4", "time");
        OverallTime.text = Results.GetScore("overall", "time");

        DemoNCount.text = Results.GetScore("scene1", "ncount");
        Test1NCount.text = Results.GetScore("scene2", "ncount");
        Test2NCount.text = Results.GetScore("scene2", "ncount");
        Test3NCount.text = Results.GetScore("scene4", "ncount");
        OverallNCount.text = Results.GetScore("overall", "ncount");

     }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

        }
      
    }
}
