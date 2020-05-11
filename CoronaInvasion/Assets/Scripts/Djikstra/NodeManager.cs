﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
	[SerializeField]
	private LayerMask unwalkableMask;
	[SerializeField]
	private GridManager grid;
	public Node[,] nodes { get; private set; }

	void Start() {
		CreateNodes();
	}

	private void CreateNodes() {
		Vector2[,] gridPos = grid.gridPos;
		if (gridPos == null) {
			Debug.Log("Grid is null");
		}
		nodes = new Node[gridPos.GetLength(0), gridPos.GetLength(1)];
		for (int i = 0; i < gridPos.GetLength(0); i++) {
			for(int j = 0; j < gridPos.GetLength(1); j++) {
				RaycastHit2D cast = Physics2D.BoxCast(gridPos[i, j], new Vector2(grid.GetGridSizeX()-0.1f, grid.GetGridSizeY()-0.1f),0f,Vector2.zero,0f,unwalkableMask);
				bool walkable = !(cast);
				nodes[i, j] = new Node(walkable, gridPos[i, j]);
			}
		}
	}

	public Node getNodeFromWorldPosition(Node[,] _nodes, Vector2 worldPosition) {
		Tuple<int, int> index = grid.getGridIndexFromWorldPos(worldPosition);
		return _nodes[index.Item1, index.Item2];
	}

	public Tuple<int,int> getIndexFromNode(Node[,] _nodes,Node n) {
		int w = _nodes.GetLength(0); // width
		int h = _nodes.GetLength(1); // height

		for (int x = 0; x < w; ++x) {
			for (int y = 0; y < h; ++y) {
				if (_nodes[x, y].Equals(n))
					return Tuple.Create(x, y);
			}
		}

		return Tuple.Create(-1, -1);
	}


	public List<Node> getNeighbor(Node[,] _nodes,Node n) {
		List<Node> returnArray = new List<Node>();
		int[] dr = { 1, 1, 0, -1, -1, -1, 0, 1 };
		int[] dc = { 0, 1, 1, 1, 0, -1, -1, -1 };

		Tuple<int, int> nodeIndex = getIndexFromNode(_nodes,n);
		for (int i = 0; i < 8; i++) {
			int xIndex = nodeIndex.Item1 + dr[i];
			int yIndex = nodeIndex.Item2 + dc[i];

			if (xIndex < 0 || xIndex > grid.gridNumberX) continue;
			if (yIndex < 0 || yIndex > grid.gridNumberY) continue;

			returnArray.Add(_nodes[xIndex, yIndex]);
		}

		return returnArray;
	}

	private void OnDrawGizmos() {
		Vector2[,] gridPos = grid.gridPos;
		if (gridPos == null) {
			Debug.Log("Grid is null");
		}
		for (int i = 0; i < gridPos.GetLength(0); i++) {
			for (int j = 0; j < gridPos.GetLength(1); j++) {
				Node nowNode = nodes[i, j];
				if (nowNode.walkable) {
					Gizmos.color = Color.green;
				}
				else {
					Gizmos.color = Color.red;
				}
				Gizmos.DrawCube(nowNode.worldPosition, new Vector3(grid.GetGridSizeX() - 0.1f, grid.GetGridSizeY() - 0.1f, 1));
			}
		}
	}

}
