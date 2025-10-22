    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.EventSystems;
    using System.Collections.Generic;
    using TMPro;

    public class TabNextField : MonoBehaviour
    {
        public List<TMP_InputField> inputFields;
        private int currentFieldIndex = 0;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {

            // Determine if Shift is held for reverse tabbing
            bool shiftHeld = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

            // Find the currently selected input field
            GameObject currentSelected = EventSystem.current.currentSelectedGameObject;
            if (currentSelected != null)
            {
                TMP_InputField currentInputField = currentSelected.GetComponent<TMP_InputField>();
                if (currentInputField != null)
                {
                    currentFieldIndex = inputFields.IndexOf(currentInputField);
                }
            }
            // Action if reverse tabbing

                if (shiftHeld)
            {
                currentFieldIndex--;
                if (currentFieldIndex < 0)
                {
                    currentFieldIndex = inputFields.Count - 1; // Wrap around to end
                }
            }
            // Action if tabbing
            else
            {
                currentFieldIndex++;
                if (currentFieldIndex >= inputFields.Count)
                {
                    currentFieldIndex = 0; // Wrap around to beginning
                }
            }

                // Select the next/previous input field
                inputFields[currentFieldIndex].Select();
            }
        }
    }