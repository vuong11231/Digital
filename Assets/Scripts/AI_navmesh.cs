using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_navmesh : MonoBehaviour
{
    public Transform[] waypoints; // Mảng chứa các điểm đến
    private NavMeshAgent navMeshAgent;
    private int currentWaypointIndex = 0;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        // Bắt đầu di chuyển tới điểm đầu tiên
        MoveToNextWaypoint();
    }

    void Update()
    {
        // Kiểm tra xem NPC đã đến điểm đến chưa
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.1f)
        {
            // Di chuyển tới điểm tiếp theo
            MoveToNextWaypoint();
        }
    }

    void MoveToNextWaypoint()
    {
        // Kiểm tra xem có điểm đến nào khả dụng không
        if (waypoints.Length > 0)
        {
            // Thiết lập điểm đến cho NavMeshAgent
            navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);

            // Chuyển sang điểm đến tiếp theo trong mảng
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }
}
