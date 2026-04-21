using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json; // Nhớ cài NuGet Newtonsoft.Json nhé Tùng

namespace QuanLyQuanAn.Forms
{
    public partial class frmTichHopAI : Form
    {
        // API Key chuẩn của Tùng
        private readonly string _apiKey = "AIzaSyAM4qTnok6X8fDC9vpOWhn4w1JqTB5Jsh8";
        private static readonly HttpClient client = new HttpClient();

        public frmTichHopAI()
        {
            InitializeComponent();
            // Thiết lập khung trả lời chuyên nghiệp
            rtbTraLoi.ReadOnly = true;
            rtbTraLoi.BackColor = Color.WhiteSmoke;
            rtbTraLoi.Font = new Font("Segoe UI", 10, FontStyle.Regular);
        }

        private async void btnGui_Click(object sender, EventArgs e)
        {
            string cauHoi = txtCauHoi.Text.Trim();
            if (string.IsNullOrEmpty(cauHoi))
            {
                MessageBox.Show("Vui lòng nhập nội dung cần tư vấn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. Hiển thị nội dung câu hỏi
            rtbTraLoi.SelectionColor = Color.DarkBlue;
            rtbTraLoi.SelectionFont = new Font(rtbTraLoi.Font, FontStyle.Bold);
            rtbTraLoi.AppendText($"\n\nBạn: {cauHoi}");

            rtbTraLoi.SelectionColor = Color.Gray;
            rtbTraLoi.SelectionFont = new Font(rtbTraLoi.Font, FontStyle.Italic);
            rtbTraLoi.AppendText("\nGemini AI đang suy nghĩ... ✨");
            rtbTraLoi.ScrollToCaret();

            // Khóa control để tránh lỗi luồng
            btnGui.Enabled = false;
            txtCauHoi.Enabled = false;

            // Ép hệ thống dùng giao thức bảo mật TLS 1.2 (Sửa lỗi kết nối trên .NET cũ)
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

            try
            {
                // 2. Tạo nội dung gửi đi (Prompt Engineering)
                var payload = new
                {
                    contents = new[] {
                        new {
                            parts = new[] {
                                new { text = $"Bạn là trợ lý ảo Gemini POS của Quán ăn sáng Long Xuyên. Người tạo ra bạn là Vương Hải Tùng. Hãy trả lời bằng tiếng Việt lịch sự, ngắn gọn dưới 3 câu. Câu hỏi: {cauHoi}" }
                            }
                        }
                    }
                };

                string jsonPayload = JsonConvert.SerializeObject(payload);
                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                // --- URL CHUẨN DỰA TRÊN DANH SÁCH ÔNG VỪA QUÉT ĐƯỢC ---
                string url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-flash-latest:generateContent?key={_apiKey}";

                var response = await client.PostAsync(url, content);
                string responseString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    // 3. Phân tích kết quả JSON
                    dynamic jsonResponse = JsonConvert.DeserializeObject(responseString);
                    string aiText = jsonResponse.candidates[0].content.parts[0].text;

                    rtbTraLoi.SelectionColor = Color.Teal;
                    rtbTraLoi.SelectionFont = new Font(rtbTraLoi.Font, FontStyle.Bold);
                    rtbTraLoi.AppendText("\nGemini AI: ");

                    rtbTraLoi.SelectionColor = Color.Black;
                    rtbTraLoi.SelectionFont = new Font(rtbTraLoi.Font, FontStyle.Regular);
                    rtbTraLoi.AppendText(aiText);
                }
                else
                {
                    rtbTraLoi.AppendText("\n[Lỗi API]: Server không phản hồi đúng yêu cầu.");
                    MessageBox.Show("Chi tiết lỗi: " + responseString, "Lỗi Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối hệ thống: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Mở lại control
                btnGui.Enabled = true;
                txtCauHoi.Enabled = true;
                txtCauHoi.Clear();
                txtCauHoi.Focus();
                rtbTraLoi.ScrollToCaret();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}