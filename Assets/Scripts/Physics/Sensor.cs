﻿using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour {
    private List<Transform> m_close;
    private List<Transform> m_obstacles;

    private Leader m_leader;

    public List<Transform> CloseEntities {
        get {
            return m_close;
        }
    }

    private void Awake() {
        m_close = new List<Transform>();
        m_obstacles = new List<Transform>();
    }

    private void OnTriggerEnter(Collider other) {
        Follower f = other.GetComponentInParent<Follower>();
        if (f != null) {
            m_close.Add(f.transform);
            return;
        }
        else {
            Obstacle o = other.GetComponent<Obstacle>();
            if (o != null) {
                m_close.Add(o.transform);
                return;
            }
            else {
                Leader l = other.GetComponentInParent<Leader>();
                if (l != null) {
                    m_close.Add(l.transform);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        Follower f = other.GetComponentInParent<Follower>();
        if (f != null) {
            m_close.Remove(f.transform);
            return;
        }
        else {
            Obstacle o = other.GetComponent<Obstacle>();
            if (o != null) {
                m_close.Remove(o.transform);
                return;
            }
            else {
                Leader l = other.GetComponentInParent<Leader>();
                if (l != null) {
                    m_close.Remove(l.transform);
                }
            }
        }
    }
}
