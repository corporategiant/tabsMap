    using UnityEngine;
    using System.Runtime.InteropServices; // Required for DllImport

    public class WebGLExitAndRedirect : MonoBehaviour
    {
        // This method will be called from a UI button or other game event
        public void ExitAndRedirect(string url)
        {
            // For older Unity versions, you might use Application.ExternalEval
            // Application.ExternalEval($"window.location.href = '{url}';"); 
            
            // For modern Unity versions and better practice, use the DllImport approach
            // to call a JavaScript function defined in a .jslib file.
            RedirectToURL(url); 
        }

        // Define a JavaScript function to be called from C#
        [DllImport("__Internal")]
        private static extern void RedirectToURL(string url);
    }