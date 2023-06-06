using GSMLibrary.Models;
using System.ComponentModel;
using System.IO.Ports;
using System.Runtime.InteropServices;

namespace VTPTransfer.Forms
{
    public partial class FrmMain : Form
    {
        private readonly BindingList<GSMCom> GSMComs;
        private readonly object lockRun = new();
        private CancellationTokenSource CancellationTokenSource;

        public readonly object LockCount = new();
        public int totalCanel = 0;
        public int successCancel = 0;
        public int failedCancel = 0;
        public int skipCancel = 0;

        public FrmMain()
        {
            InitializeComponent();
            UseImmersiveDarkMode(this.Handle, true);

            GSMComs = new();

            GSMGridView.AutoGenerateColumns = false;
            GSMGridView.DataSource = GSMComs;
            Init();

            CancellationTokenSource = new();
            ActiveControl = kryptonLabel1;
        }

        private async void Init()
        {
            var tasks = new List<Task>();
            var names = SerialPort.GetPortNames()
                .OrderBy(name =>
                {
                    var number = name.Replace("COM", "");
                    return int.TryParse(number, out int rs) ? rs : 999;
                }).ToList();

            foreach (var name in names)
            {
                var com = new GSMCom(name, name.Replace("COM", ""));
                GSMComs.Add(com);
                tasks.Add(Task.Run(() => com.GetSimInfo()));
            }
            await Task.WhenAll(tasks);
        }

        private async void ProxyInputBtn_MouseUp(object sender, MouseEventArgs e)
        {
            ActiveControl = kryptonLabel1;
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                Multiselect = false
            };
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
        }

        private void DisableBtn(bool disable)
        {
            Invoke(() =>
            {
                StartBtn.Enabled = !disable;
                StopBtn.Enabled = disable;
                ProxyInputBtn.Enabled = !disable;
                ResetBtn.Enabled = !disable;
                ConnectBtn.Enabled = !disable;
                DisconnectBtn.Enabled = !disable;

                ThreadInput.Enabled = !disable;
                AmountInput.Enabled = !disable;
                MaxCheckBox.Enabled = !disable;
                MaxNotEnoughCheckBox.Enabled = !disable;

                ReceiverTextBox.ReadOnly = disable;
            });
        }

        private async void StartBtn_MouseUp(object sender, MouseEventArgs e)
        {
            ActiveControl = kryptonLabel1;
            await Task.Run(async () =>
            {
                try
                {
                    DisableBtn(true);
                    Invoke(() => MessageBox.Show(this, "Chương trình đã bắt đầu", "Thông báo"));
                    var tasks = new List<Task>();

                    CancellationTokenSource = new();
                    await Task.WhenAll(tasks);
                }
                catch (Exception ex)
                {
                    //DataHandler.WriteLog("[StartBtn_MouseUp]", ex);
                }
                finally
                {
                    DisableBtn(false);
                    foreach (var com in GSMComs)
                    {
                        com.PortStatus = $"{com.PortStatus} -> Đã dừng";
                    }
                    Invoke(() => MessageBox.Show(this, "Chương trình đã hoàn thành", "Thông báo"));
                }
            });
        }

        private void StopBtn_MouseUp(object sender, MouseEventArgs e)
        {
            ActiveControl = kryptonLabel1;
            if (CancellationTokenSource.IsCancellationRequested) return;
            CancellationTokenSource.Cancel();
            Invoke(() => MessageBox.Show(this, "Đã dừng chương trình", "Thông báo"));
        }

        private async void ResetBtn_MouseUp(object sender, MouseEventArgs e)
        {
            ActiveControl = kryptonLabel1;
            var tasks = new List<Task>();
            var selectedRows = GetCheckedRows();
            foreach (var row in selectedRows)
            {
                var gsm = (GSMCom)row.DataBoundItem;
                tasks.Add(Task.Run(() => gsm.Reset()));
            }
            await Task.WhenAll(tasks);
            Invoke(() => MessageBox.Show(this, "Đã reset xong", "Thông báo"));
        }

        private async void ConnectBtn_MouseUp(object sender, MouseEventArgs e)
        {
            ActiveControl = kryptonLabel1;
            var tasks = new List<Task>();
            var selectedRows = GetCheckedRows();
            foreach (var row in selectedRows)
            {
                var gsm = (GSMCom)row.DataBoundItem;
                tasks.Add(Task.Run(() => gsm.GetSimInfo()));
            }
            await Task.WhenAll(tasks);
            Invoke(() => MessageBox.Show(this, "Đã kết nối xong", "Thông báo"));
        }

        private async void DisconnectBtn_MouseUp(object sender, MouseEventArgs e)
        {
            ActiveControl = kryptonLabel1;
            var tasks = new List<Task>();
            var selectedRows = GetCheckedRows();
            foreach (var row in selectedRows)
            {
                var gsm = (GSMCom)row.DataBoundItem;
                tasks.Add(Task.Run(() => gsm.Disconnect()));
            }
            await Task.WhenAll(tasks);
            Invoke(() => MessageBox.Show(this, "Đã ngắt kết nối xong", "Thông báo"));
        }

        private List<DataGridViewRow> GetCheckedRows()
        {
            var selectedRows = new List<DataGridViewRow>();
            foreach (DataGridViewCell cell in GSMGridView.SelectedCells)
            {
                DataGridViewRow row = GSMGridView.Rows[cell.RowIndex];
                if (!selectedRows.Contains(row)) selectedRows.Add(row);
            }
            return selectedRows;
        }

        #region Custom Title Bar
        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        private const int DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1 = 19;
        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;

        private static bool UseImmersiveDarkMode(IntPtr handle, bool enabled)
        {
            if (IsWindows10OrGreater(17763))
            {
                var attribute = DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1;
                if (IsWindows10OrGreater(18985))
                {
                    attribute = DWMWA_USE_IMMERSIVE_DARK_MODE;
                }

                int useImmersiveDarkMode = enabled ? 1 : 0;
                return DwmSetWindowAttribute(handle, (int)attribute, ref useImmersiveDarkMode, sizeof(int)) == 0;
            }

            return false;
        }

        private static bool IsWindows10OrGreater(int build = -1)
        {
            return Environment.OSVersion.Version.Major >= 10 && Environment.OSVersion.Version.Build >= build;
        }
        #endregion
    }
}
