using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using pessoa;
using paciente;

/**
 * Cria um novo paciente no banco de dados.
 */
public class loadSession : MonoBehaviour 
{
	[SerializeField]
	protected InputField date, notes;
	
	public void Start()
	{
		if(GlobalController.instance.session != null)
		{							
			date.text = GlobalController.instance.session.dataSessao;
			notes.text = GlobalController.instance.session.observacaoSessao;
		}
		else
		{
			Debug.Log("Você violou o acesso!");	
		}

	}
}
