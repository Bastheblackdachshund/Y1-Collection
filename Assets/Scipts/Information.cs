using UnityEngine;
using UnityEngine.UI;

public class SignInteraction : MonoBehaviour
{
    public GameObject popupPanel; // Assign the UI Panel in the inspector
    public Text popupText; // Assign the Text component in the inspector
    public float interactionDistance = 5f; // Maximum distance to interact with the sign

    private bool isPopupActive = false;

    void Start()
    {
        // Ensure the popup panel is hidden at the start of the game
        if (popupPanel != null)
        {
            popupPanel.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isPopupActive)
            {
                // If the popup is active, close it
                TogglePopup(false);
            }
            else
            {
                // Raycast from the camera's position forward
                Ray ray = new Ray(transform.position, transform.forward);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, interactionDistance))
                {
                    // Check if the object hit by the raycast is tagged as "Sign"
                    if (hit.collider.CompareTag("Sign"))
                    {
                        ShowPopup(hit.collider.gameObject);
                    }
                }
            }
        }
    }

    void ShowPopup(GameObject sign)
    {
        // Here you would set the text based on the sign object
        // For example, you can have a component on the sign that holds the information
        SignInfo signInfo = sign.GetComponent<SignInfo>();
        if (signInfo != null)
        {
            popupText.text = signInfo.infoText;
            TogglePopup(true);
        }
    }

    void TogglePopup(bool show)
    {
        isPopupActive = show;
        popupPanel.SetActive(show);
    }
}
