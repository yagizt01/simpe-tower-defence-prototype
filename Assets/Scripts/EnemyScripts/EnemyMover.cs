using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoints> path = new List<Waypoints>();
    [SerializeField] [Range(0f,5f)] float speed = 1f;

    Enemy enemy;
    void OnEnable()
    {
        FindPath();
        ReturnToStart();
      StartCoroutine(FollowPath());
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }


    void FindPath()
    {

        path.Clear();


        GameObject parent = GameObject.FindGameObjectWithTag("Path");

        foreach (Transform child in parent.transform)
        {
            Waypoints waypoints = child.GetComponent<Waypoints>();

            if (waypoints != null)
            {
                path.Add(waypoints);
            }
            
        }

    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

     void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);

    }

    IEnumerator FollowPath()
    {
        foreach (Waypoints waypoints in path)
        {
            Vector3 startPos = transform.position;
            Vector3 endPos = waypoints.transform.position;
            float timePercent = 0f;

            transform.LookAt(endPos);

            while (timePercent < 1f)
            {
                timePercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPos, endPos, timePercent);
                yield return new WaitForEndOfFrame();
            }

        }

        FinishPath();
    }

   
}
