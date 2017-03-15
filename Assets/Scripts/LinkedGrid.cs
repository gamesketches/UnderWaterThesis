﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkedGrid {

	public class GridNode {
		public GridNode North;
		public GridNode South;
		public GridNode West;
		public GridNode East;
		public GameObject Data;
	}

	public GridNode NWCorner;
	public GridNode NECorner;
	public GridNode SWCorner;
	public GridNode SECorner;

	public void AddNWCorner(GameObject data) {
		GridNode newNode = new GridNode();

		newNode.Data = data;
		newNode.East = NWCorner;
		NECorner = newNode;
	}

	public void AddNECorner(GameObject data) {
		GridNode newNode = new GridNode();

		newNode.Data = data;
		newNode.West = NECorner;
		NWCorner = newNode;
	}

	public void AddSWCorner(GameObject data) {
		GridNode newNode = new GridNode();

		newNode.Data = data;
		newNode.East = SWCorner;
		SWCorner = newNode;
	}

	public void AddSECorner(GameObject data) {
		GridNode newNode = new GridNode();

		newNode.Data = data;
		newNode.West = SECorner;
		SECorner = newNode;
	}

	public void AddTopRow(GameObject[] newRow) {
		GridNode newCorner = new GridNode();

		newCorner.Data = newRow[0];
		NWCorner = newCorner;
		for(int i = 1; i < newRow.Length; i++) {
			GridNode newNode = new GridNode();
			newNode.Data = newRow[i];
			newNode.West = newCorner;
			newCorner.East = newNode;

			newCorner = newNode;
		}
		NECorner = newCorner;
	}

	public void AddRow(GameObject[] newRow) {
		GridNode anchor = NWCorner;

		GridNode lastNode = new GridNode();
		lastNode.Data = newRow[0];
		lastNode.North = anchor;
		SWCorner = lastNode;

		for(int i = 0; i < newRow.Length - 1; i++) {
			anchor = anchor.East;
			GridNode temp = new GridNode();
			temp.Data = newRow[i];
			temp.West = lastNode;
			temp.North = anchor;

			lastNode = temp;
		}

		SECorner = lastNode;
	}


}