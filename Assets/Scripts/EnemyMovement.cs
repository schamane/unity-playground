﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof (NavMeshAgent))]
public class EnemyMovement : MonoBehaviour {

	Transform player;
	NavMeshAgent nav;

	void Awake () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		nav = GetComponent<NavMeshAgent>();	
	}
	
	// Update is called once per frame
	void Update () {
		nav.SetDestination(player.position);
	}
}
