//using UnityEngine;
//using System.Collections;
//
//public class Vecter
//{
//    string name;
//	float xx;
//    public Vecter(string tempName)
//    {
//        name = tempName;
//    }
//}
//
//public class TeachEqual : MonoBehaviour
//{
//
//    // Use this for initialization
//    void Start()
//    {
//
//       
//    }
//
//	//按值传递值 类型
//	public void Food(int x) 
//	{
//		x = 10;
//	}
//
//	public void Food2()
//	{
//	}
//
//	public void Food4(Vecter tempVect2)
//	{
//		Vecter tempVect = new Vecter (10);
//		tempVect2 = tempVect;
//	}
//
//	void TestEqual()
//	{
//		string tempA = new string(new char[] { 'H','L'});
//		string tempB = new string(new char[] { 'H', 'L'});
//		
//		Debug.Log(tempA == tempB);
//		
//		Debug.Log(tempA.Equals(tempB));
//		
//		object tempC = tempA;
//		object tempD = tempB;
//		
//		Debug.Log(tempC == tempD);
//		Debug.Log(tempC);
//		
//		Debug.Log(tempC.Equals(tempD));
//		
//		Debug.Log("Test Vecter");
//		
//		Vecter tempOne = new Vecter("Hello");
//		Vecter tempTwo = new Vecter("Hello");
//		
//		Debug.Log(tempOne == tempTwo);
//		Debug.Log(tempOne.Equals(tempTwo));
//
//		Vecter tempVect = new Vecter (1);
//
//		Food4 (tempVect);
//		Debug.Log("vector=="+tempVect.)
//	}
//
//    // Update is called once per frame
//    void Update()
//    {
//
//    }
//}
