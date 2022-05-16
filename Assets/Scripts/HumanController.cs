using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumanController : MonoBehaviour
{
    NavMeshAgent agent;

    Transform target;
    int searchRadius = 20;
    public LayerMask sevapLayer;
    public LayerMask gunahLayer;
    float bias;
    public float sevapPoint = 0;
    float randomWalkDistance = 10;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        bias = Random.Range(0.25f, 0.75f);
        StartCoroutine(IESearchTarget());
    }

    IEnumerator IESearchTarget()
    {
        while (true)
        {
            if (target != null)
            {
                agent.SetDestination(target.position);
            }
            else
            {
                FindTarget();
                if (target == null)
                {
                    FindRandomLocation();
                }
            }
            yield return new WaitForSeconds(1);
        }
    }

    void FindTarget()
    {
        float decision = Random.Range(0f, 1f);
        decision = 1;
        LayerMask targetLayer;
        if (decision < bias) targetLayer = gunahLayer;
        else targetLayer = sevapLayer;

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, searchRadius, targetLayer);
        Debug.Log("targets found " + hitColliders.Length);
        if (hitColliders.Length > 0)
        {
            int targetIndex = Random.Range(0, hitColliders.Length);
            Debug.Log("targetIndex " + targetIndex);
            if (hitColliders[targetIndex] != null)
                target = hitColliders[targetIndex].transform;
        }
    }

    void FindRandomLocation()
    {
        //temp
        Vector3 newDirection = new Vector3(Random.Range(-randomWalkDistance, randomWalkDistance), 0, Random.Range(-randomWalkDistance, randomWalkDistance));
        agent.SetDestination(transform.position + newDirection);
    }

    public void AddPoint(float point)
    {
        target = null;
        sevapPoint += point;
    }

    //target varse ona git
    //target yoksa etrafi ara, yoksa random bir yere git, her saniye tekrar ara
}
