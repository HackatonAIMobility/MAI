using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace MAI
{
    /// <summary>
    /// Provides JavaScript interop functionalities for the MAI application.
    /// This static class allows C# code to invoke JavaScript functions, for example,
    /// to interact with browser APIs.
    /// </summary>
    public static class JsInterop
    {
        /// <summary>
        /// Copies the specified text to the client's clipboard using JavaScript interop.
        /// </summary>
        /// <param name="jsRuntime">The <see cref="IJSRuntime"/> instance used to invoke JavaScript functions.</param>
        /// <param name="text">The string to be copied to the clipboard.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation of copying text to the clipboard.</returns>
        public static Task CopyToClipboard(IJSRuntime jsRuntime, string text)
        {
            return jsRuntime.InvokeVoidAsync("navigator.clipboard.writeText", text).AsTask();
        }
    }
}
