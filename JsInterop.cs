using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace MAI
{
    public static class JsInterop
    {
        public static Task CopyToClipboard(IJSRuntime jsRuntime, string text)
        {
            return jsRuntime.InvokeVoidAsync("navigator.clipboard.writeText", text).AsTask();
        }
    }
}
