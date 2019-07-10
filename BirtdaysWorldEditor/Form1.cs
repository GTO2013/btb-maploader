using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BirtdaysWorldEditor
{
    public partial class mainForm : Form
    {

        String gamePath;
        String savePath;
        String profileName;
        String imagePath;
        byte levelHeight = 128;
        byte mapSize;
        FileSystemWatcher fsw;

        public mainForm()
        {
            InitializeComponent();

            gamePath = Properties.Settings.Default.installationPath;

            minHeightControl.Value = Properties.Settings.Default.minHeight;
            maxHeightControl.Value = Properties.Settings.Default.maxHeight;

            gamePath_Text.Text = gamePath;

            imagePath = Properties.Settings.Default.imagePath;
            imagePathText.Text = imagePath;

            //Start FileWatcher
            fsw = new FileSystemWatcher();
            fsw.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            fsw.Filter = "*.*";
            fsw.Created += new FileSystemEventHandler(onFileUpdate);
            fsw.Deleted += new FileSystemEventHandler(onFileUpdate);

            if (!gamePath.Equals("")) findFiles();
        }

        private void onFileUpdate(object source, FileSystemEventArgs e)
        {
            findFiles();
        }

        private void browse_Button_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog openFileDialog1 = new FolderBrowserDialog();

            openFileDialog1.SelectedPath = gamePath;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                gamePath = openFileDialog1.SelectedPath;
                gamePath_Text.Text = gamePath;

                findFiles();
            }
        }

        //Needs valid game Path to work
        private void findFiles()
        {

            string[] files = Directory.GetDirectories(gamePath);
            string profilePath = Path.Combine(gamePath, "Profile");

            if (files.Contains(profilePath))
            {
                files = Directory.GetDirectories(profilePath);

                profileName = Path.GetFileName(files[0]);
                savePath = gamePath + "/Profile/" + profileName + "/Saves/save_data/";
                fsw.Path = savePath;
                fsw.EnableRaisingEvents = true;
                showSaves();

            }
            else
            {
                gamePath = "";
                gamePath_Text.Text = gamePath;
                MessageBox.Show("Error: Profile folder not found!");
            }
        }

        private void showSaves()
        {
            String[] files = Directory.GetDirectories(savePath);

            int y = 0;

            try { 
                savePanel.Invoke((MethodInvoker)delegate
                {
                    // Running on the UI thread
                    savePanel.Controls.Clear();
                });
            }
            catch
            {
                savePanel.Controls.Clear();
            }

            for (int i = 0; i < files.Length + 1; i++ ) {
                String s = "";

                if (i < files.Length)
                    s = files[i];
                else s = "GameData/New";

                if (s.Contains("GameData"))
                {
                    Button l = new Button();
                    l.Text = Path.GetFileName(s);
                    l.Width = 150;
                    l.Top = y;
                    y += l.Height;

                    try{
                        savePanel.Invoke((MethodInvoker)delegate
                         {
                            l.Parent = savePanel;
                         });
                    }
                    catch{
                        l.Parent = savePanel;
                     }

                    if (i < files.Length)
                        l.Click += new EventHandler(editSave_Click);
                    else
                        l.Click += new EventHandler(newMap_Click);
                }
            }
        }

        void newMap_Click(object sender, EventArgs e)
        {
            int i = 1;
            String newDir = "";
            do
            {
                newDir = savePath + "/GameData" + i.ToString("00");
                i++;
            }
            while (Directory.Exists(newDir));

            Directory.CreateDirectory(newDir);
            File.WriteAllBytes(newDir + "/gameinfo.bin", Properties.Resources.gameInfo);
            File.WriteAllBytes(newDir + "/params.bin", Properties.Resources.paramsInfo);

        }

            void editSave_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            String fullPath = savePath + b.Text + "/gameinfo.bin";

            if (File.Exists(imagePath) && File.Exists(fullPath))
            {
                try
                {

                    Bitmap bitmap = new Bitmap(imagePath);
                    int imgSize = bitmap.Size.Width;

                    FileStream fs = File.Open(fullPath, FileMode.Open);

                    //read map size
                    fs.Seek(0x400040, SeekOrigin.Begin);
                    byte mapSizeID = (byte)fs.ReadByte();
                    int startOffset = 0;

                    switch (mapSizeID) {

                        //Mini
                        case 0:
                            mapSize = 31;
                            startOffset = 0x71F0;
                            break;
                        //Small
                        case 10:
                            mapSize = 63;
                            startOffset = 0x61E0;
                            break;
                        //Normal
                        case 20:
                            mapSize = 140;
                            startOffset = 0x41C0;
                            break;
                        //Large
                        case 50:
                            mapSize = 200;
                            startOffset = 0x21A0;
                            break;
                        //Huge
                        case 100:
                            mapSize = 255;
                            startOffset = 0x180;
                            break;
                        default:
                            fs.Close();
                            MessageBox.Show("Error: Unknown Map Type!");
                            return;
                    }

                    fs.Seek(startOffset, SeekOrigin.Begin);

                    int minHeight = -(int)minHeightControl.Value;
                    int maxHeight = (int)maxHeightControl.Value;

                    for (int i = mapSize - 1; i >= 0; i--)
                    {

                        for (int j = mapSize - 1; j >= 0; j--)
                        {
                            int imgX = (int)(imgSize * ((float)i / mapSize));
                            int imgY = (int)(imgSize * ((float)j / mapSize));

                            if (imgX > bitmap.Width) imgX = bitmap.Width;
                            if (imgY > bitmap.Height) imgY = bitmap.Height;

                            Color value = bitmap.GetPixel(imgX, imgY);
                            byte valueB = (byte)(levelHeight - minHeight + ((maxHeight + minHeight) * value.GetBrightness()));

                            fs.WriteByte(valueB);
                        }
                        fs.Seek(256 - mapSize, SeekOrigin.Current);
                    }

                    fs.Close();
                    MessageBox.Show("Wrote to savefile successfully!");
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("Error: Could not find gameinfo.bin file!");
                }
            }
            else {
                MessageBox.Show("Error: No or invalid image selected!");
            }

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = imagePath;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                imagePath = openFileDialog1.FileName;
                imagePathText.Text = imagePath;
            }
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.installationPath = gamePath;
            Properties.Settings.Default.imagePath = imagePath;
            Properties.Settings.Default.minHeight = (int)minHeightControl.Value;
            Properties.Settings.Default.maxHeight = (int) maxHeightControl.Value;
            Properties.Settings.Default.Save();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {

        }

        private void savesGroup_Enter(object sender, EventArgs e)
        {

        }
    }
}
