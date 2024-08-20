using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] int cost = 75;
    [SerializeField] float timeBuild = 0.5f;


    void Start()
    {
        StartCoroutine(Build());    
    }

    public bool CreateTower(Tower tower, Vector3 pos)
    {
        Bank bank = FindObjectOfType<Bank>();

        if (bank == null)
        {
            return false;
        }

        if (bank.CurrentBalance >= cost)
        {
            Instantiate(tower.gameObject, pos, Quaternion.identity);
            bank.Withdraw(cost);
            return true;
        }

        return false;
    }

    IEnumerator Build()
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(false);
            foreach(Transform grandchild in transform)
            {
                grandchild.gameObject.SetActive(false);
            }
        }

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
            yield return new WaitForSeconds(timeBuild);
            foreach (Transform grandchild in transform)
            {
                grandchild.gameObject.SetActive(true);
            }
        }

    }

}
