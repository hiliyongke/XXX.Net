// ����������������������������������������������������������������������������������������������������������������������������
// ����   ����ErrorViewModel.cs
// ����   �ߣ�YongkeLi
// ����   ����1.0
// ������ʱ�䣺2020 04 14 9:20
// ������ʱ�䣺2020 04 14 12:14
// ����������������������������������������������������������������������������������������������������������������������������

namespace XXX.Net.WebApi.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}