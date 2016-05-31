using UnityEngine;
using System.Collections;

public class Vecter
{
    string name;
    public Vecter(string tempName)
    {
        name = tempName;
    }
}

public class TeachEqual : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

       
    }

	//按值传递值 类型
	public void Food(int x) 
	{
		x = 10;
	}

	public void Food2()


	void TestEqual()
	{
		string tempA = new string(new char[] { 'H','L'});
		string tempB = new string(new char[] { 'H', 'L'});
		
		Debug.Log(tempA == tempB);
		
		Debug.Log(tempA.Equals(tempB));
		
		object tempC = tempA;
		object tempD = tempB;
		
		Debug.Log(tempC == tempD);
		Debug.Log(tempC);
		
		Debug.Log(tempC.Equals(tempD));
		
		Debug.Log("Test Vecter");
		
		Vecter tempOne = new Vecter("Hello");
		Vecter tempTwo = new Vecter("Hello");
		
		Debug.Log(tempOne == tempTwo);
		Debug.Log(tempOne.Equals(tempTwo));
	}

    // Update is called once per frame
    void Update()
    {

    }
}
