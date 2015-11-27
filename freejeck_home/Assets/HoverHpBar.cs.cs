using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HoverHpBar : MonoBehaviour
{
	
	private Transform myTransform;
	
	public GameObject hpBar;
	
	public float curHp = 1500;
	
	public float maxHp = 1500;
	
	private Text showText;
	
	void Start()
	{
		myTransform = transform;
		
		hpBar = Instantiate(hpBar, myTransform.position, Quaternion.identity) as GameObject;
		
		showText = hpBar.transform.FindChild("UIText").gameObject.GetComponent<Text>();
		
		GameObject hpMgr = GameObject.Find("HpMgr");
		
		hpBar.transform.SetParent(hpMgr.transform);
	}
	
	void Update()
	{
		UpdateHpInfo();
		print (Vector3.up);
	}
	
	void UpdateHpInfo()
	{
		Vector3 postion = Camera.main.WorldToScreenPoint(myTransform.position + Vector3.up);//坐标转换就是用它实现的
		hpBar.transform.position = postion;
		
		Scrollbar scrollBar = hpBar.GetComponent<Scrollbar>();
		float size = maxHp == 0 ? 0 : curHp / maxHp;
		scrollBar.size = size;
		showText.text = string.Format("{0}/{1}", curHp, maxHp);
		
		//hpBar是独立的UI对象,不是游戏对象的子对象或附加组件，所以当你攻击的怪死亡后，需要主动销毁hpBar
		if (curHp <= 0)
		{
			Destroy(hpBar, 2);
		}
	}
}