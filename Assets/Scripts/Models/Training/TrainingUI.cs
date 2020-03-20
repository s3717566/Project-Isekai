using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainingUI : MonoBehaviour
{
    public Text Clones;
    public TrainingController trainingController;
    public Character character;

    public Transform physicalAttackBar;
    public Transform physicalDefenceBar;

    private Text physicalAttackLevelText;
    private Text physicalDefenceLevelText;
    private void Start()
    {
        physicalAttackLevelText = physicalAttackBar.Find("pnlTrainingBar").Find("cloneAmount").GetComponent<Text>();
        physicalDefenceLevelText = physicalDefenceBar.Find("pnlTrainingBar").Find("cloneAmount").GetComponent<Text>();
        trainingController.OnUIChanged += training_OnUIChanged;

    }

    private void refresh()
    {
        Clones.text = "Clones used: " + (trainingController.MaxClones - trainingController.ClonesFree()
            + "\nClones free: " + trainingController.ClonesFree());
        physicalAttackLevelText.text = trainingController.PhysicalAttackClones.ToString() + " Clones";
        physicalDefenceLevelText.text = trainingController.PhysicalDefenceClones.ToString() + " Clones";
    }

    private void training_OnUIChanged(object sender, System.EventArgs e)
    {
        refresh();
    }
}
