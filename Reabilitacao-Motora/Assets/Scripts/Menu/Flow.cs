using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/**
 * Escala o tamanho dos componentes da scene conforme o tamanho da tela.
 */
public class Flow : MonoBehaviour
{

	/**
	 * Finaliza o programa ao clicar em sair.
	 */
	public static void StaticQuit()
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}

	/**
	 * Leva para scene de gravar um movimento.
	 */
	public static void StaticNewMovement()
	{
		SceneManager.LoadScene("NewMovement");
	}

	/**
	 * Leva para scene de gravar um movimento.
	 */
	public static void StaticRealtimeGraphKinectPatient()
	{
		SceneManager.LoadScene("RealtimeGraphKinectPatient");
	}

	public static void StaticRealtimeGraphKinectPhysio()
	{
		SceneManager.LoadScene("RealtimeGraphKinectPhysio");
	}

	public static void StaticRealtimeGraphUDPPatient()
	{
		SceneManager.LoadScene("RealtimeGraphUDPPatient");
	}

	public static void StaticRealtimeGraphUDPPhysio()
	{
		SceneManager.LoadScene("RealtimeGraphUDPPhysio");
	}

	/**
	 * Leva para scene de detalhe de paciente.
	 */
	public static void StaticPatient()
	{
		SceneManager.LoadScene("Patient");
	}

	/**
	 * Leva para scene de detalhe de paciente.
	 */
	public static void StaticPhysiotherapist()
	{
		SceneManager.LoadScene("Physiotherapist");
	}

	/**
	 * Leva para scene de tela de login.
	 */
	public static void StaticLogin()
	{
		SceneManager.LoadScene("Login");
	}


	/**
	 * Leva para scene de lista de movimentos.
	 */
	public static void StaticMovements()
	{
		SceneManager.LoadScene("Movements");
		SceneManager.LoadScene ("ClinicToMoveMenu", LoadSceneMode.Additive);
	}

    /**
     * Leva para scene de gravar um movimento.
     */
    public static void ChoiceSensor()
    {
        SceneManager.LoadScene("ChoiceSensor");
    }

    /**
	 * Leva para scene de registrar novo paciente.
	 */
    public static void StaticNewPatient()
	{
		SceneManager.LoadScene("NewPatient");
	}


	/**
	 * Leva para scene de registrar novo paciente.
	 */
	public static void StaticUpdatePatient()
	{
		SceneManager.LoadScene("UpdatePatient");
	}

	public static void StaticUpdatePhysiotherapist()
	{
		SceneManager.LoadScene("UpdatePhysiotherapist");
	}

	/**
	 * Leva para scene de detalhes de sessão.
	 */
	public static void StaticSession()
	{
		SceneManager.LoadScene("Session");
	}


	/**
	 * Leva para scene de lista de sessões.
	 */
	public static void StaticSessions()
	{
		SceneManager.LoadScene("Sessions");
	}


	/**
	 * Leva para scene de função não implementada.
	 */
	public static void StaticNotImplemented()
	{
		SceneManager.LoadScene("NotImplemented");
	}


	/**
	 * Leva para scene de gráficos.
	 */
	public static void StaticGraphs2()
	{
		SceneManager.LoadScene("GraphsMovimentoPhysio");
	}


	/**
	 * Volta para o menu.
	 */
	public static void StaticMenu()
	{
		SceneManager.LoadScene("Menu");
	}



	/**
	 * Leva para a scene de novo fisioterapeuta.
	 */
	public static void StaticNewPhysiotherapistAdm()
	{
		SceneManager.LoadScene("NewPhysiotherapist Adm");
	}

	public static void StaticNewPhysiotherapistCommon()
	{
		SceneManager.LoadScene("NewPhysiotherapist Common");
	}



	/**
	 * Leva para a scene de nova sessao.
	 */
	public static void StaticNewSession()
	{
		SceneManager.LoadScene("NewSession");
	}



	/**
	 * Leva para a scene que lista os movimentos passíveis de serem reproduzidos num exercício.
	 */
	public static void StaticMovementsToExercise()
	{
		SceneManager.LoadScene("MovementsToExercise");
	}



	/**
	 * Leva para a scene que lista os movimentos passíveis de serem reproduzidos num exercício.
	 */
	public static void StaticEndSession()
	{
		SceneManager.LoadScene("EndSession");
	}



	/**
	 * Leva para a scene que lista os movimentos passíveis de serem reproduzidos num exercício.
	 */
	public static void StaticMovementsToReview()
	{
		SceneManager.LoadScene("MovementsToReview");
	}



	/**
	 * Leva para a scene que lista os movimentos passíveis de serem reproduzidos num exercício.
	 */
	public static void StaticExercisesToReview()
	{
		SceneManager.LoadScene("ExercisesToReview");
	}



	/**
	 * Leva para a scene que lista os movimentos passíveis de serem reproduzidos num exercício.
	 */
	public static void StaticGraphs1()
	{
		SceneManager.LoadScene("GraphsReviewDuranteSessaoPatient");
	}

	/**
	 * Leva para a scene que lista os movimentos passíveis de serem reproduzidos num exercício.
	 */
	public static void StaticGraphs3()
	{
		SceneManager.LoadScene("GraphsExerciciosSalvosPatient");
	}

	/**
	 * Leva para a scene que lista os personagens que podem ser escolhidos pelo paciente/fisioterapeuta.
	 */
	public static void StaticCharacterMenu()
	{
		SceneManager.LoadScene("CharacterMenu");
	}

    /**
	 * Leva para scene de tela de Ajuda.
	 */
    public static void StaticHelp()
    {
        SceneManager.LoadScene("Help");
    }
    /**
	 * Leva para scene de tela de Ajuda de Criar Paciente.
	 */
    public static void StaticHelpPatient()
    {
        SceneManager.LoadScene("HelpPatient");
    }
    /**
	 * Leva para scene de tela de Ajuda de Atualizar o Paciente.
	 */
    public static void StaticHelpUpdate()
    {
        SceneManager.LoadScene("HelpUpdate");
    }
    /**
	 * Leva para scene de tela de Ajuda de Criar Exercício.
	 */
    public static void StaticHelpExercise()
    {
        SceneManager.LoadScene("HelpExercise");
    }
    /**
	 * Leva para scene de tela de Ajuda de Criar Movimento.
	 */
    public static void StaticHelpMovement()
    {
        SceneManager.LoadScene("HelpMovement");
    }
    /**
    * Leva para scene de tela de Ajuda de Rotular Movimento.
    */
    public static void StaticHelpMovimentsLabel()
    {
        SceneManager.LoadScene("HelpMovementLabel");
    }
    /**
	 * Leva para scene de tela de Ajuda de Criar Sessão.
	 */
    public static void StaticHelpSession()
    {
        SceneManager.LoadScene("HelpSession");
    }
    /**
	 * Leva para scene de tela de Ajuda de Resultado da Sessão.
	 */
    public static void StaticHelpResults()
    {
        SceneManager.LoadScene("HelpResults");
    }
    /**
	 * Leva para scene de tela de Ajuda de Rotular Movimento.
	 */
    public static void StaticHelpMovementLabel()
    {
        SceneManager.LoadScene("HelpMovementLabel");
    }
}
