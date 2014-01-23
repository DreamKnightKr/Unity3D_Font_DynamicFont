using UnityEngine;
using System.Collections;
using System.Text;

public class SampleScene : MonoBehaviour {

	public TextMesh Text3D;
	public TextMesh Text3D2;

	public float fRefreshTxtTime = 1.1f;
	int nCode = 0xeab080;

	// Use this for initialization
	void Start () {
		//Text3D.text = "<color=#40E0D0><size=100>Lose</size></color>\nABCD\n가나다\n最初から始める\n~!@#$%^&*(*)(";
		//Text3D.text = "ABCD\n가나다\n最初から始める\n~!@#$%^&*(*)(";
		Text3D2.text = "ABCD\n가나다\n最初から始める\n~!@#$%^&*(*)(";
	
		StartCoroutine( UpdateText() );
	}

	IEnumerator UpdateText()
	{
		while(true)
		{
			yield return new WaitForSeconds(fRefreshTxtTime);

			string strHex = string.Format("{0:x}", nCode);
			byte[] defaultBytes = Encoding.Default.GetBytes( strHex );  
			//byte[] utf8Bytes = Encoding.Convert( Encoding.Default, Encoding.UTF8, defaultBytes ); 

			{
				// Case 1
				//Text3D2.text = Encoding.Unicode.GetString(defaultBytes);	// Same Length > Texture Same Size

				// Case 2
				Text3D2.text += Encoding.Unicode.GetString(defaultBytes);	// Getting Longer Length > 
			}

			nCode++;
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3( 0, 10.0f * Time.deltaTime,0));
	}
}
