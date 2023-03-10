using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Node based linear path for enemies to follow.
public class EnemyPath : MonoBehaviour {
	Transform[] nodes;

	float length;
	float[] edgeLengths;

	void Awake() {
		nodes = GetComponentsInChildren<Transform>()[System.Range.StartAt(1)];
		edgeLengths = new float[nodes.Length - 1];

		calculateEdgeLengths();
		calculateLength();
	}

	// Store edge lengths for later calculations
	void calculateEdgeLengths() {
		for (int i = 0; (i + 1) < nodes.Length; i++) {
			edgeLengths[i] = Vector3.Distance(nodes[i].position, nodes[i + 1].position);
		}
	}

	// Store total path length for later calculations
	void calculateLength() {
		length = 0;
		for (int i = 0; i < edgeLengths.Length; i++) {
			length += edgeLengths[i];
		}
	}

	// Linearly interpolate through the path
	public Vector3 getPosition(float t) {
		float sectionLength = 0;
		for (int i = 0; i < edgeLengths.Length; i++) {
			sectionLength += edgeLengths[i];
			if (t < (sectionLength / length)) {
				float sectionT = Mathf.InverseLerp(sectionLength - edgeLengths[i], sectionLength, t * length);
				return Vector3.Lerp(nodes[i].position, nodes[i + 1].position, sectionT);
			}
		}
		return nodes[nodes.Length - 1].position;
	}

	// Getters
	public Transform[] getNodes() { return nodes; }
	public float getLength() { return length; }
}
