using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScrollingScript : MonoBehaviour
{
    public Vector2 speed = new Vector2(2, 2);

    public Vector2 direction = new Vector2(-1, 0);

    public bool isLinkedToCamera = false;

    public bool isLooping = false;

    private List<SpriteRenderer> backgroundPart;

    void Start()
    {
        if (isLooping)
        {
            var myRenderer = GetComponent<SpriteRenderer>();

            backgroundPart = new List<SpriteRenderer>();
            GetComponentsInChildren(false, backgroundPart);
            
            if (myRenderer != null) backgroundPart.Remove(myRenderer);

            backgroundPart.OrderBy(t => t.transform.position.x)
                          .ToList();
        }   
    }

    // Update is called once per frame
    void Update()
    {
        var movement = new Vector3(
            speed.x * direction.x,
            speed.y * direction.y,
            0);

        movement *= Time.deltaTime;
        transform.Translate(movement);

        if (isLinkedToCamera)
        {
            Camera.main.transform.Translate(movement);
        }

        if (isLooping)
        {
            var firstChild = backgroundPart.FirstOrDefault();

            if (firstChild != null
                    && firstChild.transform.position.x < Camera.main.transform.position.x
                    && !firstChild.IsVisibleFrom(Camera.main))
            {
                var lastChild = backgroundPart.LastOrDefault();

                var lastPosition = lastChild.transform.position;
                var lastSize = lastChild.bounds.max - lastChild.bounds.min;

                firstChild.transform.position = new Vector3(
                    lastPosition.x + lastSize.x,
                    firstChild.transform.position.y,
                    firstChild.transform.position.z);

                backgroundPart.Remove(firstChild);
                backgroundPart.Add(firstChild);
            }
        }
    }

}
