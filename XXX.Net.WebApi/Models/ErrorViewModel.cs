// ──────────────────────────────────────────────────────────────
// 　文   件：ErrorViewModel.cs
// 　作   者：YongkeLi
// 　版   本：1.0
// 　创建时间：2020 04 14 9:20
// 　更新时间：2020 04 14 12:14
// ──────────────────────────────────────────────────────────────

namespace XXX.Net.WebApi.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}