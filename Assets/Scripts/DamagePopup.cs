using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class DamagePopup : MonoBehaviour {

	//目标位置
	private Vector3 mTarget;
	//屏幕坐标
	private Vector3 mScreen;
	//伤害数值
	public string Value;



	//文本宽度
	public float ContentWidth=100;
	//文本高度
	public float ContentHeight=50;

	//GUI坐标
	private Vector2 mPoint;

	//销毁时间
	public float FreeTime=1.5F;

	private GameObject popDamageText;
	DamageText popText;
	//private Text


	void Start () 
	{
		//popDamageText = GameObject.FindGameObjectWithTag ("PopupDamage");
		//popDamageText.SetActive (true);
		//获取目标位置
		mTarget=transform.position;
		//获取屏幕坐标
		mScreen= Camera.main.WorldToScreenPoint(mTarget);
		//将屏幕坐标转化为GUI坐标
		mPoint=new Vector2(mScreen.x,Screen.height-mScreen.y);
		//开启自动销毁线程
		StartCoroutine("Free");
	}

	void Update()
	{
		//使文本在垂直方向山产生一个偏移
		transform.Translate(Vector3.up * 0.5F * Time.deltaTime);
		//重新计算坐标
		mTarget=transform.position;
		//获取屏幕坐标
		mScreen= Camera.main.WorldToScreenPoint(mTarget);
		//将屏幕坐标转化为GUI坐标
		mPoint=new Vector2(mScreen.x,Screen.height-mScreen.y);

		//popDamageText.GetComponent<Text>().text = "+1";
		//GameObject mObject = (GameObject)Instantiate (popDamageText,transform.position,Quaternion.identity );

		//Debug.Log ("11111111");
		//popText = popDamageText.GetComponent<DamageText> ();
		//popText.showPopupContent("++1", mScreen.x, mScreen.y);  


	}

	void OnGUI()
	{		
		//保证目标在摄像机前方
		//if(mScreen.z>0)
		{
			//GUISkin skin = new GUISkin ();
			//skin.label
			GUIStyle style = new GUIStyle ();
			//style.font = (Font)Resources.Load ("RAVIE");
			//style.font = (Font)Resources.Load ("Jupiter");
			style.fontSize = 50;
			//style.fontStyle = FontStyle.Bold;
			style.fontStyle = FontStyle.BoldAndItalic;
			//style.font.material
			style.normal.textColor = Color.green;
			style.alignment = TextAnchor.MiddleCenter;

			//style.normal.textColor = new Color (222f/256f, 11f/256f, 60f/256f);

		   //内部使用GUI坐标进行绘制
		   GUI.Label(new Rect(mPoint.x,mPoint.y,ContentWidth,ContentHeight),Value.ToString(), style);
			//GUI.Label(new Rect(mPoint.x,mPoint.y,ContentWidth,ContentHeight),Value.ToString(), "lable");

		}




	}

	IEnumerator Free()
	{
		yield return new WaitForSeconds(FreeTime);
		Destroy(this.gameObject);
	}
}