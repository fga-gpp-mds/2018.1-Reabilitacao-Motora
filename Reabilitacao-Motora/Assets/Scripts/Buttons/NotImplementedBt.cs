using UnityEngine;
using UnityEngine.UI;

public class NotImplementedBt : MonoBehaviour 
{
	[SerializeField]
	protected Button nextPage;

	public void Awake ()
	{
		nextPage.onClick.AddListener(delegate{Flow.StaticNotImplemented();});
	}
}