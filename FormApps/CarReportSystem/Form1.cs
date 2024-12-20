using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CarReportSystem {
    public partial class Form1 : Form {

        //カーレポート管理用リスト
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

        //設定クラスのインスタンス生成
        Settings settings = Settings.getInstance();

        //コンストラクタ
        public Form1() {
            InitializeComponent();
            dgvCarReport.DataSource = listCarReports;
        }

        private void btAddReport_Click(object sender, EventArgs e) {
            if (cbAuthor.Text == "" || cbCarName.Text == "") {
                tslbMessage.Text = "記録者、または車名が未入力です";
                return;
            }

            CarReport carReport = new CarReport {
                Date = dtpDate.Value,
                Author = cbAuthor.Text,
                Maker = GetRadioButtonMaker(),
                CarName = cbCarName.Text,
                Report = tbReport.Text,
                Picture = pbPicture.Image,
            };
            listCarReports.Add(carReport);

            setCbAuthor(cbAuthor.Text);

            dgvCarReport.ClearSelection();  //セレクションを外す
            inputItemsAllClear();   //入力項目をすべてクリア
        }
        //入力項目をすべてクリア
        private void inputItemsAllClear() {
            dtpDate.Value = DateTime.Now;
            cbAuthor.Text = "";
            setRadioButtonMaker(CarReport.MakerGroup.なし);
            cbCarName.Text = "";
            tbReport.Text = "";
            pbPicture.Image = null;
        }

        //記録者の履歴をコンボボックスへ登録（重複なし）
        private void setCbAuthor(string author) {
            if (!cbAuthor.Items.Contains(author))
                cbAuthor.Items.Add(author);
        }
        //車名の履歴をコンボボックスへ登録（重複なし）
        private void setCbCarName(string carName) {
            if (!cbCarName.Items.Contains(carName))
                cbCarName.Items.Add(carName);
        }

        //選択されているメーカー名を列挙型で返す
        private CarReport.MakerGroup GetRadioButtonMaker() {
            if (rbToyota.Checked)
                return CarReport.MakerGroup.トヨタ;
            if (rbNissan.Checked)
                return CarReport.MakerGroup.日産;
            if (rbHonda.Checked)
                return CarReport.MakerGroup.ホンダ;
            if (rbSubaru.Checked)
                return CarReport.MakerGroup.スバル;
            if (rbImport.Checked)
                return CarReport.MakerGroup.輸入車;
            if (rbOther.Checked)
                return CarReport.MakerGroup.その他;

            return CarReport.MakerGroup.その他;
        }
        //指定したメーカーのラジオボタンをセット
        private void setRadioButtonMaker(CarReport.MakerGroup targetMaker) {
            switch (targetMaker) {
                case CarReport.MakerGroup.なし:
                    rbAllClear();
                    break;
                case CarReport.MakerGroup.トヨタ:
                    rbToyota.Checked = true;
                    break;
                case CarReport.MakerGroup.日産:
                    rbNissan.Checked = true;
                    break;
                case CarReport.MakerGroup.ホンダ:
                    rbHonda.Checked = true;
                    break;
                case CarReport.MakerGroup.スバル:
                    rbSubaru.Checked = true;
                    break;
                case CarReport.MakerGroup.輸入車:
                    rbImport.Checked = true;
                    break;
                case CarReport.MakerGroup.その他:
                    rbOther.Checked = true;
                    break;
                default:
                    break;
            }
        }

        private void rbAllClear() {
            rbToyota.Checked = false;
            rbNissan.Checked = false;
            rbHonda.Checked = false;
            rbSubaru.Checked = false;
            rbImport.Checked = false;
            rbOther.Checked = false;
        }

        //画像選択
        private void btPicOpen_Click(object sender, EventArgs e) {
            if (ofdPicFileOpen.ShowDialog() == DialogResult.OK)
                pbPicture.Image = Image.FromFile(ofdPicFileOpen.FileName);
        }

        //画像削除ボタン
        private void btPicDelete_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }

        private void Form1_Load(object sender, EventArgs e) {
            dgvCarReport.Columns["Picture"].Visible = false;  //画像表示しない

            //交互
            dgvCarReport.RowsDefaultCellStyle.BackColor = Color.CadetBlue;
            dgvCarReport.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;

            if (File.Exists("settings.xml")) {
                //設定ファイルを逆シリアル化して背景を設定
                try {
                    using (var xr = XmlReader.Create("settings.xml")) {
                        var serializer = new XmlSerializer(typeof(Settings));
                        var settings = serializer.Deserialize(xr) as Settings;
                        BackColor = Color.FromArgb(settings.MainFormColor);
                        settings.MainFormColor = BackColor.ToArgb();
                        //if (settings != null) {
                        //    BackColor = Color.FromArgb(settings.MainFormColor);
                        //}
                    }
                }
                catch (Exception) {
                    tslbMessage.Text = "色情報ファイルエラー";
                }
            } else {
                tslbMessage.Text = ("色が設定されていません");
            }




        }

        private void dgvCarReport_Click(object sender, EventArgs e) {
            if ((dgvCarReport.Rows.Count == 0)
                || (!dgvCarReport.CurrentRow.Selected)) return;

            dtpDate.Value = (DateTime)dgvCarReport.CurrentRow.Cells["Date"].Value;
            cbAuthor.Text = (string)dgvCarReport.CurrentRow.Cells["Author"].Value;

            setRadioButtonMaker((CarReport.MakerGroup)dgvCarReport.CurrentRow.Cells["Maker"].Value);

            cbCarName.Text = (string)dgvCarReport.CurrentRow.Cells["CarName"].Value;
            tbReport.Text = (string)dgvCarReport.CurrentRow.Cells["Report"].Value;

            pbPicture.Image = (Image)dgvCarReport.CurrentRow.Cells["Picture"].Value;
        }

        //削除ボタン
        private void btDeleteReport_Click(object sender, EventArgs e) {
            if ((dgvCarReport.CurrentRow == null)
                || (!dgvCarReport.CurrentRow.Selected)) return;

            listCarReports.RemoveAt(dgvCarReport.CurrentRow.Index);
            dgvCarReport.ClearSelection();  //セレクションを外す
            //dgvCarReport.CurrentRow = null;
        }

        //修正ボタン
        private void btModifyReport_Click(object sender, EventArgs e) {
            if ((dgvCarReport.CurrentRow == null)
                || (!dgvCarReport.CurrentRow.Selected)) return;

            listCarReports[dgvCarReport.CurrentRow.Index].Date = dtpDate.Value;
            listCarReports[dgvCarReport.CurrentRow.Index].Author = cbAuthor.Text;
            listCarReports[dgvCarReport.CurrentRow.Index].Maker = GetRadioButtonMaker();
            listCarReports[dgvCarReport.CurrentRow.Index].CarName = cbCarName.Text;
            listCarReports[dgvCarReport.CurrentRow.Index].Report = tbReport.Text;
            listCarReports[dgvCarReport.CurrentRow.Index].Picture = pbPicture.Image;

            dgvCarReport.Refresh(); //データグリッドビューの更新
        }

        //記録者のテキストが編集されたら
        private void cbAuthor_TextChanged(object sender, EventArgs e) {
            tslbMessage.Text = "";
        }
        //車名のテキストが編集されたら
        private void cbCarName_TextChanged(object sender, EventArgs e) {
            tslbMessage.Text = "";
        }

        //保存ボタン
        private void btReportSave_Click(object sender, EventArgs e) {
            ReportSaveFile();
        }

        //ファイル保存
        private void ReportSaveFile() {
            if (sfdReportFileSave.ShowDialog() == DialogResult.OK) {
                try {
                    //バイナリー形式でシリアル化
#pragma warning disable SYSLIB0011 // 型またはメンバーが旧型式です
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011 // 型またはメンバーが旧型式です
                    using (FileStream fs = File.Open(sfdReportFileSave.FileName, FileMode.Create)) {
                        bf.Serialize(fs, listCarReports);
                    }
                }
                catch (Exception) {
                    tslbMessage.Text = "書き込みエラー";
                    //MessageBox.Show("エラーが発生しました: " + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //throw;
                }


            }
        }

        //開くボタン
        private void btReportOpen_Click(object sender, EventArgs e) {
            ReportOpenFile();
        }

        //
        private void ReportOpenFile() {
            if (ofdReportFileOpen.ShowDialog() == DialogResult.OK) {
                try {
                    //逆シリアル化でバイナリ形式を取り込む
#pragma warning disable SYSLIB0011 // 型またはメンバーが旧型式です
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011 // 型またはメンバーが旧型式です
                    using (FileStream fs = File.Open(ofdReportFileOpen.FileName, FileMode.Open, FileAccess.Read)) {
                        listCarReports = (BindingList<CarReport>)bf.Deserialize(fs);
                        dgvCarReport.DataSource = listCarReports;
                    }
                    // データグリッドビューの選択を解除
                    dgvCarReport.ClearSelection();

                    // 記録者と車名の履歴を登録する
                    foreach (CarReport report in listCarReports) {
                        setCbAuthor(report.Author);
                        setCbCarName(report.CarName);
                    }
                }
                catch (Exception) {
                    tslbMessage.Text = "ファイル形式が違います";
                    //MessageBox.Show("違うファイルが開かれています", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //throw;
                }
                dgvCarReport.ClearSelection();  //セレクションを外す

            }
        }

        private void btInputItemsClear_Click_1(object sender, EventArgs e) {
            inputItemsAllClear();
            dgvCarReport.ClearSelection();
        }


        private void 開くToolStripMenuItem_Click(object sender, EventArgs e) {
            ReportOpenFile(); //ファイル開く処理
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e) {
            ReportSaveFile();　//ファイル保存処理
        }

        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e) {

            if (MessageBox.Show("本当に終了しますか？", "終了確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes) {
                Application.Exit(); // アプリケーションを終了する
            }
        }

        private void 色設定ToolStripMenuItem_Click(object sender, EventArgs e) {

            if (cdColor.ShowDialog() == DialogResult.OK) {
                BackColor = cdColor.Color; //背景色設定
                settings.MainFormColor = cdColor.Color.ToArgb();   //背景色保存          
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            try {
                using (var xw = XmlWriter.Create("settings.xml")) {
                    var serialazer = new XmlSerializer(settings.GetType());
                    serialazer.Serialize(xw, settings);
                }
            }
            catch (Exception) {
                MessageBox.Show("ファイルの保存に失敗しました");
            }
        }

        private void このアプリについてToolStripMenuItem_Click(object sender, EventArgs e) {
            var fmversion = new fmVersion();
            fmversion.ShowDialog();


        }

        private void pbPicture_Click(object sender, EventArgs e) {

        }
    }

}
