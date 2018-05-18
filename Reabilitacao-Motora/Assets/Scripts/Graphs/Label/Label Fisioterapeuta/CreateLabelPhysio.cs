using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using pontosrotulofisioterapeuta;

/**
 * Descrever aqui o que essa classe realiza.
 */
public class CreateLabelPhysio : MonoBehaviour
{
	[SerializeField]
	protected GameObject labelPrefab;
	
	string nameLabel = "label name";
	string initialX = "0", finalX = "0";

	/**
	 * Descrever aqui o que esse método realiza.
	 */
	public void displayGraph(string label, Vector2 val)
	{
		GameObject go = Instantiate (labelPrefab) as GameObject;

		go.transform.localPosition = new Vector3 (0f, 0f, 0f);
		go.transform.SetParent (transform, false);

		var scriptInitial = go.GetComponentInChildren<SetInitialX>();
		var scriptFinal = go.GetComponentInChildren<SetFinalX>();
		var labelName = go.GetComponentInChildren<TextMesh>();
		var dbPrfObject = go.GetComponentInChildren<SetLabelPhysio>();

		scriptInitial.InitialX = val.x;
		scriptFinal.FinalX = val.y;

		scriptInitial.Set();
		scriptFinal.Set();

		labelName.text = label;

		PontosRotuloFisioterapeuta.Insert(GlobalController.instance.movement.idMovimento, label, val.x, val.y);
		List<PontosRotuloFisioterapeuta> allPrf = PontosRotuloFisioterapeuta.Read();

		dbPrfObject.Prf = allPrf[allPrf.Count - 1];
	}


	public void OnGUI()
	{
		GUI.Box(new Rect (3 * (Screen.width/5), 7.4f * (Screen.height/9), Screen.width/4, 60),""); 

		GUILayout.BeginArea(new Rect(3 * (Screen.width/5), 7.5f * (Screen.height/9), Screen.width/4, 50));
			GUILayout.BeginHorizontal();
				nameLabel = GUILayout.TextField(nameLabel, GUILayout.Width(120));
				initialX = GUILayout.TextField(initialX, GUILayout.Width(90));
				finalX = GUILayout.TextField(finalX, GUILayout.Width(90));
			GUILayout.EndHorizontal();

			if (GUILayout.Button("Apply to Chart")) 
			{
				string label = nameLabel;
				Vector2 val = new Vector2 (float.Parse(initialX), float.Parse(finalX));
				displayGraph (label, val);
			}

		GUILayout.EndArea();
	}
}
