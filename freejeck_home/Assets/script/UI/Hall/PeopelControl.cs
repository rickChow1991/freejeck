using UnityEngine;
using System.Collections;
namespace com.iuixi.FreeJeck
{
	public class PeopelControl : MonoBehaviour {

		// Use this for initialization

		private float MouseRot_Y;
		private float WheelRot_Y;
		private float  Rot_Y;
		private float  Rot_Y1;
		[SerializeField] float MouseSpeed=30;
		[SerializeField] float DampMouse0=5;
		[SerializeField] float wheelspeed=500;
		[SerializeField] float DampWheel=20;



		void Start () {
		 
		}
		
		// Update is called once per frame
		void Update () {

			if(Input.GetAxis("Mouse ScrollWheel")!=0)
			{
				WheelRot_Y = Input.GetAxis("Mouse ScrollWheel") * wheelspeed;
				if(WheelRot_Y >0)
					Rot_Y =WheelRot_Y -DampWheel ;
				if(WheelRot_Y <0)
					Rot_Y =WheelRot_Y +DampWheel ;
				transform .Rotate(0,Rot_Y*Time.deltaTime ,0);

			}

			if(Input.GetMouseButton(0)&&Input.GetAxis("Mouse X")!=0)
			{
				MouseRot_Y = Input.GetAxis("Mouse X") * MouseSpeed;
				if(MouseRot_Y >0)
					Rot_Y1 =MouseRot_Y -DampMouse0 ;
				if(MouseRot_Y <0)
					Rot_Y1 =MouseRot_Y +DampMouse0 ;
				transform .Rotate(0,-Rot_Y1*Time.deltaTime ,0);

			}
		
			if(!Input.GetMouseButton(0)&&Rot_Y1>0)
			{
				
				Rot_Y1-=DampMouse0;
				if(Rot_Y1  <=0)
					Rot_Y1 =0;
				transform .Rotate(0,-Rot_Y1*Time.deltaTime ,0);
				
			}
			if(!Input.GetMouseButton(0)&&Rot_Y1 <0)
			{
				
				Rot_Y1+=DampMouse0;
				if(Rot_Y1 >=0)
					Rot_Y1 =0;
				transform .Rotate(0,-Rot_Y1*Time.deltaTime ,0);
			}
			

			if(Input.GetAxis("Mouse ScrollWheel")==0&&Rot_Y>0)
			{
				Rot_Y-=DampWheel*Time.deltaTime;
				if(Rot_Y <=0)
					Rot_Y=0;
				transform .Rotate(0,Rot_Y*Time.deltaTime ,0);
			}
			
			if(Input.GetAxis("Mouse ScrollWheel")==0&&Rot_Y<0)
			{
				Rot_Y+=DampWheel*Time.deltaTime;
				if(Rot_Y >=0)
					Rot_Y=0;
				transform .Rotate(0,Rot_Y*Time.deltaTime ,0);
			}

		}

	}
}