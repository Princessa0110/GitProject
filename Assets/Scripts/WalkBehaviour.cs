using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkBehaviour : StateMachineBehaviour
{
    private const float walkchangechanse = 0.4f;

    float timer;
    List<Transform> points = new List<Transform>();
    NavMeshAgent agent;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      timer = 0;
      Transform pointsObject = GameObject.FindGameObjectWithTag("Points").transform;
      foreach (Transform t in pointsObject)
      {
        points.Add(t);
        agent = animator.GetComponent<NavMeshAgent>();
        agent.SetDestination(points[0].position);
      }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       if (agent.remainingDistance <= agent.stoppingDistance)
       {
        agent.SetDestination(points[Random.Range(0, points.Count)].position);
       }

       timer += Time.deltaTime;
        if(timer > 20)
        {
            if(Random.Range(0f, 1f) < walkchangechanse)
            {
                animator.SetBool("IsWalking", true);
                animator.SetBool("IsWalk", false);

            }
            else
            {
                animator.SetBool("IsWalk", false);
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       agent.SetDestination(agent.transform.position); //остановка NPC из состояния ходьбы
    }
}
