using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	void calculateEdgeLengths() {
		for (int i = 0; (i + 1) < nodes.Length; i++) {
			edgeLengths[i] = Vector3.Distance(nodes[i].position, nodes[i + 1].position);
		}
	}

	void calculateLength() {
		length = 0;
		for (int i = 0; i < edgeLengths.Length; i++) {
			length += edgeLengths[i];
		}
	}

	// Not very efficient
	// Move to next node while edgeLength[i] /length < interpolant

	// Linearly interpolates throughout the path
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

	public Transform[] getNodes() { return nodes; }
	public float getLength() { return length; }
}
