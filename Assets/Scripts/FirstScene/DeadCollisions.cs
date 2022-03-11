using UnityEngine;

public class DeadCollisions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        FirstSceneManager.instance.deadPanel.gameObject.SetActive(true);
    }
}
