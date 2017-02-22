using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseEnergyDEBUG : MonoBehaviour {

	private PerformanceTracker performanceTracker;

	// Use this for initialization
	void Start () {
		performanceTracker = FindObjectOfType<PerformanceTracker>();
	}
	
	public void ButtonClicked () {
		if (performanceTracker.energyValue < performanceTracker.maxEnergyValue) {
			performanceTracker.PositiveAnimation ();
			performanceTracker.energyValue += 1;
			performanceTracker.AddEnergy();
		}
	}

}
