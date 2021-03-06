using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using movimento;
using exercicio;
using movimentomusculo;
using pontosrotulofisioterapeuta;
using pontosrotulopaciente;

public class DeleteMovementButton : MonoBehaviour 
{
	[SerializeField]
	protected Button nextPage;

	public void Awake ()
	{
		nextPage.onClick.AddListener(delegate{DeleteMovement();});
	}

	public static void DeleteMovement ()
	{
		int IdMovimento = GlobalController.instance.movement.idMovimento;

		List<Exercicio> allExercises = Exercicio.Read();
		List<PontosRotuloFisioterapeuta> allPrfs = PontosRotuloFisioterapeuta.Read();
		List<PontosRotuloPaciente> allPrps = PontosRotuloPaciente.Read();
		List<MovimentoMusculo> mm = MovimentoMusculo.Read();

		foreach (var prf in allPrfs)
		{
			if (prf.idMovimento == IdMovimento)
			{
				PontosRotuloFisioterapeuta.DeleteValue (prf.idRotuloFisioterapeuta);
			}
		}


		foreach (var ex in allExercises)
		{
			if (ex.idMovimento == IdMovimento)
			{
				foreach (var prp in allPrps)
				{
					if (prp.idExercicio == ex.idExercicio)
					{
						PontosRotuloPaciente.DeleteValue (prp.idRotuloPaciente);
					}
				}
				string pathEx = string.Format("{0}/Exercicios/{1}", Application.dataPath, ex.pontosExercicio);
				if(File.Exists(pathEx))
				{
					File.Delete(pathEx);
				}
				Exercicio.DeleteValue (ex.idExercicio);
			}
		}

		foreach (var m in mm)
		{
			if (m.idMovimento == IdMovimento)
			{
				MovimentoMusculo.DeleteValue (m.idMovimento, m.idMusculo);
			}
		}

		string pathMov = string.Format("{0}/Movimentos/{1}", Application.dataPath, GlobalController.instance.movement.pontosMovimento);

		if(File.Exists(pathMov))
		{
			File.Delete(pathMov);
		}

		Movimento.DeleteValue (IdMovimento);
	}
}
