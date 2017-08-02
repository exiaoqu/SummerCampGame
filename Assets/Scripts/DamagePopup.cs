using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class DamagePopup : MonoBehaviour {

	//Ŀ��λ��
	private Vector3 mTarget;
	//��Ļ����
	private Vector3 mScreen;
	//�˺���ֵ
	public string Value;



	//�ı����
	public float ContentWidth=100;
	//�ı��߶�
	public float ContentHeight=50;

	//GUI����
	private Vector2 mPoint;

	//����ʱ��
	public float FreeTime=1.5F;

	private GameObject popDamageText;
	DamageText popText;
	//private Text


	void Start () 
	{
		//popDamageText = GameObject.FindGameObjectWithTag ("PopupDamage");
		//popDamageText.SetActive (true);
		//��ȡĿ��λ��
		mTarget=transform.position;
		//��ȡ��Ļ����
		mScreen= Camera.main.WorldToScreenPoint(mTarget);
		//����Ļ����ת��ΪGUI����
		mPoint=new Vector2(mScreen.x,Screen.height-mScreen.y);
		//�����Զ������߳�
		StartCoroutine("Free");
	}

	void Update()
	{
		//ʹ�ı��ڴ�ֱ����ɽ����һ��ƫ��
		transform.Translate(Vector3.up * 0.5F * Time.deltaTime);
		//���¼�������
		mTarget=transform.position;
		//��ȡ��Ļ����
		mScreen= Camera.main.WorldToScreenPoint(mTarget);
		//����Ļ����ת��ΪGUI����
		mPoint=new Vector2(mScreen.x,Screen.height-mScreen.y);

		//popDamageText.GetComponent<Text>().text = "+1";
		//GameObject mObject = (GameObject)Instantiate (popDamageText,transform.position,Quaternion.identity );

		//Debug.Log ("11111111");
		//popText = popDamageText.GetComponent<DamageText> ();
		//popText.showPopupContent("++1", mScreen.x, mScreen.y);  


	}

	void OnGUI()
	{		
		//��֤Ŀ���������ǰ��
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

		   //�ڲ�ʹ��GUI������л���
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