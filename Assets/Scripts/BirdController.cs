using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    [SerializeField] private List<Bird> birds;
    [SerializeField] private BirdTrigger birdTrigger;
    public Action onBirdTrigger;

    private void Start()
    {
        foreach (var bird in birds)
        {
            bird.init(this);
            birdTrigger.init(this);
        }
    }
}
